using Microsoft.Extensions.Configuration;
using Models;
using RaspiDashboard.Interfaces;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text;
using UserInterface;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Sockets;


namespace RaspiDashboard.Controllers
{
    public class RaspiApiController : IRaspiApiController
    {
        private GpioObject[]? _gpioObjects;

        private readonly IConfiguration _config;
        private readonly IServiceProvider? _serviceProvider;
        private readonly HttpClient _httpClient;
        private readonly string? _startEndPoint;


        public string? GitSemVer { get; set; }

        private Uri? _webSocketUri;
        

        public RaspiApiController(IConfiguration config, IServiceProvider serviceProvider, IHttpClientFactory httpClientfactory)
        {
            _config = config;
            _serviceProvider = serviceProvider;
            _httpClient = httpClientfactory.CreateClient(_config["ConnectionName"]!);
            _startEndPoint = _config["StartEndPoint"];
            _gpioObjects = _config.GetSection("Gpios").Get<GpioObject[]>()!;

        }

        public async Task<HttpEndPoint[]> GetEndPointsAsync()
        {
            using HttpResponseMessage initResponse = await _httpClient!.GetAsync($"{_startEndPoint}");
            initResponse.EnsureSuccessStatusCode();

            GitSemVer = initResponse.Headers.GetValues("GitSemVer").First();

            var httpEndPointArray = await initResponse.Content.ReadFromJsonAsync<HttpEndPoint[]>();
            return httpEndPointArray!;
        }

        public async Task<dynamic?> CallApiAsync(HttpEndPoint endPoint)
        {
            try
            {
                var method = endPoint!.HttpMethod.ToUpper();

                if (method.Equals("GET"))
                {
                    using HttpResponseMessage response = await _httpClient!.GetAsync(endPoint?.HttpCallEndPoint);
                    response.EnsureSuccessStatusCode();

                    if (endPoint!.HttpCallEndPoint == _config["TemperatureInfo"])
                    {
                        return await response.Content.ReadFromJsonAsync<TemperatureInfoObject>();
                    }

                    if (endPoint!.HttpCallEndPoint == _config["CpuInfo"])
                    {
                        return await response.Content.ReadFromJsonAsync<CPUInfoObject>();
                    }

                    if (endPoint!.HttpCallEndPoint == _config["SystemInfo"])
                    {

                        return await response.Content.ReadFromJsonAsync<SystemInfoObject>();
                    }

                    if (endPoint!.HttpCallEndPoint == _config["MemoryInfo"])
                    {
                        return await response.Content.ReadFromJsonAsync<MemoryInfoObject>();
                    }

                    MessageBox.Show("Invalid EndPoint", "Error");
                    return null;
                }

                if (method.Equals("PUT"))
                {
                    using JsonContent gpioContent = JsonContent.Create(_gpioObjects);
                    using HttpResponseMessage response = await _httpClient!.PutAsync(endPoint?.HttpCallEndPoint, gpioContent);
                    response.EnsureSuccessStatusCode();
                    _gpioObjects = await response.Content.ReadFromJsonAsync<GpioObject[]>();
                    return _gpioObjects;

                }

                MessageBox.Show($"Endpoint Error", "Error");
                return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return null;
            }

        }

        public GpioObject[]? CleanUp()
        {
            try
            {
                using JsonContent gpioContent = JsonContent.Create(_gpioObjects);
                HttpResponseMessage response = _httpClient!.PutAsync(_config["GpioLow"], gpioContent).Result;
                response.EnsureSuccessStatusCode();
                _gpioObjects = response.Content.ReadFromJsonAsync<GpioObject[]>().Result;
               
                return _gpioObjects!;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message, "Error");
                else
                    MessageBox.Show(ex.Message, "Error");

                return null;
            }
        }

        public async Task DoWebSocketAsync()
        {
            string portNumber = _config["PortNumber"]!;
            string hostName = _config["HostName"]!;
            string gpioStatusEndPoint = _config["GpioStatus"]!;

            using ClientWebSocket ws = new();
            if (Uri.TryCreate($"ws://{hostName}:{portNumber}/{gpioStatusEndPoint}", UriKind.Absolute, out Uri? uri))
            {
                _webSocketUri = uri;
               
                string authUser = _config["AuthUser"]!;
               
                ws.Options.SetRequestHeader("AUTHORIZED_USER", authUser);

                await ws.ConnectAsync(uri, CancellationToken.None);

                var mainForm = _serviceProvider!.GetRequiredService<MainForm>();

                while (true)
                {
                    var receiveBytes = new byte[4 * 1000];
                    var result = await ws.ReceiveAsync(receiveBytes, default);
                    string strRes = Encoding.UTF8.GetString([.. receiveBytes.TakeWhile((v, index) => receiveBytes.Skip(index).Any(w => w != 0x00))]);
                    List<GpioObject> gpioObjectList = JsonSerializer.Deserialize<List<GpioObject>>(strRes)!;
                    mainForm.UpdateGpiosCallback(gpioObjectList);

                    var sendBytes = new byte[2];
                    await ws.SendAsync(sendBytes, WebSocketMessageType.Text, true, default);

                    if (mainForm!.IsClosed)
                    {
                        Thread.Sleep(1000);
                        await ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Closing Client", CancellationToken.None);
                        Thread.Sleep(1000);
                        await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                        break;
                    }
                }
            }
        }
    }
}

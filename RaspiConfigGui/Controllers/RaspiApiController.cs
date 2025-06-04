using Microsoft.Extensions.Configuration;
using RaspiDashboard.Models;
using RaspiDashboard.Constants;
using RaspiDashboard.Interfaces;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace RaspiDashboard.Controllers
{
    public class RaspiApiController : IRaspiApiController
    {
        
        private readonly ConcurrentQueue<GpioObject>? _gpioObjectsQueue;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        private readonly string? _startEndPoint;

        public event GpioEventHandler? OnGpioEvent;
        public long IsClosed = 0;

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
        {
            
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException(nameof(cipherText));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(iv));

            // Declare the string used to hold
            // the decrypted text.
            string? plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                aesAlg.Padding = PaddingMode.PKCS7;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using MemoryStream msDecrypt = new(cipherText);
                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new(csDecrypt);

                // Read the decrypted bytes from the decrypting stream
                // and place them in a string.
                plaintext = srDecrypt.ReadToEnd();

            }

            return plaintext;
        }

        public RaspiApiController(IConfiguration config, IHttpClientFactory httpClientfactory, ConcurrentQueue<GpioObject> gpioObjectsQueue)
        {
            _config = config;
            _httpClient = httpClientfactory.CreateClient(_config["ConnectionName"]!);
            
            _startEndPoint = _config["StartEndPoint"];
            _gpioObjectsQueue = gpioObjectsQueue;

            var gpios = _config.GetSection("Gpios").Get<GpioObject[]>()!;
            foreach (var gp in gpios)
            {
                gpioObjectsQueue!.Enqueue(gp);
            }
        }

        public async Task<(HttpEndPoint[], string)> GetEndPointsAsync()
        {
            using HttpResponseMessage initResponse = await _httpClient!.GetAsync($"{_startEndPoint}");
            initResponse.EnsureSuccessStatusCode();

            var gitSemVer = initResponse.Headers.GetValues("GitSemVer").First();
            var httpEndPoints = await initResponse.Content.ReadFromJsonAsync<HttpEndPoint[]>();

            //var encStream = await initResponse.Content.ReadAsStreamAsync();
            //using var memoryStream = new MemoryStream();
            //await encStream.CopyToAsync(memoryStream);

            //var encryptedBytes =  memoryStream.ToArray();

            //var httpEndPoints = await initResponse.Content.ReadFromJsonAsync<HttpEndPoint[]>();
            //var key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            //var iv = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0D };
            //string resStr = DecryptStringFromBytes_Aes(encryptedBytes, key, iv);
            //var httpEndPoints = JsonSerializer.Deserialize<HttpEndPoint[]>(resStr);
            return (httpEndPoints, gitSemVer)!;
        }

        public async Task<BaseInfoObject?> GetInfoAsync(HttpEndPoint endPoint)
        {
            try
            {
                var method = endPoint?.HttpMethod!.ToUpper();
                var httpCall = endPoint?.HttpCallEndPoint;
                
                using HttpResponseMessage response = await _httpClient!.GetAsync(httpCall);
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

                Debug.WriteLine("Invalid EndPoint");
                return null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "Error");
                return null;
            }

        }

        public async Task<ConcurrentQueue<GpioObject>?> PutGpioAsync(HttpEndPoint endPoint)
        {
            try
            {
                var method = endPoint!.HttpMethod?.ToUpper();
                var httpCall = endPoint?.HttpCallEndPoint;

              
                using JsonContent gpioContent = JsonContent.Create(_gpioObjectsQueue);
                using HttpResponseMessage response = await _httpClient!.PutAsync(httpCall, gpioContent);
                //var encStream = await response.Content.ReadAsStreamAsync();
                //using var memoryStream = new MemoryStream();
                //await encStream.CopyToAsync(memoryStream);
                //var encryptedBytes = memoryStream.ToArray();

                response.EnsureSuccessStatusCode();

                //var key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
                //var iv = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0D };
                //string resStr = DecryptStringFromBytes_Aes(encryptedBytes, key, iv);

                var gpios = await response.Content.ReadFromJsonAsync<ConcurrentQueue<GpioObject>>();
                //var gpios = JsonSerializer.Deserialize<ConcurrentQueue<GpioObject>>(resStr);

                _gpioObjectsQueue!.Clear();
                foreach (var item in gpios!)
                {
                    _gpioObjectsQueue.Enqueue(item);
                }

                return _gpioObjectsQueue;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "Warning");
                return null;
            }
        }

        public async Task GetGpioStatusAsync()
        {
            try 
            { 
                string portNumber = _config["PortNumber"]!;
                string hostName = _config["HostName"]!;
                string gpioStatusEndPoint = _config["GpioStatus"]!;

                bool uriIsValid = Uri.TryCreate($"ws://{hostName}:{portNumber}/{gpioStatusEndPoint}", UriKind.Absolute, out Uri? uri);
              
                if (uriIsValid)
                {
                    using ClientWebSocket ws = new();
                    string authUser = _config["AuthUser"]!;
               
                    ws.Options.SetRequestHeader("AUTHORIZED_USER", authUser);
                    await ws.ConnectAsync(uri!, CancellationToken.None);

                    while (true)
                    {
                        if (IsClosed == 0)
                        {  
                            var receiveBytes = new byte[4 * 1000];
                            var result = await ws.ReceiveAsync(receiveBytes, default);
                            string strRes = Encoding.UTF8.GetString([.. receiveBytes.TakeWhile((v, index) => receiveBytes.Skip(index).Any(w => w != 0x00))]);
                            ConcurrentQueue<GpioObject> ?gpioObjectList = JsonSerializer.Deserialize<ConcurrentQueue<GpioObject>>(strRes)!;

                            if(OnGpioEvent != null)
                                OnGpioEvent?.Invoke(this, gpioObjectList);

                            var sendBytes = new byte[1];
                            sendBytes[0] = MiscConstants.EOT;
                            await ws.SendAsync(sendBytes, WebSocketMessageType.Binary, true, default);
                        }

                        if (IsClosed == 1)
                        {
                            
                            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client Closed Connection Gracefully", CancellationToken.None);
                            ws.Dispose();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex) 
            { 
                Debug.WriteLine(ex, "Error");
            }
        }

        public void CleanUp()
        {
            if (_httpClient != null)
            {
                _httpClient.CancelPendingRequests();
                _httpClient!.Dispose();
            }
        }

      
    }
}

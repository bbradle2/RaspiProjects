using Microsoft.Extensions.Configuration;
using Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace RaspiConfigGui
{

    public partial class MainForm : Form
    {
        private readonly string? _initEndPoint;
        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;
        private readonly HttpClient _httpClient;

        private GpioObject[]? _gpioObjects;
        private TemperatureInfoObject? _temperatureInfoObject;
        private CPUInfoObject? _cpuInfoObject;
        private SystemInfoObject? _systemInfoObject;
        private MemoryInfoObject? _memoryInfoObject;
        private bool _isConnected = false;

        public MainForm(IConfiguration config, IServiceProvider serviceProvider, IHttpClientFactory httpClientfactory)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _config = config;
            _initEndPoint = _config["EndPoints"];
            _httpClient = httpClientfactory.CreateClient(_config["ConnectionName"]!);
            _gpioObjects = _config.GetSection("Gpios").Get<GpioObject[]>()!;

            Init().GetAwaiter();
        }

        private async Task Init()
        {
            try
            {
                this.Text = "Loading.....";
                CmbHttpEndPoints.Enabled = false;

                using HttpResponseMessage initResponse = await _httpClient!.GetAsync($"{_initEndPoint}");
                initResponse.EnsureSuccessStatusCode();
                var httpEndPointArray = await initResponse.Content.ReadFromJsonAsync<HttpEndPoint[]>();

                CmbHttpEndPoints.DataSource = httpEndPointArray;
                CmbHttpEndPoints.ValueMember = "HttpMethod";
                CmbHttpEndPoints.DisplayMember = "HttpCallEndPoint";
                CmbHttpEndPoints.SelectedItem = httpEndPointArray!
                    .Where(s => s.HttpCallEndPoint == _config["GpioHigh"])
                    .First();

                await MakeApiCall();
               
                CmbHttpEndPoints.Enabled = true;

                _isConnected = true;

            }
            catch (Exception ex)
            {
                this.Text = "Could not connect......";
                CmbHttpEndPoints.Enabled = false;
                MessageBox.Show(this, ex.Message, "Error");
                Close();
            }
            finally
            {
                this.Text = "";
            }

            return;
        }

        private async Task MakeApiCall()
        {
            try
            {
                this.Text = "Performing Call.....";
                CmbHttpEndPoints.Enabled = false;

                var httpendpoint = CmbHttpEndPoints.SelectedItem as HttpEndPoint;
                
                if (httpendpoint!.HttpMethod!.Equals("get", StringComparison.CurrentCultureIgnoreCase))
                {
                    using HttpResponseMessage response = await _httpClient!.GetAsync(httpendpoint?.HttpCallEndPoint);
                    response.EnsureSuccessStatusCode();

                    if(httpendpoint!.HttpCallEndPoint == _config["TemperatureInfo"])
                    {
                        _temperatureInfoObject = await response.Content.ReadFromJsonAsync<TemperatureInfoObject>();
                    } 
                    else if(httpendpoint!.HttpCallEndPoint == _config["CpuInfo"])
                    {
                        _cpuInfoObject = await response.Content.ReadFromJsonAsync<CPUInfoObject>();
                    }
                    else if (httpendpoint!.HttpCallEndPoint == _config["SystemInfo"])
                    {
                        _systemInfoObject = await response.Content.ReadFromJsonAsync<SystemInfoObject>();
                    }
                    else if (httpendpoint!.HttpCallEndPoint == _config["MemoryInfo"])
                    {
                        _memoryInfoObject = await response.Content.ReadFromJsonAsync<MemoryInfoObject>();
                    } 
                    else
                    {
                        MessageBox.Show(this, "Invalid EndPoint", "Error");
                    }
                }
                else if (httpendpoint!.HttpMethod!.Equals("put", StringComparison.CurrentCultureIgnoreCase)) 
                {
                    
                    using JsonContent gpioContent = JsonContent.Create(_gpioObjects);
                    using HttpResponseMessage response = await _httpClient!.PutAsync(httpendpoint?.HttpCallEndPoint, gpioContent);
                    response.EnsureSuccessStatusCode();
                    _gpioObjects = await response.Content.ReadFromJsonAsync<GpioObject[]>();

                }
                else
                {
                    MessageBox.Show(this,$"Endpoint Error", "Error");
                }

                CmbHttpEndPoints.Enabled = true;
            }
            catch (Exception ex)
            {
                CmbHttpEndPoints.Enabled = false;
                MessageBox.Show(this, ex.Message, "Error");

            }
            finally
            {
                this.Text = "";
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(_isConnected) 
            { 
                using JsonContent gpioContent = JsonContent.Create(_gpioObjects);
           
                HttpResponseMessage response = _httpClient!.PutAsync(_config["GpioLow"], gpioContent).Result;
                response.EnsureSuccessStatusCode();
                _gpioObjects = response.Content.ReadFromJsonAsync<GpioObject[]>().Result;
            }
        }

        private async void cmbHttpEndPoints_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await MakeApiCall();
        }
    }
}

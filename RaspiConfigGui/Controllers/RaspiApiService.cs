using Microsoft.Extensions.Configuration;
using RaspiDashboard.Models;
using RaspiDashboard.Interfaces;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Security.Cryptography;


namespace RaspiDashboard.Controllers
{
    public class RaspiApiService : IRaspiApiService
    {
        
        private readonly ConcurrentQueue<GpioObject>? _gpioObjectsQueue;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        private readonly string? _startEndPoint;

        public event GpioChangeEventHandler? OnGpioChangeEvent;
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

        public RaspiApiService(IConfiguration config, IHttpClientFactory httpClientfactory, ConcurrentQueue<GpioObject> gpioObjectsQueue)
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
             
                response.EnsureSuccessStatusCode();

                var gpios = await response.Content.ReadFromJsonAsync<ConcurrentQueue<GpioObject>>();

                _gpioObjectsQueue!.Clear();
                foreach (var item in gpios!)
                {
                    _gpioObjectsQueue.Enqueue(item);
                }

                if (OnGpioChangeEvent != null)
                    OnGpioChangeEvent?.Invoke(this, _gpioObjectsQueue);

                return _gpioObjectsQueue;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "Warning");
                return null;
            }
        }


        public async Task<ConcurrentQueue<GpioObject>> GetGpioStatusAsync()
        {
            using HttpResponseMessage response = await _httpClient!.GetAsync(_config["GpioStatus"]);
            var gpioObjectsQueue = await response.Content.ReadFromJsonAsync<ConcurrentQueue<GpioObject>>();

            if (OnGpioChangeEvent != null)
                OnGpioChangeEvent?.Invoke(this, gpioObjectsQueue);

            return gpioObjectsQueue!;

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

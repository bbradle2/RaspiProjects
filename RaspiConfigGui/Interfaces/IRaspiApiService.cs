using RaspiDashboard.Models;
using System.Collections.Concurrent;

namespace RaspiDashboard.Interfaces
{
    public delegate void GpioChangeEventHandler(object sender, ConcurrentQueue<GpioObject>? _gpioObjects);

    public interface IRaspiApiService
    {

        Task<BaseInfoObject?> GetInfoAsync(HttpEndPoint endPoint);
        Task<ConcurrentQueue<GpioObject>?> PutGpioAsync(HttpEndPoint endPoint);
        Task <(HttpEndPoint[], string)> GetEndPointsAsync();
        event GpioChangeEventHandler? OnGpioChangeEvent;
        void CleanUp();

    }
}
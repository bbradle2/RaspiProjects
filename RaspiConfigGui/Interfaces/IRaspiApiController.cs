using RaspiDashboard.Models;
using System.Collections.Concurrent;

namespace RaspiDashboard.Interfaces
{
    public delegate void GpioEventHandler(object sender, ConcurrentQueue<GpioObject>? _gpioObjects);

    public interface IRaspiApiController
    {

        Task<BaseInfoObject?> GetInfoAsync(HttpEndPoint endPoint);
        Task<ConcurrentQueue<GpioObject>?> PutGpioAsync(HttpEndPoint endPoint);
        Task <(HttpEndPoint[], string)> GetEndPointsAsync();
        event GpioEventHandler? OnGpioEvent;
        public void CleanUp();

    }
}
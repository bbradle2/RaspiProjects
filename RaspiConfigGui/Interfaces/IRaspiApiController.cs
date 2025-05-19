using Models;

namespace RaspiDashboard.Interfaces
{
    public interface IRaspiApiController
    {
        string? GitSemVer { get; set; }

        Task<dynamic?> CallApiAsync(HttpEndPoint endPoint);
        GpioObject[]? CleanUp();
        Task<HttpEndPoint[]> GetEndPointsAsync();
    }
}
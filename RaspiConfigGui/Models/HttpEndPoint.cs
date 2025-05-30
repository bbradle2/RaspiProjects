using System.Text.Json.Serialization;

namespace RaspiDashboard.Models
{
    public class HttpEndPoint
    {
        public string? HttpMethod { get; set; }
        public string? HttpCallEndPoint { get; set; }
    }
}
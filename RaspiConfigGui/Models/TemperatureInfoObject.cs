using System.Text.Json.Serialization;

namespace Models
{
    public class TemperatureInfoObject : BaseInfoObject
    {
        public double TemperatureFahrenheit { get; set; }
        public double TemperatureCelcius { get; set; }
    }
}

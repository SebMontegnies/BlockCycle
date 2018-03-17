using BlockCycle.UI.DAL;

namespace BlockCycle.UI.Models
{
    public class AirQualitySensor
    {
        public decimal GpsX { get; set; }
        public decimal GpsY { get; set; }
        public string Temperature { get; set; }
        public string Humidite { get; set; }
        public string Co2 { get; set; }
        public string PressionAtmospherique { get; set; }

        public static AirQualitySensor Mapper(AIR_QUALITY airQuality)
        {
            return new AirQualitySensor()
            {
                GpsX = airQuality.GPS_X,
                GpsY = airQuality.GPS_X,
                Temperature = $"{airQuality.TEMPERATURE} °C",
                Humidite = $"{airQuality.HUMIDITE} %",
                Co2 = airQuality.CO2.ToString(),
                PressionAtmospherique = airQuality.PRESSION_ATMO.ToString()
            };
        }
    }
}
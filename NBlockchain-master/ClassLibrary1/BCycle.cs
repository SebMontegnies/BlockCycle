namespace BlockCycle.Model
{
    public class BCycle 
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int Altitude { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }
        public Meteo Meteo { get; set; }
        public AirQuality AirQuality { get; set; }
    }
}

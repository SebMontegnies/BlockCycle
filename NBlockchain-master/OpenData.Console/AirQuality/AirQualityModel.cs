using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Console.AirQuality
{

    public class SensorType
    {
        public string name { get; set; }
        public int id { get; set; }
        public string manufacturer { get; set; }
    }

    public class Sensor
    {
        public string pin { get; set; }
        public int id { get; set; }
        public SensorType sensor_type { get; set; }
    }

    public class Sensordatavalue
    {
        public string value_type { get; set; }
        public int id { get; set; }
        public string value { get; set; }
    }

    public class Location
    {
        public string country { get; set; }
        public int id { get; set; }
        public string altitude { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

    public class AirQualityModel
    {
        public string timestamp { get; set; }
        public int id { get; set; }
        public Sensor sensor { get; set; }
        public List<Sensordatavalue> sensordatavalues { get; set; }
        public Location location { get; set; }
        public object sampling_rate { get; set; }
    }
}

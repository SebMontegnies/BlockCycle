using System;
using BlockCycle.UI.DAL;

namespace BlockCycle.UI.Models
{
    public class MeteoPrevisionItem
    {
        public DateTime Date { get; set; }
        public string Temps { get; set; }
        public string Description { get; set; }
        public string TemperatureMaxIntervale { get; set; }
        public string TemperatureMinIntervale { get; set; }
        public string Precipitation { get; set; }
        public string DirectionVent { get; set; }
        public string DirectionVentToolTip { get; set; }
        public string ForceVent { get; set; }
        public string BourrasqueVent { get; set; }
        public string Lune { get; set; }

        public static MeteoPrevisionItem Mapper(METEO meteo)
        {
            return new MeteoPrevisionItem()
            {
                BourrasqueVent = meteo.WIND_GUSTS,
                Date = meteo.DATE,
                Description = meteo.DESC,
                DirectionVent = meteo.WIND_DIRECTION_TEXT,
                DirectionVentToolTip = meteo.WIND_DIRECTION_TOOLTIP,
                ForceVent = meteo.WIND_FORCE,
                Lune = meteo.MOON_TEXT,
                Precipitation = meteo.RAINWATER,
                TemperatureMaxIntervale = meteo.MAX_RANGE,
                TemperatureMinIntervale = meteo.MIN_RANGE,
                Temps = meteo.WEATHER
            };
        }
    }
}
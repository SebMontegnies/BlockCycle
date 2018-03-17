using System;
using BlockCycle.UI.DAL;

namespace BlockCycle.UI.Models
{
    public class MeteoJour
    {
        public DateTime date { get; set; }
        public string Validite { get; set; }
        public string DescriptionGlobal { get; set; }
        public string DescriptionVent { get; set; }
        public string DescriptionHumidite { get; set; }
        public string DescriptionRoute { get; set; }
        public string LeverSoleil { get; set; }
        public string CoucherSoleil { get; set; }
        public string LeverLune { get; set; }
        public string CoucherLune { get; set; }

        public static MeteoJour Mapper(METEO_JOUR meteoJour)
        {
            return new MeteoJour()
            {
                date = meteoJour.DATE,
                Validite = meteoJour.VALIDITE,
                CoucherLune = meteoJour.MOONSET,
                LeverLune = meteoJour.MOONRISE,
                CoucherSoleil = meteoJour.SUNSET,
                LeverSoleil = meteoJour.SUNRISE,
                DescriptionGlobal = meteoJour.DESC_GLOBAL,
                DescriptionHumidite = meteoJour.DESC_HUMIDITE,
                DescriptionRoute = meteoJour.DESC_ROAD,
                DescriptionVent = meteoJour.DESC_WIND
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlockCycle.UI.DAL;

namespace BlockCycle.Models
{
    public class Musee
    {
        public string Nom { get; set; }
        public decimal GpsX { get; set; }
        public decimal GpsY { get; set; }

        public static Musee Mapper(MUSEE musee)
        {
            return new Musee()
            {
                GpsX = musee.GPS_X,
                GpsY = musee.GPS_Y,
                Nom = musee.NOM
            };
        }
    }
}
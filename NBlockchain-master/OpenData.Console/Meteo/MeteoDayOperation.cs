using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenData.Console.Entity;
using OpenData.Console.Model;

namespace OpenData.Console.Meteo
{
    public class MeteoDayOperation
    {
        private readonly BlockChainEntities _blockChainEntities;
        private readonly OpenDataContext _openDataContext;

        public MeteoDayOperation(BlockChainEntities blockChainEntities, OpenDataContext openDataContext)
        {
            _blockChainEntities = blockChainEntities;
            _openDataContext = openDataContext;
        }

        public void SetData()
        {
            _blockChainEntities.Database.ExecuteSqlCommand("DELETE FROM METEO_JOUR");

            var lines = File.ReadLines(_openDataContext.FileName).ToList();
            METEO_JOUR meteoJour = new METEO_JOUR()
            {
                DATE = DateTime.Today
            };

            lines.RemoveAt(0);
            lines.RemoveAt(0);
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                var data = line.Split(';');

                if (data[0] == $"validity")
                    meteoJour.VALIDITE = data[1];
                else if (data[0] == $"description_global")
                    meteoJour.DESC_GLOBAL = data[1];
                else if (data[0] == $"description_wind")
                    meteoJour.DESC_WIND = data[1];
                else if (data[0] == $"description_humidity")
                    meteoJour.DESC_HUMIDITE = data[1];
                else if (data[0] == $"sunrise")
                    meteoJour.SUNRISE = data[1];
                else if (data[0] == $"sunset")
                    meteoJour.SUNSET = data[1];
                else if (data[0] == $"moonrise")
                    meteoJour.MOONRISE = data[1];
                else if (data[0] == $"moonset")
                    meteoJour.MOONSET = data[1];
                else if (data[0] == $"description_road")
                    meteoJour.DESC_ROAD = data[1];
            }

            _blockChainEntities.METEO_JOUR.Add(meteoJour);
            _blockChainEntities.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenData.Console.Entity;
using OpenData.Console.Model;

namespace OpenData.Console.Meteo
{
    public class MeteoOperation
    {
        private readonly BlockChainEntities _blockChainEntities;
        private readonly OpenDataContext _openDataContext;

        public MeteoOperation(BlockChainEntities blockChainEntities, OpenDataContext openDataContext)
        {
            _blockChainEntities = blockChainEntities;
            _openDataContext = openDataContext;
        }

        public void SetData()
        {
            _blockChainEntities.Database.ExecuteSqlCommand("DELETE FROM METEO");

            List<string> lines = File.ReadAllLines(_openDataContext.FileName).ToList();
            lines.RemoveAt(0);
            lines.RemoveAt(0);
            lines.RemoveAt(0);

            string index = "0";
            METEO meteo = new METEO();
            foreach (var line in lines)
            {
                var data = line.Split(';');

                if (line.Substring(0, 1) == index)
                {
                    if (data[0] == $"{index}_date")
                        meteo.DATE = DateTime.Parse(data[1]);
                    else if (data[0] == $"{index}_weather")
                        meteo.WEATHER = $"{data[1]} {data[2]}";
                    else if (data[0] == $"{index}_desc")
                        meteo.DESC = $"{data[1]} {data[2]}";
                    else if (data[0] == $"{index}_max_range")
                        meteo.MAX_RANGE = $"{data[1]} {data[2]}";
                    else if (data[0] == $"{index}_min_range")
                        meteo.MIN_RANGE = $"{data[1]} {data[2]}";
                    else if (data[0] == $"{index}_rainwater")
                        meteo.RAINWATER = $"{data[1]} {data[2]}";
                    else if (data[0] == $"{index}_wind_direction_text")
                        meteo.WIND_DIRECTION_TEXT = $"{data[1]} {data[2]}";
                    else if (data[0] == $"{index}_wind_direction_tooltip")
                        meteo.WIND_DIRECTION_TOOLTIP = $"{data[1]} {data[2]}";
                    else if (data[0] == $"{index}_wind_force")
                        meteo.WIND_FORCE = $"{data[1]} {data[2]}";
                    else if (data[0] == $"{index}_wind_gusts")
                        meteo.WIND_GUSTS = $"{data[1]} {data[2]}";
                    else if (data[0] == $"{index}_moon_text")
                        meteo.MOON_TEXT = $"{data[1]} {data[2]}";
                }
                else
                {
                    if (index != "0")
                    {
                        // Save Data
                        _blockChainEntities.METEO.Add(meteo);
                    }

                    index = line.Substring(0, 1);
                    meteo = new METEO()
                    {
                        DATE = DateTime.Parse(data[1])
                    };
                }
            }

            _blockChainEntities.SaveChanges();
        }
    }
}

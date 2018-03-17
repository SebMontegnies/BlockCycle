using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenData.Console.Entity;
using OpenData.Console.Model;

namespace OpenData.Console.AirQuality
{
    public class AirQualityOperation
    {
        private readonly BlockChainEntities _blockChainEntities;
        private readonly OpenDataContext _openDataContext;
        private List<AirQualityModel> _airQualityModels;

        public AirQualityOperation(BlockChainEntities blockChainEntities, OpenDataContext openDataContext)
        {
            _blockChainEntities = blockChainEntities;
            _openDataContext = openDataContext;
        }

        public void SetData()
        {
            if (_airQualityModels == null)
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(_openDataContext.Uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        HttpContent httpContent = response.Content;
                        _airQualityModels = JsonConvert.DeserializeObject<List<AirQualityModel>>(httpContent.ReadAsStringAsync().Result);
                    }
                }
            }

            if (_airQualityModels != null)
            {
                _blockChainEntities.Database.ExecuteSqlCommand("DELETE FROM AIR_QUALITY");

                foreach (var airQualityModel in _airQualityModels.Where(t => t.sensordatavalues.Any(a => a.value_type == "temperature")))
                {
                    AIR_QUALITY airQuality = new AIR_QUALITY()
                    {
                        GPS_X = Decimal.Parse(airQualityModel.location.latitude.Replace(".",",")),
                        GPS_Y = Decimal.Parse(airQualityModel.location.longitude.Replace(".", ",")),
                        TEMPERATURE = Decimal.Parse(airQualityModel.sensordatavalues.FirstOrDefault(t => t.value_type == "temperature").value.Replace(".",",")),
                        HUMIDITE = Decimal.Parse(airQualityModel.sensordatavalues.FirstOrDefault(t => t.value_type == "humidity").value.Replace(".", ",")),
                        CO2 = 350,
                        PRESSION_ATMO = 1080
                    };

                    _blockChainEntities.AIR_QUALITY.Add(airQuality);
                }

                _blockChainEntities.SaveChanges();
            }
        }
    }
}

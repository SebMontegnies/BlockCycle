using System;
using System.Collections.Generic;
using System.Linq;
using BlockCycle.Models;
using BlockCycle.UI.Models;

namespace BlockCycle.UI.DAL
{
    public class OpenData
    {
        private readonly BlockChainEntities _blockChainEntities;

        public OpenData(BlockChainEntities blockChainEntities)
        {
            _blockChainEntities = blockChainEntities;
        }

        public MeteoJour GetMeteoJour()
        {
            return new MeteoJour { };
            return MeteoJour.Mapper(_blockChainEntities.METEO_JOUR.FirstOrDefault(m => m.DATE == DateTime.Today));
        }

        public IEnumerable<MeteoPrevisionItem> GetMeteoPrevision()
        {
            return null;
            IList<MeteoPrevisionItem> previsions = new List<MeteoPrevisionItem>();
            foreach (METEO meteo in _blockChainEntities.METEO)
            {
                previsions.Add(MeteoPrevisionItem.Mapper(meteo));
            }

            return previsions.AsEnumerable();
        }

        public IEnumerable<AirQualitySensor> GetAirQualitySensors()
        {
            return null;
            IList<AirQualitySensor> sensors = new List<AirQualitySensor>();
            foreach (AIR_QUALITY airQuality in _blockChainEntities.AIR_QUALITY)
            {
                sensors.Add(AirQualitySensor.Mapper(airQuality));
            }

            return sensors.AsEnumerable();
        }

        public Piste GetPiste(string nom, TypePiste typePiste)
        {
            return null;
            if (typePiste==TypePiste.pisteCyclable)
                return Piste.Mapper(_blockChainEntities.PISTE_CYCLABLE_ENTETE.FirstOrDefault(cyc => cyc.NOM == nom));
            if(typePiste==TypePiste.pisteVtt)
                return Piste.Mapper(_blockChainEntities.PISTE_VTT_ENTETE.FirstOrDefault(vtt => vtt.NOM == nom));

            return null;
        }

        public IList<Musee> GetMusees()
        {
            return null;
            IList<Musee> musees = new List<Musee>();
            foreach (MUSEE musee in _blockChainEntities.MUSEE)
            {
                musees.Add(Musee.Mapper(musee));
            }

            return musees;
        }
    }
}
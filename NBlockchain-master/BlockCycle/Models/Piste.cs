using System.Collections.Generic;
using BlockCycle.UI.DAL;

namespace BlockCycle.UI.Models
{
    public enum TypePiste
    {
        pisteVtt = 1,
        pisteCyclable = 2
    }

    public class Piste
    {
        public string Nom { get; set; }
        public TypePiste Type { get; set; }
        public IList<PisteDetail> details { get; set; }

        public static Piste Mapper(PISTE_CYCLABLE_ENTETE pisteCyclableEntete)
        {
            var returnData = new Piste()
            {
                Nom = pisteCyclableEntete.NOM,
                Type = TypePiste.pisteCyclable,
                details = new List<PisteDetail>()
            };

            foreach (var pisteCyclableDetail in pisteCyclableEntete.PISTE_CYCLABLE_DETAIL)
            {
                returnData.details.Add(PisteDetail.Mapper(pisteCyclableDetail));
            }

            return returnData;
        }

        public static Piste Mapper(PISTE_VTT_ENTETE pisteVttEntete)
        {
            var returnData = new Piste()
            {
                Nom = pisteVttEntete.NOM,
                Type = TypePiste.pisteVtt,
                details = new List<PisteDetail>()
            };

            foreach (var pisteVttDetail in pisteVttEntete.PISTE_VTT_DETAIL)
            {
                returnData.details.Add(PisteDetail.Mapper(pisteVttDetail));
            }

            return returnData;
        }
    }
}
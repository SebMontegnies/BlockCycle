using BlockCycle.UI.DAL;

namespace BlockCycle.UI.Models
{
    public class PisteDetail
    {
        public decimal GpsX { get; set; }
        public decimal GpsY { get; set; }
        public int Ordre { get; set; }

        public static PisteDetail Mapper(PISTE_CYCLABLE_DETAIL pisteCyclableDetail)
        {
            return new PisteDetail()
            {
                GpsX = pisteCyclableDetail.GPS_X,
                GpsY = pisteCyclableDetail.GPS_Y,
                Ordre = pisteCyclableDetail.ORDRE
            };
        }

        public static PisteDetail Mapper(PISTE_VTT_DETAIL pisteVttDetail)
        {
            return new PisteDetail()
            {
                GpsX = pisteVttDetail.GPS_X,
                GpsY = pisteVttDetail.GPS_Y,
                Ordre = pisteVttDetail.ORDRE
            };
        }
    }
}
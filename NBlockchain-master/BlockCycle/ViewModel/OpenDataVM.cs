using System.Collections.Generic;
using BlockCycle.Model;
using BlockCycle.Models;
using BlockCycle.UI.Models;

namespace BlockCycle.UI.ViewModel
{
    public class OpenDataVM
    {
        public MeteoJour meteoJour { get; set; }
        public IEnumerable<MeteoPrevisionItem> MeteoPrevision { get; set; }
        public IEnumerable<AirQualitySensor> AirQualitySensors { get; set; }
        public IEnumerable<Musee> Musees { get; set; }
        public Piste Piste { get; set; }
        public Course CurrentCourse { get; set; }
        public Ant Ant { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenData.Console.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class METEO
    {
        public int ID_METEO { get; set; }
        public System.DateTime DATE { get; set; }
        public string WEATHER { get; set; }
        public string DESC { get; set; }
        public string MAX_RANGE { get; set; }
        public string MIN_RANGE { get; set; }
        public string RAINWATER { get; set; }
        public string WIND_DIRECTION_TEXT { get; set; }
        public string WIND_DIRECTION_TOOLTIP { get; set; }
        public string WIND_FORCE { get; set; }
        public string WIND_GUSTS { get; set; }
        public string MOON_TEXT { get; set; }
    }
}

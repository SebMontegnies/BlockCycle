//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlockCycle.UI.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PISTE_CYCLABLE_DETAIL
    {
        public int ID_PISTE_CYCLABLE_DETAIL { get; set; }
        public int ID_PISTE_CYCLABLE_ENTETE { get; set; }
        public int ORDRE { get; set; }
        public decimal GPS_X { get; set; }
        public decimal GPS_Y { get; set; }
    
        public virtual PISTE_CYCLABLE_ENTETE PISTE_CYCLABLE_ENTETE { get; set; }
    }
}

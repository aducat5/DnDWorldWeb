//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DnDWorld.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lore
    {
        public int LoreID { get; set; }
        public int LoreTypeID { get; set; }
        public string LoreContent { get; set; }
        public int AuthorID { get; set; }
        public int UniverseID { get; set; }
        public Nullable<int> PlanetID { get; set; }
    
        public virtual LoreType LoreType { get; set; }
        public virtual User User { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DnDWorld.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoreType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoreType()
        {
            this.Lores = new HashSet<Lore>();
        }
    
        public int LoreTypeID { get; set; }
        public string LoreTypeName { get; set; }
        public string LoreTypeDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lore> Lores { get; set; }
    }
}
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
    
    public partial class Character
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Character()
        {
            this.CharacterClasses = new HashSet<CharacterClass>();
            this.CharacterDescriptions = new HashSet<CharacterDescription>();
            this.CharacterItems = new HashSet<CharacterItem>();
        }
    
        public int CharacterID { get; set; }
        public int OwnerID { get; set; }
        public string Fullname { get; set; }
        public int RaceID { get; set; }
        public int Experience { get; set; }
        public string PicturePath { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDead { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CharacterClass> CharacterClasses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CharacterDescription> CharacterDescriptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CharacterItem> CharacterItems { get; set; }
        public virtual Race Race { get; set; }
        public virtual User User { get; set; }
    }
}
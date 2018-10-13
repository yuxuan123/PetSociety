//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetSociety.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Pet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Pet()
        {
            this.T_Market = new HashSet<T_Market>();
            this.T_Post = new HashSet<T_Post>();
            this.T_User = new HashSet<T_User>();
        }
    
        public System.Guid PetID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeOthers { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string BloodType { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public string Characteristic { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Market> T_Market { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Post> T_Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_User> T_User { get; set; }
    }
}

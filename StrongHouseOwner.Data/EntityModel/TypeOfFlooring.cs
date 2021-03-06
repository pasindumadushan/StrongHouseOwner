//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StrongHouseOwner.Data.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypeOfFlooring
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeOfFlooring()
        {
            this.TypeOfFlooringSamples = new HashSet<TypeOfFlooringSample>();
        }
    
        public int FlooringTypeId { get; set; }
        public string FlooringTypeCategory { get; set; }
        public string FlooringType { get; set; }
        public string FlooringTypeDetails { get; set; }
        public Nullable<int> FlooringTypeDeletion { get; set; }
        public string FlooringTypeAdvantage { get; set; }
        public string FlooringTypeDisadvantage { get; set; }
        public string FlooringTypeBestUse { get; set; }
        public string FlooringTypeReinstall { get; set; }
        public string FlooringTypeImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeOfFlooringSample> TypeOfFlooringSamples { get; set; }
    }
}

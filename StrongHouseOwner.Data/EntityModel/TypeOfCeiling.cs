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
    
    public partial class TypeOfCeiling
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeOfCeiling()
        {
            this.TypeOfCeilingSamples = new HashSet<TypeOfCeilingSample>();
        }
    
        public int CeilingTypeId { get; set; }
        public string CeilingTypeCategory { get; set; }
        public string CeilingType { get; set; }
        public string CeilingTypeDetails { get; set; }
        public Nullable<int> CeilingTypeDeletion { get; set; }
        public string CeilingTypeAdvantage { get; set; }
        public string CeilingTypeDisadvantage { get; set; }
        public string CeilingTypeBestUse { get; set; }
        public string CeilingTypeReinstall { get; set; }
        public string CeilingTypeImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeOfCeilingSample> TypeOfCeilingSamples { get; set; }
    }
}

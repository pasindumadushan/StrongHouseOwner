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
    
    public partial class HouseDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HouseDetail()
        {
            this.StoredPlans = new HashSet<StoredPlan>();
            this.StoredFloorings = new HashSet<StoredFlooring>();
        }
    
        public int HouseId { get; set; }
        public Nullable<int> UserRefId { get; set; }
        public string HouseName { get; set; }
        public string HouseAddress { get; set; }
        public string HouseAdditionalInformation { get; set; }
        public Nullable<int> NumberOfFloors { get; set; }
        public Nullable<decimal> FloorArea { get; set; }
        public Nullable<decimal> LandArea { get; set; }
        public Nullable<int> NumberOfLivingRooms { get; set; }
        public Nullable<int> NumberOfDiningRooms { get; set; }
        public Nullable<int> NumberOfBedRooms { get; set; }
        public Nullable<int> NumberOfWashRooms { get; set; }
        public Nullable<int> NumberOfKitchens { get; set; }
        public Nullable<int> NumberOfStoreRooms { get; set; }
        public Nullable<int> NumberOfGarages { get; set; }
        public Nullable<decimal> EstimatedValue { get; set; }
        public string HouseImagePath { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoredPlan> StoredPlans { get; set; }
        public virtual UserRegistration UserRegistration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoredFlooring> StoredFloorings { get; set; }
    }
}

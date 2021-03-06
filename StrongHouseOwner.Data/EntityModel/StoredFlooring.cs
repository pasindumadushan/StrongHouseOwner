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
    
    public partial class StoredFlooring
    {
        public int FlooringId { get; set; }
        public int HouseRefId { get; set; }
        public Nullable<int> StoredTypeOfFlooringRefId { get; set; }
        public Nullable<int> StoredTypeOfFlooringSampleRefId { get; set; }
        public string FlooringName { get; set; }
        public string FlooringCategory { get; set; }
        public string FlooringType { get; set; }
        public decimal FlooringArea { get; set; }
        public string FlooringSampleName { get; set; }
        public string FlooringSampleCode { get; set; }
        public string FlooringSampleBrand { get; set; }
        public Nullable<decimal> FlooringSampleHight { get; set; }
        public Nullable<decimal> FlooringSampleWidth { get; set; }
        public Nullable<decimal> FlooringMililiters { get; set; }
        public Nullable<decimal> FlooringSamplePrice { get; set; }
        public Nullable<decimal> FlooringSampleMinAmount { get; set; }
        public Nullable<decimal> FlooringSampleTotalCost { get; set; }
        public string SampleImagePath { get; set; }
        public string TypeOfPartition { get; set; }
    
        public virtual HouseDetail HouseDetail { get; set; }
    }
}

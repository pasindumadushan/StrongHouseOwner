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
    
    public partial class TypeOfWallingSample
    {
        public int WallingTypeSampleId { get; set; }
        public int TypeOfWallingRefId { get; set; }
        public Nullable<int> ShopRefId { get; set; }
        public string WallingTypeSampleCode { get; set; }
        public string WallingTypeSampleName { get; set; }
        public string WallingTypeBrand { get; set; }
        public Nullable<int> WallingTypeSampleSizeHeight { get; set; }
        public Nullable<int> WallingTypeSampleSizeWidth { get; set; }
        public Nullable<int> WallingMilliliters { get; set; }
        public Nullable<decimal> WallingTypeSamplePrice { get; set; }
        public string WallingTypeSampleImagePath { get; set; }
    
        public virtual TypeOfWalling TypeOfWalling { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Domain.Model
{
    public class TypeOfWallingModel
    {
        public int WallingTypeId { get; set; }
        public string WallingTypeCategory { get; set; }
        public string WallingType { get; set; }
        public string WallingTypeDetails { get; set; }
        public Nullable<int> WallingTypeDeletion { get; set; }
        public string WallingTypeAdvantage { get; set; }
        public string WallingTypeDisadvantage { get; set; }
        public string WallingTypeBestUse { get; set; }
        public string WallingTypeReinstall { get; set; }
        public string WallingTypeImage { get; set; }

    }

    public class TypeOfWallingListModel
    {
        public int WallingTypeId { get; set; }
        public string WallingTypeCategory { get; set; }
        public string WallingType { get; set; }
        public string WallingTypeDetails { get; set; }
        public Nullable<int> WallingTypeDeletion { get; set; }
        public string WallingTypeAdvantage { get; set; }
        public string WallingTypeDisadvantage { get; set; }
        public string WallingTypeBestUse { get; set; }
        public string WallingTypeReinstall { get; set; }
        public string WallingTypeImage { get; set; }

    }
}
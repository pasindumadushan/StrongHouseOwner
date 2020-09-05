using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Domain.Model
{
    public class TypeOfCeilingModel
    {
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

    }

    public class TypeOfCeilingListModel
    {
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

    }
}
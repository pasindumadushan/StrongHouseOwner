using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Domain.Model
{
    public class TypeOfFlooringModel
    {
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

    }

    public class TypeOfFlooringListModel
    {
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

    }
}
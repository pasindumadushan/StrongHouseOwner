using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Data.Repository
{
    public class HouseCeilingStoreRepository
    {
        StrongHouseDBEntities objEntity;

        public StoredCeiling GetStoredCeiling(int storedCeilingId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.StoredCeilings.Where(x => x.CeilingId == storedCeilingId).FirstOrDefault();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<StoredCeiling> GetHouseStoredCeilingListRP(int houseId)
        {
            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.StoredCeilings.Where(x => x.HouseRefId == houseId).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public StoredCeiling SaveStoredCeilingRP(StoredCeiling storedCeiling)
        {

            try
            {
                objEntity = new StrongHouseDBEntities();
                objEntity.StoredCeilings.Add(storedCeiling);
                objEntity.SaveChanges();

                return storedCeiling;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public StoredCeiling EditStoredCeilingRP(StoredCeiling storedCeiling)
        {

            objEntity = new StrongHouseDBEntities();

            System.Diagnostics.Debug.WriteLine("CeilingId - " + storedCeiling.CeilingId);
            System.Diagnostics.Debug.WriteLine("HouseId - " + storedCeiling.HouseRefId);
            System.Diagnostics.Debug.WriteLine("CeilingName - " + storedCeiling.CeilingName);
            System.Diagnostics.Debug.WriteLine("CeilingCategory - " + storedCeiling.CeilingCategory);
            System.Diagnostics.Debug.WriteLine("CeilingType - " + storedCeiling.CeilingType);
            System.Diagnostics.Debug.WriteLine("TypeOfPartition - " + storedCeiling.TypeOfPartition);
            System.Diagnostics.Debug.WriteLine("CeilingArea - " + storedCeiling.CeilingArea);

            System.Diagnostics.Debug.WriteLine("CeilingSampleName - " + storedCeiling.CeilingSampleName);
            System.Diagnostics.Debug.WriteLine("CeilingSampleCode - " + storedCeiling.CeilingSampleCode);
            System.Diagnostics.Debug.WriteLine("CeilingSampleBrand - " + storedCeiling.CeilingSampleBrand);
            System.Diagnostics.Debug.WriteLine("CeilingSampleHight - " + storedCeiling.CeilingSampleHight);
            System.Diagnostics.Debug.WriteLine("CeilingSampleWidth - " + storedCeiling.CeilingSampleWidth);
            System.Diagnostics.Debug.WriteLine("CeilingMililiters - " + storedCeiling.CeilingMililiters);
            System.Diagnostics.Debug.WriteLine("CeilingSamplePrice - " + storedCeiling.CeilingSamplePrice);
            System.Diagnostics.Debug.WriteLine("CeilingSampleMinAmount - " + storedCeiling.CeilingSampleMinAmount);
            System.Diagnostics.Debug.WriteLine("CeilingSampleTotalCost - " + storedCeiling.CeilingSampleTotalCost);

            objEntity.Entry(storedCeiling).State = EntityState.Modified;
            objEntity.SaveChanges();


            return storedCeiling;



        }

        public StoredCeiling DeleteStoredCeilingRP(int ceilingId)
        {
            try
            {

                objEntity = new StrongHouseDBEntities();

                StoredCeiling sc = objEntity.StoredCeilings.Find(Convert.ToInt32(ceilingId));

                objEntity.StoredCeilings.Remove(sc);
                objEntity.SaveChanges();

                return sc;

            }
            catch (Exception)
            {

                return null;

            }
        }
    }
}
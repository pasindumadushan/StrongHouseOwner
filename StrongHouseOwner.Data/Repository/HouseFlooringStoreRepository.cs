using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Data.Repository
{
    public class HouseFlooringStoreRepository
    {
        StrongHouseDBEntities objEntity;

        public StoredFlooring GetStoredFlooring(int storedFlooringId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.StoredFloorings.Where(x => x.FlooringId == storedFlooringId).FirstOrDefault();
                
                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public StoredFlooring SaveStoredFlooringRP(StoredFlooring storedFlooring)
        {

            try
            {
                objEntity = new StrongHouseDBEntities();
                objEntity.StoredFloorings.Add(storedFlooring);
                objEntity.SaveChanges();

                return storedFlooring;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public StoredFlooring EditStoredFlooringRP(StoredFlooring storedFlooring)
        {

            objEntity = new StrongHouseDBEntities();

            System.Diagnostics.Debug.WriteLine("FlooringId - " + storedFlooring.FlooringId);
            System.Diagnostics.Debug.WriteLine("HouseId - " + storedFlooring.HouseRefId);
            System.Diagnostics.Debug.WriteLine("FlooringName - " + storedFlooring.FlooringName);
            System.Diagnostics.Debug.WriteLine("FlooringCategory - " + storedFlooring.FlooringCategory);
            System.Diagnostics.Debug.WriteLine("FlooringType - " + storedFlooring.FlooringType);
            System.Diagnostics.Debug.WriteLine("TypeOfPartition - " + storedFlooring.TypeOfPartition);
            System.Diagnostics.Debug.WriteLine("FlooringArea - " + storedFlooring.FlooringArea);

            System.Diagnostics.Debug.WriteLine("FlooringSampleName - " + storedFlooring.FlooringSampleName);
            System.Diagnostics.Debug.WriteLine("FlooringSampleCode - " + storedFlooring.FlooringSampleCode);
            System.Diagnostics.Debug.WriteLine("FlooringSampleBrand - " + storedFlooring.FlooringSampleBrand);
            System.Diagnostics.Debug.WriteLine("FlooringSampleHight - " + storedFlooring.FlooringSampleHight);
            System.Diagnostics.Debug.WriteLine("FlooringSampleWidth - " + storedFlooring.FlooringSampleWidth);
            System.Diagnostics.Debug.WriteLine("FlooringMililiters - " + storedFlooring.FlooringMililiters);
            System.Diagnostics.Debug.WriteLine("FlooringSamplePrice - " + storedFlooring.FlooringSamplePrice);
            System.Diagnostics.Debug.WriteLine("FlooringSampleMinAmount - " + storedFlooring.FlooringSampleMinAmount);
            System.Diagnostics.Debug.WriteLine("FlooringSampleTotalCost - " + storedFlooring.FlooringSampleTotalCost);

            objEntity.Entry(storedFlooring).State = EntityState.Modified;
            objEntity.SaveChanges();


            return storedFlooring;

            

        }
    }
}
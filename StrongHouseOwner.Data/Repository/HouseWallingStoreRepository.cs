using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Data.Repository
{
    public class HouseWallingStoreRepository
    {
        StrongHouseDBEntities objEntity;

        public StoredWalling GetStoredWalling(int storedWallingId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.StoredWallings.Where(x => x.WallingId == storedWallingId).FirstOrDefault();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<StoredWalling> GetHouseStoredWallingListRP(int houseId)
        {
            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.StoredWallings.Where(x => x.HouseRefId == houseId).OrderByDescending(c => c.WallingId).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public StoredWalling SaveStoredWallingRP(StoredWalling storedWalling)
        {

            try
            {
                objEntity = new StrongHouseDBEntities();
                objEntity.StoredWallings.Add(storedWalling);
                objEntity.SaveChanges();

                return storedWalling;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public StoredWalling EditStoredWallingRP(StoredWalling storedWalling)
        {

            objEntity = new StrongHouseDBEntities();

            System.Diagnostics.Debug.WriteLine("WallingId - " + storedWalling.WallingId);
            System.Diagnostics.Debug.WriteLine("HouseId - " + storedWalling.HouseRefId);
            System.Diagnostics.Debug.WriteLine("WallingName - " + storedWalling.WallingName);
            System.Diagnostics.Debug.WriteLine("WallingCategory - " + storedWalling.WallingCategory);
            System.Diagnostics.Debug.WriteLine("WallingType - " + storedWalling.WallingType);
            System.Diagnostics.Debug.WriteLine("TypeOfPartition - " + storedWalling.TypeOfPartition);
            System.Diagnostics.Debug.WriteLine("WallingArea - " + storedWalling.WallingArea);

            System.Diagnostics.Debug.WriteLine("WallingSampleName - " + storedWalling.WallingSampleName);
            System.Diagnostics.Debug.WriteLine("WallingSampleCode - " + storedWalling.WallingSampleCode);
            System.Diagnostics.Debug.WriteLine("WallingSampleBrand - " + storedWalling.WallingSampleBrand);
            System.Diagnostics.Debug.WriteLine("WallingSampleHight - " + storedWalling.WallingSampleHight);
            System.Diagnostics.Debug.WriteLine("WallingSampleWidth - " + storedWalling.WallingSampleWidth);
            System.Diagnostics.Debug.WriteLine("WallingMililiters - " + storedWalling.WallingMililiters);
            System.Diagnostics.Debug.WriteLine("WallingSamplePrice - " + storedWalling.WallingSamplePrice);
            System.Diagnostics.Debug.WriteLine("WallingSampleMinAmount - " + storedWalling.WallingSampleMinAmount);
            System.Diagnostics.Debug.WriteLine("WallingSampleTotalCost - " + storedWalling.WallingSampleTotalCost);

            objEntity.Entry(storedWalling).State = EntityState.Modified;
            objEntity.SaveChanges();


            return storedWalling;



        }

        public StoredWalling DeleteStoredWallingRP(int wallingId)
        {
            try
            {

                objEntity = new StrongHouseDBEntities();

                StoredWalling sw = objEntity.StoredWallings.Find(Convert.ToInt32(wallingId));

                objEntity.StoredWallings.Remove(sw);
                objEntity.SaveChanges();

                return sw;

            }
            catch (Exception)
            {

                return null;

            }
        }
    }
}
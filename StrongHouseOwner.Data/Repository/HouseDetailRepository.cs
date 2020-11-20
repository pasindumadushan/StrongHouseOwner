using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Data.Repository
{
    public class HouseDetailRepository
    {

        StrongHouseDBEntities objEntity;
        public List<HouseDetail> GetHouseDetailListRP(int userId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.HouseDetails.Where(x => x.UserRefId == userId).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public HouseDetail GetHouseDetailRP(int houseId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.HouseDetails.Where(x => x.HouseId == houseId).FirstOrDefault();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }
        }


        public HouseDetail SaveHouseDetailRP(HouseDetail houseDetail)
        {

            try
            {
                objEntity = new StrongHouseDBEntities();
                objEntity.HouseDetails.Add(houseDetail);
                objEntity.SaveChanges();

                return houseDetail;
            }
            catch(Exception)
            {
                return null;
            }

        }

        public HouseDetail EditHouseDetailRP(HouseDetail houseDetail)
        {
            try
            {

                objEntity = new StrongHouseDBEntities();

                objEntity.Entry(houseDetail).State = EntityState.Modified;
                objEntity.SaveChanges();

                return houseDetail;

            }
            catch (Exception)
            {

                return null;

            }
        }

        public HouseDetail DeleteHouseDetailRP(int houseId)
        {
            try
            {

                objEntity = new StrongHouseDBEntities();

                HouseDetail hd = objEntity.HouseDetails.Find(houseId);

                objEntity.HouseDetails.Remove(hd);
                objEntity.SaveChanges();

                return hd;

            }
            catch (Exception)
            {

                return null;

            }
        }

    }
}
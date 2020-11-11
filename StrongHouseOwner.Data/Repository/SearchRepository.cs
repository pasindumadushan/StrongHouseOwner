using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Data.Repository
{
    public class SearchRepository
    {
        StrongHouseDBEntities objEntity;
        public List<HouseDetail> HouseDetailSearchRP(int userId, string searchBy, string searchValue)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                List<HouseDetail> objResult = new List<HouseDetail>();

                if (searchBy == "Name")
                {
                    objResult = objEntity.HouseDetails.Where(x => x.UserRefId == userId && x.HouseName.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.HouseDetails.Where(x => x.UserRefId == userId && x.HouseAddress.Contains(searchValue)).ToList();
                }
                

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }
    }
}
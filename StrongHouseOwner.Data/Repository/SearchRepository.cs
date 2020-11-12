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

        public List<TypeOfFlooring> GetFlooringListTypesSearchRP(string searchBy, string searchValue)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                List<TypeOfFlooring> objResult = new List<TypeOfFlooring>();
                if (searchBy == "Type")
                {
                    objResult = objEntity.TypeOfFloorings.Where(x => x.FlooringType.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.TypeOfFloorings.Where(x => x.FlooringTypeCategory.Contains(searchValue)).ToList();
                }

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<TypeOfWalling> GetWallingListTypesSearchRP(string searchBy, string searchValue)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                List<TypeOfWalling> objResult = new List<TypeOfWalling>();
                if (searchBy == "Type")
                {
                    objResult = objEntity.TypeOfWallings.Where(x => x.WallingType.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.TypeOfWallings.Where(x => x.WallingTypeCategory.Contains(searchValue)).ToList();
                }

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<TypeOfCeiling> GetCeilingListTypesSearchRP(string searchBy, string searchValue)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                List<TypeOfCeiling> objResult = new List<TypeOfCeiling>();
                if (searchBy == "Type")
                {
                    objResult = objEntity.TypeOfCeilings.Where(x => x.CeilingType.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.TypeOfCeilings.Where(x => x.CeilingTypeCategory.Contains(searchValue)).ToList();
                }

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }


        public List<TypeOfFlooringSample> SamplesFlooringListSearchRP(int flooringTypeId, string searchBy, string searchValue)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                List<TypeOfFlooringSample> objResult = new List<TypeOfFlooringSample>();

                if (searchBy == "Name")
                {
                    objResult = objEntity.TypeOfFlooringSamples.Where(x => x.TypeOfFlooringRefId == flooringTypeId && x.FlooringTypeSampleName.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.TypeOfFlooringSamples.Where(x => x.TypeOfFlooringRefId == flooringTypeId && x.FlooringTypeSampleCode.Contains(searchValue)).ToList();
                }


                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<TypeOfWallingSample> SamplesWallingListSearchRP(int wallingTypeId, string searchBy, string searchValue)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                List<TypeOfWallingSample> objResult = new List<TypeOfWallingSample>();

                if (searchBy == "Name")
                {
                    objResult = objEntity.TypeOfWallingSamples.Where(x => x.TypeOfWallingRefId == wallingTypeId && x.WallingTypeSampleName.Contains(searchValue)).ToList();
                }
                else if (searchBy == "Code")
                {
                    objResult = objEntity.TypeOfWallingSamples.Where(x => x.TypeOfWallingRefId == wallingTypeId && x.WallingTypeSampleCode.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.TypeOfWallingSamples.Where(x => x.TypeOfWallingRefId == wallingTypeId && x.WallingTypeBrand.Contains(searchValue)).ToList();
                }

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<TypeOfCeilingSample> SamplesCeilingListSearchRP(int ceilingTypeId, string searchBy, string searchValue)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                List<TypeOfCeilingSample> objResult = new List<TypeOfCeilingSample>();

                if (searchBy == "Name")
                {
                    objResult = objEntity.TypeOfCeilingSamples.Where(x => x.TypeOfCeilingRefId == ceilingTypeId && x.CeilingTypeSampleName.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.TypeOfCeilingSamples.Where(x => x.TypeOfCeilingRefId == ceilingTypeId && x.CeilingTypeSampleCode.Contains(searchValue)).ToList();
                }


                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<StoredPlan> GetHouseStoredPlanListSearchRP(int houseId, string searchBy, string searchValue)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                List<StoredPlan> objResult = new List<StoredPlan>();

                if (searchBy == "Name")
                {
                    objResult = objEntity.StoredPlans.Where(x => x.HouseRefId == houseId && x.PlanName.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.StoredPlans.Where(x => x.HouseRefId == houseId && x.TypeOfPlan.Contains(searchValue)).ToList();
                }

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<StoredFlooring> GetHouseStoredFlooringListSearchRP(int houseId, string searchBy, string searchValue)
        {
            try
            {

                objEntity = new StrongHouseDBEntities();
                List<StoredFlooring> objResult = new List<StoredFlooring>();

                if (searchBy == "Partition")
                {
                    objResult = objEntity.StoredFloorings.Where(x => x.HouseRefId == houseId && x.TypeOfPartition.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.StoredFloorings.Where(x => x.HouseRefId == houseId && x.FlooringCategory.Contains(searchValue)).ToList();
                }

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<StoredWalling> GetHouseStoredWallingListSearchRP(int houseId, string searchBy, string searchValue)
        {
            try
            {

                objEntity = new StrongHouseDBEntities();
                List<StoredWalling> objResult = new List<StoredWalling>();

                if (searchBy == "Partition")
                {
                    objResult = objEntity.StoredWallings.Where(x => x.HouseRefId == houseId && x.TypeOfPartition.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.StoredWallings.Where(x => x.HouseRefId == houseId && x.WallingCategory.Contains(searchValue)).ToList();
                }
                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<StoredCeiling> GetHouseStoredCeilingListSearchRP(int houseId, string searchBy, string searchValue)
        {
            try
            {

                objEntity = new StrongHouseDBEntities();
                List<StoredCeiling> objResult = new List<StoredCeiling>();

                if (searchBy == "Partition")
                {
                    objResult = objEntity.StoredCeilings.Where(x => x.HouseRefId == houseId && x.TypeOfPartition.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.StoredCeilings.Where(x => x.HouseRefId == houseId && x.CeilingCategory.Contains(searchValue)).ToList();
                }
                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        
        public List<UserRegistration> GetUserListRPSearchRP(string searchBy, string searchValue)
        {
            try
            {
                objEntity = new StrongHouseDBEntities();
                List<UserRegistration> objResult = new List<UserRegistration>();

                if (searchBy == "Username")
                {
                    objResult = objEntity.UserRegistrations.Where(x => x.UserName.Contains(searchValue)).ToList();
                }
                else
                {
                    objResult = objEntity.UserRegistrations.Where(x => x.UserMail.Contains(searchValue)).ToList();
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
using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Data.Repository
{
    public class HousePlanRepository
    {
        StrongHouseDBEntities objEntity;

        public StoredPlan GetHouseStoredPlanRP(int storedPlanId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.StoredPlans.Where(x => x.StoredPlanId == storedPlanId).FirstOrDefault();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<StoredPlan> GetHouseStoredPlanListRP(int houseId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.StoredPlans.Where(x => x.HouseRefId == houseId).OrderByDescending(c => c.StoredPlanId).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<Plan> GetPlanListRP()
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.Plans.ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public StoredPlan SaveStoredPlanRP(StoredPlan storedPlan)
        {

            try
            {
                objEntity = new StrongHouseDBEntities();
                objEntity.StoredPlans.Add(storedPlan);
                objEntity.SaveChanges();

                return storedPlan;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public StoredPlan EditStoredPlanRP(StoredPlan storedPlan)
        {
            try
            {

                objEntity = new StrongHouseDBEntities();

                objEntity.Entry(storedPlan).State = EntityState.Modified;
                objEntity.SaveChanges();

                return storedPlan;

            }
            catch (Exception)
            {

                return null;

            }
        }

        public StoredPlan DeleteStoredPlanRP(int storedPlanId)
        {
            try
            {

                objEntity = new StrongHouseDBEntities();

                StoredPlan sp = objEntity.StoredPlans.Find(Convert.ToInt32(storedPlanId));

                objEntity.StoredPlans.Remove(sp);
                objEntity.SaveChanges();

                return sp;

            }
            catch (Exception)
            {

                return null;

            }
        }
    }
}
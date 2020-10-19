using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Data.Repository
{
    public class RegistrationRepository
    {
        StrongHouseDBEntities objEntity;

        public UserRegistration GetUserRegistration(UserRegistration objUserRegistration)
        {
            objEntity = new StrongHouseDBEntities();
            var objResult = objEntity.UserRegistrations.Where(x => x.UserMail.ToUpper() == objUserRegistration.UserMail.ToUpper()).FirstOrDefault();

            return objResult;
        }

        public UserRegistration GetUserRP(int userId)
        {
            try
            {
                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.UserRegistrations.Where(x => x.UserId == userId).FirstOrDefault();

                return objResult;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<UserRegistration> GetUserListRP()
        {
            try
            {
                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.UserRegistrations.ToList();

                return objResult;
            }
            catch(Exception)
            {
                return null;
            }
            
        }

        public UserRegistration DeleteRP(int userId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                UserRegistration fs = objEntity.UserRegistrations.Find(Convert.ToInt32(userId));

                objEntity.UserRegistrations.Remove(fs);
                objEntity.SaveChanges();

                return fs;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public UserRegistration EditUserRP(UserRegistration objUserRegistration)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                objEntity.Entry(objUserRegistration).State = EntityState.Modified;
                objEntity.SaveChanges();

                return objUserRegistration;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public UserRegistration RegistrationRP(UserRegistration objRegistration)
        {

            objEntity = new StrongHouseDBEntities();
            objEntity.UserRegistrations.Add(objRegistration);
            objEntity.SaveChanges();

            return objRegistration;
        }

        public UserRegistration UpdatePassword(string userMail, string userPassword)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.UserRegistrations.Where(x => x.UserMail.ToUpper() == userMail.ToUpper()).FirstOrDefault();

                objResult.UserPassword = userPassword;

                objEntity.Entry(objResult).State = EntityState.Modified;
                objEntity.SaveChanges();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

    }
}
using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
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


        public UserRegistration RegistrationRP(UserRegistration objRegistration)
        {

            objEntity = new StrongHouseDBEntities();
            objEntity.UserRegistrations.Add(objRegistration);
            objEntity.SaveChanges();

            return objRegistration;
        }

    }
}
using StrongHouseOwner.Data.EntityModel;
using StrongHouseOwner.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Application.Services
{
    public class RegistrationServices
    {
        RegistrationRepository registrationRepository;
        public UserRegistration ExistUser(UserRegistration objUserRegistration)
        {
            registrationRepository = new RegistrationRepository();

            var objResult = registrationRepository.GetUserRegistration(objUserRegistration);

            return objResult;
        }
    }
}
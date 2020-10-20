using StrongHouseOwner.Data.EntityModel;
using StrongHouseOwner.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrongHouseOwner.Controllers
{
    public class CustomerController : Controller
    {
        RegistrationRepository registrationRepository;
        StrongHouseDBEntities objEntity;
        UserRegistration userRegistration;
        // GET: Customer
        public ActionResult UserProfile()
        {
            registrationRepository = new RegistrationRepository();
            var objResult = registrationRepository.GetUserRP(Convert.ToInt32(Session["User_Type"]));

            return View(objResult);
        }
    }
}
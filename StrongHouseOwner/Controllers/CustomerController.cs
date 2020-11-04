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
            var objResult = registrationRepository.GetUserRP(Convert.ToInt32(Session["User_Id"]));

            return View(objResult);
        }

        public ActionResult Edit(int userId)
        {
            registrationRepository = new RegistrationRepository();
            var objResult = registrationRepository.GetUserRP(Convert.ToInt32(Session["User_Id"]));

            return View(objResult);
        }

        [HttpPost]
        public ActionResult EditUser()
        {
            var validation = 0;
            userRegistration = new UserRegistration();
            registrationRepository = new RegistrationRepository();

            userRegistration.UserId = Convert.ToInt32(Request.Form["User_Id"]);
            userRegistration.UserMail = Request.Form["User_Mail"];
            userRegistration.UserName = Request.Form["User_Name"];
            userRegistration.UserPassword = Request.Form["User_Password"];
            userRegistration.UserAge = Convert.ToInt32(Request.Form["User_Age"]);
            userRegistration.UserAddress = Request.Form["User_Address"];
            userRegistration.UserPhoneNumber = Request.Form["User_Phone_Number"];
            userRegistration.UserType = Convert.ToInt32(Request.Form["User_Type"]);

            System.Diagnostics.Debug.WriteLine(userRegistration.UserId);
            System.Diagnostics.Debug.WriteLine(userRegistration.UserMail);
            System.Diagnostics.Debug.WriteLine(userRegistration.UserName);
            System.Diagnostics.Debug.WriteLine(userRegistration.UserPassword);
            System.Diagnostics.Debug.WriteLine(userRegistration.UserAge);
            System.Diagnostics.Debug.WriteLine(userRegistration.UserAddress);

            var objResult = registrationRepository.EditUserRP(userRegistration);

            if (objResult != null)
            {
                validation = 1;
            }
            else
            {
                validation = 0;
            }

            var result = new { validation};
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
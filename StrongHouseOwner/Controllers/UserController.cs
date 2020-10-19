using StrongHouseOwner.Data.EntityModel;
using StrongHouseOwner.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrongHouseOwner.Controllers
{
    public class UserController : Controller
    {
        RegistrationRepository registrationRepository;
        UserRegistration userRegistration;

        // GET: User
        public ActionResult Index()
        {

            registrationRepository = new RegistrationRepository();
            var objResult = registrationRepository.GetUserListRP();

            return View(objResult);

        }

        [HttpGet]
        public ActionResult Delete(int userId)
        {

            registrationRepository = new RegistrationRepository();

            var objResult = registrationRepository.GetUserRP(userId);
            var objResultList = registrationRepository.GetUserListRP();

            ViewBag.ViewBagRefuserId = userId;
            ViewBag.userId = objResult.UserId;
            ViewBag.userName = objResult.UserName;
            ViewBag.userMail = objResult.UserMail;
            ViewBag.userAge = objResult.UserAge;
            ViewBag.userAddress = objResult.UserAddress;
            ViewBag.userPhoneNumber = objResult.UserPassword;
            ViewBag.userType = objResult.UserType;


            return View(objResultList);

        }

        [HttpPost]
        public ActionResult DeleteUser()
        {
            registrationRepository = new RegistrationRepository();
            var UserId = Convert.ToInt32(Request.Form["user_Id"]);

            var objEntity = registrationRepository.DeleteRP(UserId);

            return Json(new { success = objEntity.UserId }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Edit(int userId)
        {

            registrationRepository = new RegistrationRepository();

            var objResult = registrationRepository.GetUserRP(userId);
            var objResultList = registrationRepository.GetUserListRP();

            ViewBag.userId = objResult.UserId;
            ViewBag.userName = objResult.UserName;
            ViewBag.userMail = objResult.UserMail;
            ViewBag.userAge = objResult.UserAge;
            ViewBag.userPassword = objResult.UserPassword;
            ViewBag.userAddress = objResult.UserAddress;
            ViewBag.userPhoneNumber = objResult.UserPhoneNumber;
            ViewBag.userType = objResult.UserType;

            return View(objResultList);

        }

        [HttpPost]
        public ActionResult EditUser()
        {

            userRegistration = new UserRegistration();

            userRegistration.UserId = Convert.ToInt32(Request.Form["user_Id"]);
            userRegistration.UserName = Request.Form["user_Name"];
            userRegistration.UserMail = Request.Form["user_Mail"];
            userRegistration.UserAge = Convert.ToInt32(Request.Form["user_Age"]);
            userRegistration.UserPassword = Request.Form["user_Password"];
            userRegistration.UserAddress = Request.Form["user_Address"];
            userRegistration.UserPhoneNumber = Request.Form["user_Phone_Number"];
            userRegistration.UserType = Convert.ToInt32(Request.Form["user_Type"]);

            registrationRepository = new RegistrationRepository();
            var objEntity = registrationRepository.EditUserRP(userRegistration);

            return Json(objEntity);

        }
    }
}
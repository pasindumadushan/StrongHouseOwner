using StrongHouseOwner.Application.Services;
using StrongHouseOwner.Data.EntityModel;
using StrongHouseOwner.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace StrongHouseOwner.Controllers
{

    public class LoginController : Controller
    {
        UserRegistration userLogin;
        StrongHouseDBEntities objEntity;
        RegistrationServices registrationServices;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            int validation;
            userLogin = new UserRegistration();
            registrationServices = new RegistrationServices();

            userLogin.UserMail = Request.Form["User_Mail"];

            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(Request.Form["User_Password"]);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            var hashPassword = BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();

            userLogin.UserPassword = hashPassword;

            var objResult = registrationServices.ExistUser(userLogin);

            if (objResult == null)
            {
                validation = 0;
            }
            else if (objResult != null && objResult.UserMail.ToUpper() == userLogin.UserMail.ToUpper() && objResult.UserPassword == userLogin.UserPassword)
            {
                validation = 2;

                Session["User_Name"] = objResult.UserName;
                Session["User_Id"] = objResult.UserId;
                Session["User_Mail"] = objResult.UserMail;
                Session["User_Password"] = objResult.UserPassword;
                Session["User_Type"] = objResult.UserType;
            }
            else
            {
                validation = 1;
            }

            var result = new { validation };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {
            Session["User_Name"] = null;
            Session["User_Id"] = null;
            Session["User_Mail"] = null;
            Session["User_Password"] = null;
            Session["User_Type"] = null;

            return RedirectToAction("Home", "Home");
        }
    }
}
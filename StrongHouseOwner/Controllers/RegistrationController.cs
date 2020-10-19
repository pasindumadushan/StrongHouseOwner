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
    public class RegistrationController : Controller
    {
        UserRegistration userRegistration;
        StrongHouseDBEntities objEntity;
        RegistrationRepository registrationRepository;
        RegistrationServices registrationServices;

        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CheckUserMail(string userMail)
        {
            System.Threading.Thread.Sleep(200);
            var Result = objEntity.UserRegistrations.Where(x => x.UserMail == userMail).SingleOrDefault();
            if(Result != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }


        public ActionResult Registration()
        {
            int validation;
            registrationRepository = new RegistrationRepository();
            userRegistration = new UserRegistration();
            registrationServices = new RegistrationServices();

            userRegistration.UserName = Request.Form["User_Name"];
            userRegistration.UserMail = Request.Form["User_Mail"];
            userRegistration.UserAge= Convert.ToInt32(Request.Form["User_Age"]);
            userRegistration.UserAddress = Request.Form["User_Address"];
            userRegistration.UserPhoneNumber = Request.Form["User_Phone_Number"];
            userRegistration.UserType = Convert.ToInt32(Request.Form["User_Type"]);

            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(Request.Form["User_Password"]);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            var hashPassword = BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();

            userRegistration.UserPassword = hashPassword;

            var objResult = registrationServices.ExistUser(userRegistration);

            if (objResult != null)
            {
                validation = 1;
            }
            
            else
            {

                registrationRepository.RegistrationRP(userRegistration);
                validation = 0;

            }

            var result = new { validation };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
    }

}
using StrongHouseOwner.Data.EntityModel;
using StrongHouseOwner.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace StrongHouseOwner.Controllers
{
    public class ValidateUserController : Controller
    {
        RegistrationRepository registrationRepository;
        UserRegistration userRegistration;
        // GET: ValidateUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmailConfirm()
        {
            var validation = 0;
            registrationRepository = new RegistrationRepository();
            userRegistration = new UserRegistration();

            userRegistration.UserMail = Request.Form["User_Mail"];

            var objResult = registrationRepository.GetUserRegistration(userRegistration);
            
            if (objResult != null)
            {
                Random rnd = new Random();
                int code = rnd.Next(10000000, 99999999);

                MailMessage Mail = new MailMessage();
                MailAddress ma = new MailAddress("jefffranko7@gmail.com");
                Mail.From = ma;
                Mail.To.Add(objResult.UserMail);
                Mail.Subject = "Strong House Owner Recovery Code";
                string htmlString = @"<html>
                      <body>
                      <H2>Here's your new recovery code</H2>
                      <p>If you ever need a recovery access to your account, this code use for tempary password. We strongly recommended to update your password with new one.</p>
                      <p>If you previously had a recovery code, it is no longer valid. Use this new code instead</br></p>
                      <p>Your new code is <b>" + code+@"</b></p>  
                      <p>Thank you!</br></p>
                      </body>
                      </html>
                     ";

                Mail.Body = htmlString;
                Mail.IsBodyHtml = true;

                SmtpClient smtpMailObj = new SmtpClient();
                smtpMailObj.Host = "smtp.gmail.com";
                smtpMailObj.Credentials = new System.Net.NetworkCredential("jefffranko7@gmail.com", "0382291409");
                smtpMailObj.Port = 587;
                smtpMailObj.EnableSsl = true;
                smtpMailObj.Send(Mail);

                validation = 1;
                Session["recovery code"] = code;
            }
            else
            {
                validation = 0;
            }

            var result = new { validation};
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdatePassword(string userMail)
        {
            ViewBag.ViewBagUserMail = userMail;
            ViewBag.ViewBagRecoveryCode = Session["recovery code"];
            return View();
        }

        public ActionResult SavePassword()
        {
            var validation = 0;
            registrationRepository = new RegistrationRepository();

            var UserMail = Request.Form["User_Mail"];

            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(Request.Form["User_Password"]);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            var hashPassword = BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();

            var UserPassword = hashPassword;


            var objResult = registrationRepository.UpdatePassword(UserMail, UserPassword);

            if (objResult != null)
            {
                validation = 1;
            }
            else
            {
                validation = 0;
            }

            var result = new { validation };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
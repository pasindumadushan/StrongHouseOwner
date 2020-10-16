using Newtonsoft.Json;
using StrongHouseOwner.Data.EntityModel;
using StrongHouseOwner.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace StrongHouseOwner.Controllers
{
    public class HomeController : Controller
    {
        FlooringRepository flooringRepository;
        WallingRepository wallingRepository;
        CeilingRepository ceilingRepository;
        StrongHouseDBEntities objEntity;
        JavaScriptSerializer jss;
        // GET: Home
        public ActionResult Home()
        {

            return View();

        }

        public ActionResult LatestFlooring()
        {
            flooringRepository = new FlooringRepository();
            var objResult = flooringRepository.GetFlooringLatestListTypesRP();

            System.Diagnostics.Debug.WriteLine("Flooring - "+ objResult);


            string output = JsonConvert.SerializeObject(objResult, Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            return Json(output, JsonRequestBehavior.AllowGet);

        }

        public ActionResult LatestWalling()
        {
            jss = new JavaScriptSerializer();

            wallingRepository = new WallingRepository();
            var objResult = wallingRepository.GetWallingLatestListTypesRP();

            System.Diagnostics.Debug.WriteLine("Flooring - " + objResult);

            string output = JsonConvert.SerializeObject(objResult, Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(output, JsonRequestBehavior.AllowGet);

        }
        
        public ActionResult LatestCeiling()
        {
            jss = new JavaScriptSerializer();

            ceilingRepository = new CeilingRepository();
            var objResult = ceilingRepository.GetCeilingLatestListTypesRP();

            System.Diagnostics.Debug.WriteLine("Flooring - " + objResult);

            string output = JsonConvert.SerializeObject(objResult, Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(output, JsonRequestBehavior.AllowGet);

        }
    }
}
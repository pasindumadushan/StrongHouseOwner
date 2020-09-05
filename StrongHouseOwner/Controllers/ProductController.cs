using StrongHouseOwner.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrongHouseOwner.Controllers
{
    public class ProductController : Controller
    {
        FlooringRepository flooringRepository;
        WallingRepository wallingRepository;
        CeilingRepository ceilingRepository;
        // GET: Product
        public ActionResult Products()
        {
            return View();
        }


        public ActionResult ListOfFlooringTypes()
        {

            flooringRepository = new FlooringRepository();
            var objResult = flooringRepository.GetFlooringListTypesRP();

            return View(objResult);
        }
        
        public ActionResult ListOfWallingTypes()
        {

            wallingRepository = new WallingRepository();
            var objResult = wallingRepository.GetWallingListTypesRP();

            return View(objResult);
        }
        
        public ActionResult ListOfCeilingTypes()
        {

            ceilingRepository = new CeilingRepository();
            var objResult = ceilingRepository.GetCeilingListTypesRP();

            return View(objResult);
        }



        public ActionResult SamplesFlooring(int flooringTypeId)
        {

            flooringRepository = new FlooringRepository();
            var objResult = flooringRepository.SamplesListRP(flooringTypeId);

            ViewBag.ViewBagRefflooringTypeId = flooringTypeId;

            return View(objResult);
        }

        public ActionResult SamplesWalling(int wallingTypeId)
        {

            wallingRepository = new WallingRepository();
            var objResult = wallingRepository.SamplesListRP(wallingTypeId);

            ViewBag.ViewBagRefwallingTypeId = wallingTypeId;

            return View(objResult);
        }

        public ActionResult SamplesCeiling(int ceilingTypeId)
        {

            ceilingRepository = new CeilingRepository();
            var objResult = ceilingRepository.SamplesListRP(ceilingTypeId);

            ViewBag.ViewBagRefceilingTypeId = ceilingTypeId;

            return View(objResult);
        }



        public ActionResult SameSamplesFlooring(string flooringTypeSampleName, string flooringTypeSampleCode, int flooringTypeId)
        {

            flooringRepository = new FlooringRepository();
            var objResult = flooringRepository.SameSamplesRP(flooringTypeSampleName, flooringTypeSampleCode, flooringTypeId);

            var objResult2 = flooringRepository.GetFlooringTypeRP(flooringTypeId);


            ViewBag.ViewBagRefTypeOfFlooringRefId = flooringTypeId;
            ViewBag.ViewBagRefflooringTypeCategory = objResult2.FlooringTypeCategory;
            ViewBag.ViewBagRefflooringType = objResult2.FlooringType;
            ViewBag.ViewBagRefflooringTypeDetails = objResult2.FlooringTypeDetails;
            ViewBag.ViewBagRefflooringTypeBestUse = objResult2.FlooringTypeBestUse;
            ViewBag.ViewBagRefflooringTypeImage = objResult2.FlooringTypeImage;

            return View(objResult);
        }

        public ActionResult SameSamplesWalling(string wallingTypeSampleName, string wallingTypeSampleCode, int wallingTypeId)
        {

            wallingRepository = new WallingRepository();
            var objResult = wallingRepository.SameSamplesRP(wallingTypeSampleName, wallingTypeSampleCode, wallingTypeId);

            var objResult2 = wallingRepository.GetWallingTypeRP(wallingTypeId);


            ViewBag.ViewBagRefTypeOfWallingRefId = wallingTypeId;
            ViewBag.ViewBagRefwallingTypeCategory = objResult2.WallingTypeCategory;
            ViewBag.ViewBagRefwallingType = objResult2.WallingType;
            ViewBag.ViewBagRefwallingTypeDetails = objResult2.WallingTypeDetails;
            ViewBag.ViewBagRefwallingTypeBestUse = objResult2.WallingTypeBestUse;
            ViewBag.ViewBagRefwallingTypeImage = objResult2.WallingTypeImage;

            return View(objResult);
        }

        public ActionResult SameSamplesCeiling(string ceilingTypeSampleName, string ceilingTypeSampleCode, int ceilingTypeId)
        {

            ceilingRepository = new CeilingRepository();
            var objResult = ceilingRepository.SameSamplesRP(ceilingTypeSampleName, ceilingTypeSampleCode, ceilingTypeId);

            var objResult2 = ceilingRepository.GetCeilingTypeRP(ceilingTypeId);


            ViewBag.ViewBagRefTypeOfCeilingRefId = ceilingTypeId;
            ViewBag.ViewBagRefceilingTypeCategory = objResult2.CeilingTypeCategory;
            ViewBag.ViewBagRefceilingType = objResult2.CeilingType;
            ViewBag.ViewBagRefceilingTypeDetails = objResult2.CeilingTypeDetails;
            ViewBag.ViewBagRefceilingTypeBestUse = objResult2.CeilingTypeBestUse;
            ViewBag.ViewBagRefceilingTypeImage = objResult2.CeilingTypeImage;

            return View(objResult);
        }
    }
}
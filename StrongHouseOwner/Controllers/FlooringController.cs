using StrongHouseOwner.Data.EntityModel;
using StrongHouseOwner.Data.Repository;
using StrongHouseOwner.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrongHouseOwner.Controllers
{
    public class FlooringController : Controller
    {
        FlooringRepository flooringRepository;
        TypeOfFlooring objFlooringType;
        TypeOfFlooringSample objFlooringSample;
        SearchRepository searchRepository;

        // GET: CreateFlooring
        int validation;

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateSample(int refflooringTypeId)
        {

            ViewBag.ViewBagRefflooringTypeId = refflooringTypeId;

            return View();

        }

        [HttpPost]
        public ActionResult CreateFlooringType()
        {

            objFlooringType = new TypeOfFlooring();
            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            objFlooringType.FlooringTypeCategory = Request.Form["Flooring_Type_Category"];
            objFlooringType.FlooringType = Request.Form["Flooring_Type"];
            objFlooringType.FlooringTypeDetails = Request.Form["Flooring_Type_Details"];
            objFlooringType.FlooringTypeAdvantage = Request.Form["Flooring_Type_Advantage"];
            objFlooringType.FlooringTypeDisadvantage = Request.Form["Flooring_Type_Disadvantage"];
            objFlooringType.FlooringTypeBestUse = Request.Form["Flooring_Type_BestUse"];
            objFlooringType.FlooringTypeReinstall = Request.Form["Flooring_Type_Reinstall"];

            if (ImageFile != null)
            {
                //var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                var fileName = objFlooringType.FlooringTypeCategory + "-" + objFlooringType.FlooringType +  extension;
                objFlooringType.FlooringTypeImage = "~/Images/FlooringTypeImages/" + fileName;

                ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/FlooringTypeImages/" + fileName));
            }



            flooringRepository = new FlooringRepository();
            var objResult = flooringRepository.ExistFlooringTypeRP(objFlooringType);

            if (objResult != null)
            {

                validation = 1;

            }
            else
            {

                validation = 0;
                flooringRepository.SaveFlooringTypeRP(objFlooringType);

            }

            var result = new { validation };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult CreateSampleSubmit()
        {
            
            objFlooringSample = new TypeOfFlooringSample();

            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            objFlooringSample.TypeOfFlooringRefId = Convert.ToInt32(Request.Form["Ref_Flooring_Type_Id"]); 
            objFlooringSample.FlooringTypeSampleCode = Request.Form["Flooring_Type_Sample_Code"];
            objFlooringSample.FlooringTypeSampleName= Request.Form["Flooring_Type_Sample_Name"];
            objFlooringSample.FlooringTypeSampleSizeHeight = Convert.ToInt32(Request.Form["Flooring_Type_Sample_Height"]);
            objFlooringSample.FlooringTypeSampleSizeWidth = Convert.ToInt32(Request.Form["Flooring_Type_Sample_Width"]);
            objFlooringSample.FlooringTypeSamplePrice = Convert.ToDecimal(Request.Form["Flooring_Type_Sample_Price"]);
            
            flooringRepository = new FlooringRepository();
            var objResult = flooringRepository.ExistSampleRP(objFlooringSample);

            if (objResult != null)
            {

                validation = 1;

            }
            else
            {

                validation = 0;
                var flooringTypeSampleId = flooringRepository.SaveSampleRP(objFlooringSample).FlooringTypeSampleId;

                if (ImageFile != null)
                {

                    string extension = Path.GetExtension(ImageFile.FileName);
                    var fileName = flooringTypeSampleId + "-" + objFlooringSample.TypeOfFlooringRefId + extension;
                    objFlooringSample.FlooringTypeSampleImagePath = "~/Images/FlooringSampleImages/" + fileName;

                    ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/FlooringSampleImages/" + fileName));

                    flooringRepository.EditSampleRP(objFlooringSample);
                }

            }

            var result = new { validation, objFlooringSample.TypeOfFlooringRefId };
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        public ActionResult ListOfFlooringTypes(string SearchBy, string SearchValue)
        {
            searchRepository = new SearchRepository();
            flooringRepository = new FlooringRepository();
            List<TypeOfFlooring> objResult = new List<TypeOfFlooring>();

            if (Convert.ToInt32(Session["User_Type"]) == 1 || Convert.ToInt32(Session["User_Type"]) == 3)
            {

                if (SearchValue != null)
                {
                    objResult = searchRepository.GetFlooringListTypesSearchRP(SearchBy, SearchValue);
                }
                else
                {
                    objResult = flooringRepository.GetFlooringListTypesRP();
                }

                return View(objResult);
            }
            else
            {
                return RedirectToAction("UserProfile", "Customer");
            }

            
        }

        public ActionResult Samples(int flooringTypeId, string SearchBy, string SearchValue)
        {

            flooringRepository = new FlooringRepository();
            searchRepository = new SearchRepository();
            List<TypeOfFlooringSample> objResult = new List<TypeOfFlooringSample>();
            if (SearchValue != null)
            {
                objResult = searchRepository.SamplesFlooringListSearchRP(flooringTypeId, SearchBy, SearchValue);
            }
            else
            {
                objResult = flooringRepository.SamplesListRP(flooringTypeId);
            }
            ViewBag.ViewBagRefflooringTypeId = flooringTypeId;

            return View(objResult);
        }

        [HttpGet]
        public ActionResult Edit(int flooringTypeId)
        {

            flooringRepository = new FlooringRepository();

            var objResult = flooringRepository.GetFlooringTypeRP(flooringTypeId);
            var objResultList = flooringRepository.GetFlooringListTypesRP();

            

            ViewBag.flooringTypeId = objResult.FlooringTypeId;
            ViewBag.flooringTypeCategory = objResult.FlooringTypeCategory;
            ViewBag.flooringType = objResult.FlooringType;
            ViewBag.flooringTypeDetails = objResult.FlooringTypeDetails;
            ViewBag.flooringTypeAdvantage = objResult.FlooringTypeAdvantage;
            ViewBag.flooringTypeDisadvantage = objResult.FlooringTypeDisadvantage;
            ViewBag.flooringTypeBestUse = objResult.FlooringTypeBestUse;
            ViewBag.flooringTypeReinstall = objResult.FlooringTypeReinstall;
            

            if(objResult.FlooringTypeImage != null)
            {
                ViewBag.flooringTypeImage = objResult.FlooringTypeImage;
                System.Diagnostics.Debug.WriteLine(objResult.FlooringTypeImage);
            }
            else
            {
                ViewBag.flooringTypeImage = "~/Images/No Image Available.jpg";
                System.Diagnostics.Debug.WriteLine(objResult.FlooringTypeImage);
            }

            System.Diagnostics.Debug.WriteLine(objResult.FlooringTypeImage + objResult.FlooringTypeCategory);
            return View(objResultList);

        }

        [HttpPost]
        public ActionResult EditFlooringType()
        {

            objFlooringType = new TypeOfFlooring();
            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            objFlooringType.FlooringTypeId = Convert.ToInt32(Request.Form["flooring_Type_Id"]);
            objFlooringType.FlooringTypeCategory = Request.Form["flooring_Type_Category"];
            objFlooringType.FlooringType = Request.Form["flooring_Type"];
            objFlooringType.FlooringTypeDetails = Request.Form["flooring_Type_Details"];
            objFlooringType.FlooringTypeAdvantage = Request.Form["Flooring_Type_Advantage"];
            objFlooringType.FlooringTypeDisadvantage = Request.Form["Flooring_Type_Disadvantage"];
            objFlooringType.FlooringTypeBestUse = Request.Form["Flooring_Type_BestUse"];
            objFlooringType.FlooringTypeReinstall = Request.Form["Flooring_Type_Reinstall"];

            if (ImageFile != null)
            {
                //var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                var fileName = objFlooringType.FlooringTypeCategory + "-" + objFlooringType.FlooringType + extension;
                objFlooringType.FlooringTypeImage = "~/Images/FlooringTypeImages/" + fileName;

                ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/FlooringTypeImages/" + fileName));
            }

            flooringRepository = new FlooringRepository();
            var objEntity = flooringRepository.EditFlooringTypeRP(objFlooringType);

            return Json(objEntity);

        }

        [HttpGet]
        public ActionResult Delete(int flooringTypeId)
        {

            flooringRepository = new FlooringRepository();

            var objResult = flooringRepository.GetFlooringTypeRP(flooringTypeId);
            var objResultList = flooringRepository.GetFlooringListTypesRP();

            ViewBag.ViewBagRefflooringTypeId = flooringTypeId;
            ViewBag.flooringTypeId = objResult.FlooringTypeId;
            ViewBag.flooringTypeCategory = objResult.FlooringTypeCategory;
            ViewBag.flooringType = objResult.FlooringType;
            ViewBag.flooringTypeDetails = objResult.FlooringTypeDetails;
            ViewBag.flooringTypeAdvantage = objResult.FlooringTypeAdvantage;
            ViewBag.flooringTypeDisadvantage = objResult.FlooringTypeDisadvantage;
            ViewBag.flooringTypeBestUse = objResult.FlooringTypeBestUse;
            ViewBag.flooringTypeReinstall = objResult.FlooringTypeReinstall;


            return View(objResultList);

        }

        [HttpGet]
        public ActionResult DeleteSample(int flooringSampleId, int flooringTypeId)
        {

            flooringRepository = new FlooringRepository();

            var objResult = flooringRepository.SamplesRP(flooringSampleId);
            var objResultList = flooringRepository.SamplesListRP(flooringTypeId);

            ViewBag.ViewBagRefflooringTypeId = flooringTypeId;
            ViewBag.flooringTypeSampleId = objResult.FlooringTypeSampleId;
            ViewBag.ShopRefId = objResult.ShopRefId;
            ViewBag.flooringTypeSampleCode = objResult.FlooringTypeSampleCode;
            ViewBag.flooringTypeSampleName = objResult.FlooringTypeSampleName;

            return View(objResultList);

        }

        [HttpPost]
        public ActionResult DeleteFlooringType()
        {

            objFlooringType = new TypeOfFlooring();

            objFlooringType.FlooringTypeId = Convert.ToInt32(Request.Form["flooring_Type_Id"]);
            objFlooringType.FlooringTypeCategory = Request.Form["flooring_Type_Category"];
            objFlooringType.FlooringType = Request.Form["flooring_Type"];
            objFlooringType.FlooringTypeDetails = Request.Form["flooring_Type_Details"];
            objFlooringType.FlooringTypeAdvantage = Request.Form["Flooring_Type_Advantage"];
            objFlooringType.FlooringTypeDisadvantage = Request.Form["Flooring_Type_Disadvantage"];
            objFlooringType.FlooringTypeBestUse = Request.Form["Flooring_Type_BestUse"];
            objFlooringType.FlooringTypeReinstall = Request.Form["Flooring_Type_Reinstall"];

            flooringRepository = new FlooringRepository();
            var objEntity = flooringRepository.DeleteFlooringTypeRP(objFlooringType);

            return Json(new { success = objEntity.FlooringTypeId }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult DeleteSampleConfirm()
        {

            objFlooringSample = new TypeOfFlooringSample();
            objFlooringSample.FlooringTypeSampleId = Convert.ToInt32(Request.Form["flooring_Type_Sample_Id"]);
            objFlooringSample.FlooringTypeSampleCode = Request.Form["flooring_Type_Sample_Code"];
            objFlooringSample.FlooringTypeSampleName = Request.Form["flooring_Type_Sample_Name"];

            if(Request.Form["Shop_Ref_Id"] != null)
            {

            }
            else
            {
                objFlooringSample.ShopRefId = Convert.ToInt32(Request.Form["Shop_Ref_Id"]);

            }

            flooringRepository = new FlooringRepository();
            var objEntity = flooringRepository.DeleteSampleRP(objFlooringSample);

            return Json(new { success = objEntity.FlooringTypeSampleId }, JsonRequestBehavior.AllowGet);

        }


    }
}
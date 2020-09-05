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
    public class CeilingController : Controller
    {
        CeilingRepository CeilingRepository;
        TypeOfCeiling objCeilingType;
        TypeOfCeilingSample objCeilingSample;
        // GET: CreateCeiling
        int validation;

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateSample(int refCeilingTypeId)
        {

            ViewBag.ViewBagRefCeilingTypeId = refCeilingTypeId;

            return View();

        }

        [HttpPost]
        public ActionResult CreateCeilingType()
        {

            objCeilingType = new TypeOfCeiling();
            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            objCeilingType.CeilingTypeCategory = Request.Form["Ceiling_Type_Category"];
            objCeilingType.CeilingType = Request.Form["Ceiling_Type"];
            objCeilingType.CeilingTypeDetails = Request.Form["Ceiling_Type_Details"];
            objCeilingType.CeilingTypeAdvantage = Request.Form["Ceiling_Type_Advantage"];
            objCeilingType.CeilingTypeDisadvantage = Request.Form["Ceiling_Type_Disadvantage"];
            objCeilingType.CeilingTypeBestUse = Request.Form["Ceiling_Type_BestUse"];
            objCeilingType.CeilingTypeReinstall = Request.Form["Ceiling_Type_Reinstall"];

            if (ImageFile != null)
            {
                //var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                var fileName = objCeilingType.CeilingTypeCategory + "-" + objCeilingType.CeilingType + extension;
                objCeilingType.CeilingTypeImage = "~/Images/CeilingTypeImages/" + fileName;

                ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/CeilingTypeImages/" + fileName));
            }


            CeilingRepository = new CeilingRepository();
            var objResult = CeilingRepository.ExistCeilingTypeRP(objCeilingType);

            if (objResult != null)
            {

                validation = 1;

            }
            else
            {

                validation = 0;
                CeilingRepository.SaveCeilingTypeRP(objCeilingType);

            }

            var result = new { validation };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult CreateSampleSubmit()
        {
            
            objCeilingSample = new TypeOfCeilingSample();

            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            objCeilingSample.TypeOfCeilingRefId = Convert.ToInt32(Request.Form["Ref_Ceiling_Type_Id"]); 
            objCeilingSample.CeilingTypeSampleCode = Request.Form["Ceiling_Type_Sample_Code"];
            objCeilingSample.CeilingTypeSampleName= Request.Form["Ceiling_Type_Sample_Name"];
            objCeilingSample.CeilingTypeSampleSizeHeight = Convert.ToInt32(Request.Form["Ceiling_Type_Sample_Height"]);
            objCeilingSample.CeilingTypeSampleSizeWidth = Convert.ToInt32(Request.Form["Ceiling_Type_Sample_Width"]);
            objCeilingSample.CeilingTypeSamplePrice = Convert.ToDecimal(Request.Form["Ceiling_Type_Sample_Price"]);
            
            CeilingRepository = new CeilingRepository();
            var objResult = CeilingRepository.ExistSampleRP(objCeilingSample);

            if (objResult != null)
            {

                validation = 1;

            }
            else
            {

                validation = 0;
                var ceilingTypeSampleId = CeilingRepository.SaveSampleRP(objCeilingSample).CeilingTypeSampleId;

                if (ImageFile != null)
                {

                    string extension = Path.GetExtension(ImageFile.FileName);
                    var fileName = ceilingTypeSampleId + "-" + objCeilingSample.TypeOfCeilingRefId + extension;
                    objCeilingSample.CeilingTypeSampleImagePath = "~/Images/CeilingSampleImages/" + fileName;

                    ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/CeilingSampleImages/" + fileName));

                    CeilingRepository.EditSampleRP(objCeilingSample);
                }

            }

            var result = new { validation, objCeilingSample.TypeOfCeilingRefId };
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        public ActionResult ListOfCeilingTypes()
        {

            CeilingRepository = new CeilingRepository();
            var objResult = CeilingRepository.GetCeilingListTypesRP();

            return View(objResult);
        }

        public ActionResult Samples(int CeilingTypeId)
        {

            CeilingRepository = new CeilingRepository();
            var objResult = CeilingRepository.SamplesListRP(CeilingTypeId);

            ViewBag.ViewBagRefCeilingTypeId = CeilingTypeId;

            return View(objResult);
        }

        [HttpGet]
        public ActionResult Edit(int CeilingTypeId)
        {

            CeilingRepository = new CeilingRepository();

            var objResult = CeilingRepository.GetCeilingTypeRP(CeilingTypeId);
            var objResultList = CeilingRepository.GetCeilingListTypesRP();

            ViewBag.CeilingTypeId = objResult.CeilingTypeId;
            ViewBag.CeilingTypeCategory = objResult.CeilingTypeCategory;
            ViewBag.CeilingType = objResult.CeilingType;
            ViewBag.CeilingTypeDetails = objResult.CeilingTypeDetails;
            ViewBag.CeilingTypeAdvantage = objResult.CeilingTypeAdvantage;
            ViewBag.CeilingTypeDisadvantage = objResult.CeilingTypeDisadvantage;
            ViewBag.CeilingTypeBestUse = objResult.CeilingTypeBestUse;
            ViewBag.CeilingTypeReinstall = objResult.CeilingTypeReinstall;

            if (objResult.CeilingTypeImage != null)
            {
                ViewBag.CeilingTypeImage = objResult.CeilingTypeImage;
                System.Diagnostics.Debug.WriteLine(objResult.CeilingTypeImage);
            }
            else
            {
                ViewBag.CeilingTypeImage = "~/Images/No Image Available.jpg";
                System.Diagnostics.Debug.WriteLine(objResult.CeilingTypeImage);
            }

            return View(objResultList);

        }

        [HttpPost]
        public ActionResult EditCeilingType()
        {

            objCeilingType = new TypeOfCeiling();
            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            objCeilingType.CeilingTypeId = Convert.ToInt32(Request.Form["Ceiling_Type_Id"]);
            objCeilingType.CeilingTypeCategory = Request.Form["Ceiling_Type_Category"];
            objCeilingType.CeilingType = Request.Form["Ceiling_Type"];
            objCeilingType.CeilingTypeDetails = Request.Form["Ceiling_Type_Details"];
            objCeilingType.CeilingTypeAdvantage = Request.Form["Ceiling_Type_Advantage"];
            objCeilingType.CeilingTypeDisadvantage = Request.Form["Ceiling_Type_Disadvantage"];
            objCeilingType.CeilingTypeBestUse = Request.Form["Ceiling_Type_BestUse"];
            objCeilingType.CeilingTypeReinstall = Request.Form["Ceiling_Type_Reinstall"];

            if (ImageFile != null)
            {
                //var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                var fileName = objCeilingType.CeilingTypeCategory + "-" + objCeilingType.CeilingType + extension;
                objCeilingType.CeilingTypeImage = "~/Images/CeilingTypeImages/" + fileName;

                ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/CeilingTypeImages/" + fileName));
            }

            CeilingRepository = new CeilingRepository();
            var objEntity = CeilingRepository.EditCeilingTypeRP(objCeilingType);

            return Json(objEntity);

        }

        [HttpGet]
        public ActionResult Delete(int CeilingTypeId)
        {

            CeilingRepository = new CeilingRepository();

            var objResult = CeilingRepository.GetCeilingTypeRP(CeilingTypeId);
            var objResultList = CeilingRepository.GetCeilingListTypesRP();

            ViewBag.ViewBagRefCeilingTypeId = CeilingTypeId;
            ViewBag.CeilingTypeId = objResult.CeilingTypeId;
            ViewBag.CeilingTypeCategory = objResult.CeilingTypeCategory;
            ViewBag.CeilingType = objResult.CeilingType;
            ViewBag.CeilingTypeDetails = objResult.CeilingTypeDetails;
            ViewBag.CeilingTypeAdvantage = objResult.CeilingTypeAdvantage;
            ViewBag.CeilingTypeDisadvantage = objResult.CeilingTypeDisadvantage;
            ViewBag.CeilingTypeBestUse = objResult.CeilingTypeBestUse;
            ViewBag.CeilingTypeReinstall = objResult.CeilingTypeReinstall;

            return View(objResultList);

        }

        [HttpGet]
        public ActionResult DeleteSample(int CeilingSampleId, int CeilingTypeId)
        {

            CeilingRepository = new CeilingRepository();

            var objResult = CeilingRepository.SamplesRP(CeilingSampleId);
            var objResultList = CeilingRepository.SamplesListRP(CeilingTypeId);

            ViewBag.ViewBagRefCeilingTypeId = CeilingTypeId;
            ViewBag.CeilingTypeSampleId = objResult.CeilingTypeSampleId;
            ViewBag.ShopRefId = objResult.ShopRefId;
            ViewBag.CeilingTypeSampleCode = objResult.CeilingTypeSampleCode;
            ViewBag.CeilingTypeSampleName = objResult.CeilingTypeSampleName;

            return View(objResultList);

        }

        [HttpPost]
        public ActionResult DeleteCeilingType()
        {

            objCeilingType = new TypeOfCeiling();

            objCeilingType.CeilingTypeId = Convert.ToInt32(Request.Form["Ceiling_Type_Id"]);
            objCeilingType.CeilingTypeCategory = Request.Form["Ceiling_Type_Category"];
            objCeilingType.CeilingType = Request.Form["Ceiling_Type"];
            objCeilingType.CeilingTypeDetails = Request.Form["Ceiling_Type_Details"];
            objCeilingType.CeilingTypeAdvantage = Request.Form["Ceiling_Type_Advantage"];
            objCeilingType.CeilingTypeDisadvantage = Request.Form["Ceiling_Type_Disadvantage"];
            objCeilingType.CeilingTypeBestUse = Request.Form["Ceiling_Type_BestUse"];
            objCeilingType.CeilingTypeReinstall = Request.Form["Ceiling_Type_Reinstall"];

            CeilingRepository = new CeilingRepository();
            var objEntity = CeilingRepository.DeleteCeilingTypeRP(objCeilingType);

            return Json(new { success = objEntity.CeilingTypeId }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult DeleteSampleConfirm()
        {

            objCeilingSample = new TypeOfCeilingSample();
            objCeilingSample.CeilingTypeSampleId = Convert.ToInt32(Request.Form["Ceiling_Type_Sample_Id"]);
            objCeilingSample.CeilingTypeSampleCode = Request.Form["Ceiling_Type_Sample_Code"];
            objCeilingSample.CeilingTypeSampleName = Request.Form["Ceiling_Type_Sample_Name"];

            if(Request.Form["Shop_Ref_Id"] != null)
            {

            }
            else
            {
                objCeilingSample.ShopRefId = Convert.ToInt32(Request.Form["Shop_Ref_Id"]);

            }

            CeilingRepository = new CeilingRepository();
            var objEntity = CeilingRepository.DeleteSampleRP(objCeilingSample);

            return Json(new { success = objEntity.CeilingTypeSampleId }, JsonRequestBehavior.AllowGet);

        }


    }
}
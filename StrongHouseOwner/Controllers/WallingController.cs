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
    public class WallingController : Controller
    {
        WallingRepository WallingRepository;
        TypeOfWalling objWallingType;
        TypeOfWallingSample objWallingSample;
        // GET: CreateWalling
        int validation;

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateSample(int refWallingTypeId)
        {

            ViewBag.ViewBagRefWallingTypeId = refWallingTypeId;

            return View();

        }

        [HttpPost]
        public ActionResult CreateWallingType()
        {

            objWallingType = new TypeOfWalling();
            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            objWallingType.WallingTypeCategory = Request.Form["Walling_Type_Category"];
            objWallingType.WallingType = Request.Form["Walling_Type"];
            objWallingType.WallingTypeDetails = Request.Form["Walling_Type_Details"];
            objWallingType.WallingTypeAdvantage = Request.Form["Walling_Type_Advantage"];
            objWallingType.WallingTypeDisadvantage = Request.Form["Walling_Type_Disadvantage"];
            objWallingType.WallingTypeBestUse = Request.Form["Walling_Type_BestUse"];
            objWallingType.WallingTypeReinstall = Request.Form["Walling_Type_Reinstall"];


            if (ImageFile != null)
            {
                //var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                var fileName = objWallingType.WallingTypeCategory + "-" + objWallingType.WallingType + extension;
                objWallingType.WallingTypeImage = "~/Images/WallingTypeImages/" + fileName;

                ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/WallingTypeImages/" + fileName));
            }


            WallingRepository = new WallingRepository();
            var objResult = WallingRepository.ExistWallingTypeRP(objWallingType);

            if (objResult != null)
            {

                validation = 1;

            }
            else
            {

                validation = 0;
                WallingRepository.SaveWallingTypeRP(objWallingType);

            }

            var result = new { validation };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult CreateSampleSubmit()
        {
            
            objWallingSample = new TypeOfWallingSample();
            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            var PaintOrTile = Convert.ToBoolean(Request.Form["Paint_Or_Tile"]);

            if(PaintOrTile == true)
            {

                objWallingSample.WallingTypeBrand = Request.Form["Walling_Type_Brand"];
                objWallingSample.WallingMilliliters = Convert.ToInt32(Request.Form["Walling_Milliliters"]);

            }
            else
            {
                objWallingSample.WallingTypeSampleSizeHeight = Convert.ToInt32(Request.Form["Walling_Type_Sample_Height"]);
                objWallingSample.WallingTypeSampleSizeWidth = Convert.ToInt32(Request.Form["Walling_Type_Sample_Width"]);

            }

            objWallingSample.TypeOfWallingRefId = Convert.ToInt32(Request.Form["Ref_Walling_Type_Id"]);
            objWallingSample.WallingTypeSampleCode = Request.Form["Walling_Type_Sample_Code"];
            objWallingSample.WallingTypeSampleName= Request.Form["Walling_Type_Sample_Name"];
            objWallingSample.WallingTypeSamplePrice = Convert.ToDecimal(Request.Form["Walling_Type_Sample_Price"]);
            
            WallingRepository = new WallingRepository();
            var objResult = WallingRepository.ExistSampleRP(objWallingSample, PaintOrTile);

            if (objResult != null)
            {

                validation = 1;

            }
            else
            {

                validation = 0;
                int wallingTypeSampleId = WallingRepository.SaveSampleRP(objWallingSample).WallingTypeSampleId;

                if (ImageFile != null)
                {

                    string extension = Path.GetExtension(ImageFile.FileName);
                    var fileName = wallingTypeSampleId + "-" + objWallingSample.TypeOfWallingRefId + extension;
                    objWallingSample.WallingTypeSampleImagePath = "~/Images/WallingSampleImages/" + fileName;

                    ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/WallingSampleImages/" + fileName));

                    WallingRepository.EditSampleRP(objWallingSample);
                }

            }

            var result = new { validation, objWallingSample.TypeOfWallingRefId };
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        public ActionResult ListOfWallingTypes()
        {

            WallingRepository = new WallingRepository();
            var objResult = WallingRepository.GetWallingListTypesRP();

            return View(objResult);
        }

        public ActionResult Samples(int WallingTypeId)
        {

            WallingRepository = new WallingRepository();
            var objResult = WallingRepository.SamplesListRP(WallingTypeId);

            ViewBag.ViewBagRefWallingTypeId = WallingTypeId;

            return View(objResult);
        }

        [HttpGet]
        public ActionResult Edit(int WallingTypeId)
        {

            WallingRepository = new WallingRepository();

            var objResult = WallingRepository.GetWallingTypeRP(WallingTypeId);
            var objResultList = WallingRepository.GetWallingListTypesRP();

            ViewBag.WallingTypeId = objResult.WallingTypeId;
            ViewBag.WallingTypeCategory = objResult.WallingTypeCategory;
            ViewBag.WallingType = objResult.WallingType;
            ViewBag.WallingTypeDetails = objResult.WallingTypeDetails;
            ViewBag.WallingTypeAdvantage = objResult.WallingTypeAdvantage;
            ViewBag.WallingTypeDisadvantage = objResult.WallingTypeDisadvantage;
            ViewBag.WallingTypeBestUse = objResult.WallingTypeBestUse;
            ViewBag.WallingTypeReinstall = objResult.WallingTypeReinstall;

            if (objResult.WallingTypeImage != null)
            {
                ViewBag.WallingTypeImage = objResult.WallingTypeImage;
                System.Diagnostics.Debug.WriteLine(objResult.WallingTypeImage);
            }
            else
            {
                ViewBag.WallingTypeImage = "~/Images/No Image Available.jpg";
                System.Diagnostics.Debug.WriteLine(objResult.WallingTypeImage);
            }

            return View(objResultList);

        }

        [HttpPost]
        public ActionResult EditWallingType()
        {

            objWallingType = new TypeOfWalling();
            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            objWallingType.WallingTypeId = Convert.ToInt32(Request.Form["Walling_Type_Id"]);
            objWallingType.WallingTypeCategory = Request.Form["Walling_Type_Category"];
            objWallingType.WallingType = Request.Form["Walling_Type"];
            objWallingType.WallingTypeDetails = Request.Form["Walling_Type_Details"];
            objWallingType.WallingTypeAdvantage = Request.Form["Walling_Type_Advantage"];
            objWallingType.WallingTypeDisadvantage = Request.Form["Walling_Type_Disadvantage"];
            objWallingType.WallingTypeBestUse = Request.Form["Walling_Type_BestUse"];
            objWallingType.WallingTypeReinstall = Request.Form["Walling_Type_Reinstall"];

            if (ImageFile != null)
            {
                //var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                var fileName = objWallingType.WallingTypeCategory + "-" + objWallingType.WallingType + extension;
                objWallingType.WallingTypeImage = "~/Images/WallingTypeImages/" + fileName;

                ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/WallingTypeImages/" + fileName));
            }

            WallingRepository = new WallingRepository();
            var objEntity = WallingRepository.EditWallingTypeRP(objWallingType);

            return Json(objEntity);

        }

        [HttpGet]
        public ActionResult Delete(int WallingTypeId)
        {

            WallingRepository = new WallingRepository();

            var objResult = WallingRepository.GetWallingTypeRP(WallingTypeId);
            var objResultList = WallingRepository.GetWallingListTypesRP();

            ViewBag.ViewBagRefWallingTypeId = WallingTypeId;
            ViewBag.WallingTypeId = objResult.WallingTypeId;
            ViewBag.WallingTypeCategory = objResult.WallingTypeCategory;
            ViewBag.WallingType = objResult.WallingType;
            ViewBag.WallingTypeDetails = objResult.WallingTypeDetails;
            ViewBag.WallingTypeAdvantage = objResult.WallingTypeAdvantage;
            ViewBag.WallingTypeDisadvantage = objResult.WallingTypeDisadvantage;
            ViewBag.WallingTypeBestUse = objResult.WallingTypeBestUse;
            ViewBag.WallingTypeReinstall = objResult.WallingTypeReinstall;

            return View(objResultList);

        }

        [HttpGet]
        public ActionResult DeleteSample(int WallingSampleId, int WallingTypeId)
        {

            WallingRepository = new WallingRepository();

            var objResult = WallingRepository.SamplesRP(WallingSampleId);
            var objResultList = WallingRepository.SamplesListRP(WallingTypeId);

            ViewBag.ViewBagRefWallingTypeId = WallingTypeId;
            ViewBag.WallingTypeSampleId = objResult.WallingTypeSampleId;
            ViewBag.ShopRefId = objResult.ShopRefId;
            ViewBag.WallingTypeSampleCode = objResult.WallingTypeSampleCode;
            ViewBag.WallingTypeSampleName = objResult.WallingTypeSampleName;

            return View(objResultList);

        }

        [HttpPost]
        public ActionResult DeleteWallingType()
        {

            objWallingType = new TypeOfWalling();

            objWallingType.WallingTypeId = Convert.ToInt32(Request.Form["Walling_Type_Id"]);
            objWallingType.WallingTypeCategory = Request.Form["Walling_Type_Category"];
            objWallingType.WallingType = Request.Form["Walling_Type"];
            objWallingType.WallingTypeDetails = Request.Form["Walling_Type_Details"];
            objWallingType.WallingTypeAdvantage = Request.Form["Walling_Type_Advantage"];
            objWallingType.WallingTypeDisadvantage = Request.Form["Walling_Type_Disadvantage"];
            objWallingType.WallingTypeBestUse = Request.Form["Walling_Type_BestUse"];
            objWallingType.WallingTypeReinstall = Request.Form["Walling_Type_Reinstall"];

            WallingRepository = new WallingRepository();
            var objEntity = WallingRepository.DeleteWallingTypeRP(objWallingType);

            return Json(new { success = objEntity.WallingTypeId }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult DeleteSampleConfirm()
        {

            objWallingSample = new TypeOfWallingSample();
            objWallingSample.WallingTypeSampleId = Convert.ToInt32(Request.Form["Walling_Type_Sample_Id"]);
            objWallingSample.WallingTypeSampleCode = Request.Form["Walling_Type_Sample_Code"];
            objWallingSample.WallingTypeSampleName = Request.Form["Walling_Type_Sample_Name"];

            if(Request.Form["Shop_Ref_Id"] != null)
            {

            }
            else
            {
                objWallingSample.ShopRefId = Convert.ToInt32(Request.Form["Shop_Ref_Id"]);

            }

            WallingRepository = new WallingRepository();
            var objEntity = WallingRepository.DeleteSampleRP(objWallingSample);

            return Json(new { success = objEntity.WallingTypeSampleId }, JsonRequestBehavior.AllowGet);

        }


    }
}
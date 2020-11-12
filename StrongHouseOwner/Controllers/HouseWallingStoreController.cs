using StrongHouseOwner.Data.EntityModel;
using StrongHouseOwner.Data.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrongHouseOwner.Controllers
{
    public class HouseWallingStoreController : Controller
    {
        HouseWallingStoreRepository houseWallingStoreRepository;
        WallingRepository wallingRepository;
        StoredWalling storedWalling;
        SearchRepository searchRepository;

        // GET: HouseFloorStore
        public ActionResult Index(int houseId, string SearchBy, string SearchValue)
        {
            houseWallingStoreRepository = new HouseWallingStoreRepository();
            ViewBag.ViewBagHouseRefId = houseId;
            searchRepository = new SearchRepository();
            List<StoredWalling> objResult = new List<StoredWalling>();

            if (SearchValue != null)
            {
                objResult = searchRepository.GetHouseStoredWallingListSearchRP(houseId, SearchBy, SearchValue);
            }
            else
            {
                objResult = houseWallingStoreRepository.GetHouseStoredWallingListRP(houseId);
            }

            return View(objResult);
        }

        public ActionResult Create(int houseId)
        {

            wallingRepository = new WallingRepository();
            ViewBag.ViewBagHouseRefId = Convert.ToInt32(houseId);

            var objResult = wallingRepository.GetWallingListTypesRP();

            return View(objResult);
        }

        [HttpPost]
        public ActionResult CreateHouseWalling()
        {
            storedWalling = new StoredWalling();
            houseWallingStoreRepository = new HouseWallingStoreRepository();
            var validation = 0;
            var storedWallingId = 0;

            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            storedWalling.HouseRefId = Convert.ToInt32(Request.Form["House_Ref_Id"]);
            storedWalling.StoredTypeOfWallingRefId = Convert.ToInt32(Request.Form["Stored_Type_Of_Walling_Ref_Id"]);
            storedWalling.WallingCategory = Request.Form["Walling_Category"];
            storedWalling.WallingType = Request.Form["Walling_Type"];
            storedWalling.WallingName = Request.Form["Walling_Name"];
            storedWalling.TypeOfPartition = Request.Form["Type_Of_Partition"];
            storedWalling.WallingArea = Convert.ToDecimal(Request.Form["Walling_Area"]);


            var editStoredWalling = houseWallingStoreRepository.SaveStoredWallingRP(storedWalling);
            //need to get house id. only way is save record in table then get house id

            if (editStoredWalling != null)
            {
                if (ImageFile != null)
                {

                    string extension = Path.GetExtension(ImageFile.FileName);
                    var fileName = editStoredWalling.WallingId + "-" + editStoredWalling.HouseRefId + extension;
                    editStoredWalling.SampleImagePath = "~/Images/Store/Walling/" + fileName;

                    ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/Store/Walling/" + fileName));

                }
                houseWallingStoreRepository.EditStoredWallingRP(editStoredWalling);

                storedWallingId = editStoredWalling.WallingId;
                validation = 1;
            }
            else
            {
                validation = 0;
            }

            var result = new { validation, storedWallingId };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateUpdate(int storedWallingId)
        {
            houseWallingStoreRepository = new HouseWallingStoreRepository();
            var objResult = houseWallingStoreRepository.GetStoredWalling(storedWallingId);
            List<TypeOfWallingSample> objListResult = null;

            ViewBag.ViewBagTypeOfWallingRefId = objResult.StoredTypeOfWallingRefId;
            ViewBag.ViewBagWallingArea = objResult.WallingArea;
            ViewBag.ViewBagStoredWallingId = storedWallingId;
            ViewBag.ViewBagHouseRefId = Convert.ToInt32(objResult.HouseRefId);

            if (objResult != null)
            {
                wallingRepository = new WallingRepository();
                objListResult = wallingRepository.SamplesListRP(Convert.ToInt32(objResult.StoredTypeOfWallingRefId));
            }

            return View(objListResult);
        }

        [HttpPost]
        public ActionResult UpdateHouseWalling()
        {
            houseWallingStoreRepository = new HouseWallingStoreRepository();
            storedWalling = new StoredWalling();
            wallingRepository = new WallingRepository();
            var validation = 0;

            var objEntity = houseWallingStoreRepository.GetStoredWalling(Convert.ToInt32(Request.Form["Walling_Id"]));
            storedWalling.WallingId = objEntity.WallingId;
            storedWalling.HouseRefId = objEntity.HouseRefId;
            storedWalling.StoredTypeOfWallingRefId = objEntity.StoredTypeOfWallingRefId;
            storedWalling.WallingCategory = objEntity.WallingCategory;
            storedWalling.WallingType = objEntity.WallingType;
            storedWalling.WallingName = objEntity.WallingName;
            storedWalling.TypeOfPartition = objEntity.TypeOfPartition;
            storedWalling.WallingArea = objEntity.WallingArea;
            storedWalling.SampleImagePath = objEntity.SampleImagePath;


            storedWalling.WallingSampleName = Request.Form["Walling_Sample_Name"];
            storedWalling.WallingSampleCode = Request.Form["Walling_Sample_Code"];
            storedWalling.WallingSampleBrand = Request.Form["Walling_Sample_Brand"];
            storedWalling.WallingSampleHight = Convert.ToDecimal(Request.Form["Walling_Sample_Height"]);
            storedWalling.WallingSampleWidth = Convert.ToDecimal(Request.Form["Walling_Sample_Width"]);
            storedWalling.WallingMililiters = Convert.ToDecimal(Request.Form["Walling_Mililiters"]);
            storedWalling.WallingSamplePrice = Convert.ToDecimal(Request.Form["Walling_Sample_Price"]);
            storedWalling.WallingSampleMinAmount = Convert.ToDecimal(Request.Form["Walling_Sample_Min_Amount"]);
            storedWalling.WallingSampleTotalCost = Convert.ToDecimal(Request.Form["Walling_Sample_Total_Cost"]);
            TypeOfWallingSample SampleRefObj = null;
            if (storedWalling.WallingMililiters == 0)
            {
                SampleRefObj = wallingRepository.SamplesUsingNameRP(storedWalling.WallingSampleName, storedWalling.WallingSampleCode, Convert.ToInt32(storedWalling.WallingSampleHight), Convert.ToInt32(storedWalling.WallingSampleWidth));
                if (SampleRefObj != null)
                {
                    storedWalling.StoredTypeOfWallingSampleRefId = SampleRefObj.WallingTypeSampleId;
                }

            }


            var editStoredWalling = houseWallingStoreRepository.EditStoredWallingRP(storedWalling);
            //need to get house id. only way is save record in table then get house id

            if (editStoredWalling != null)
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



        public ActionResult PopulateDropDownList(string wallingTypeSampleName, string wallingTypeSampleCode, int wallingTypeId)
        {

            wallingRepository = new WallingRepository();
            var Sizes = new List<string>();

            var objListResult = wallingRepository.SameSamplesRP(wallingTypeSampleName, wallingTypeSampleCode, wallingTypeId).Select(i => new { i.WallingTypeBrand, i.WallingMilliliters, i.WallingTypeSamplePrice }).Distinct().OrderByDescending(i => i.WallingTypeBrand).ToArray();

            foreach (var i in objListResult)
            {
                Sizes.Add(i.WallingTypeBrand + "*" + i.WallingMilliliters + "*" + i.WallingTypeSamplePrice);
            }


            if (objListResult == null)
                ViewBag.ViewBagDropDownList = false;
            else
                ViewBag.ViewBagDropDownList = true;

            return Json(Sizes.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MinimalAmountCalculatorForTiles(int height, int width, float area)
        {

            var areaOfTile = (float)(height * width) / 144;
            var minimalAmout = area / areaOfTile;

            return Json(minimalAmout, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalCostCalculatorForTiles(float wallingSampleMinAmount, float wallingSamplePrice)
        {

            var totalCost = wallingSampleMinAmount * wallingSamplePrice;

            return Json(totalCost, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int wallingId)
        {
            houseWallingStoreRepository = new HouseWallingStoreRepository();

            var houseRefId = houseWallingStoreRepository.GetStoredWalling(wallingId).HouseRefId;
            var objResult = houseWallingStoreRepository.DeleteStoredWallingRP(wallingId);

            return RedirectToAction("Index", new { houseId = houseRefId });
        }

    }


}
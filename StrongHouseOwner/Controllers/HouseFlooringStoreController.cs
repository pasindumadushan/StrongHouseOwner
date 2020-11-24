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
    public class HouseFlooringStoreController : Controller
    {
        HouseFlooringStoreRepository houseFlooringStoreRepository;
        FlooringRepository flooringRepository;
        StoredFlooring storedFlooring;
        SearchRepository searchRepository;

        // GET: HouseFloorStore
        public ActionResult Index(int houseId, string SearchBy, string SearchValue)
        {
            houseFlooringStoreRepository = new HouseFlooringStoreRepository();
            ViewBag.ViewBagHouseRefId = houseId;
            searchRepository = new SearchRepository();
            List<StoredFlooring> objResult = new List<StoredFlooring>();

            if (SearchValue != null)
            {
                objResult = searchRepository.GetHouseStoredFlooringListSearchRP(houseId, SearchBy, SearchValue);
            }
            else
            {
                objResult = houseFlooringStoreRepository.GetHouseStoredFlooringListRP(houseId);
            }

            return View(objResult);
        }

        public ActionResult Create(int houseId)
        {

            flooringRepository = new FlooringRepository();
            ViewBag.ViewBagHouseRefId = Convert.ToInt32(houseId);

            var objResult = flooringRepository.GetFlooringListTypesRP();

            return View(objResult);
        }

        [HttpPost]
        public ActionResult CreateHouseFlooring()
        {
            storedFlooring = new StoredFlooring();
            houseFlooringStoreRepository = new HouseFlooringStoreRepository();
            var validation = 0;
            var storedFlooringId = 0;

            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            storedFlooring.HouseRefId = Convert.ToInt32(Request.Form["House_Ref_Id"]);
            storedFlooring.StoredTypeOfFlooringRefId = Convert.ToInt32(Request.Form["Stored_Type_Of_Flooring_Ref_Id"]);
            storedFlooring.FlooringCategory = Request.Form["Flooring_Category"];
            storedFlooring.FlooringType = Request.Form["Flooring_Type"];
            storedFlooring.FlooringName = Request.Form["Flooring_Name"];
            storedFlooring.TypeOfPartition = Request.Form["Type_Of_Partition"];
            storedFlooring.FlooringArea = Convert.ToDecimal(Request.Form["Flooring_Area"]); 


            var editStoredFlooring = houseFlooringStoreRepository.SaveStoredFlooringRP(storedFlooring);
            //need to get house id. only way is save record in table then get house id

            if (editStoredFlooring != null)
            {
                if (ImageFile != null)
                {

                    string extension = Path.GetExtension(ImageFile.FileName);
                    var fileName = editStoredFlooring.FlooringId + "-" + editStoredFlooring.HouseRefId + extension;
                    editStoredFlooring.SampleImagePath = "~/Images/Store/Flooring/" + fileName;

                    ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/Store/Flooring/" + fileName));

                }
                houseFlooringStoreRepository.EditStoredFlooringRP(editStoredFlooring);

                storedFlooringId = editStoredFlooring.FlooringId;
                validation = 1;
            }
            else
            {
                validation = 0;
            }

            var result = new { validation, storedFlooringId };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateUpdate(int storedFlooringId)
        {
            houseFlooringStoreRepository = new HouseFlooringStoreRepository();
            var objResult = houseFlooringStoreRepository.GetStoredFlooring(storedFlooringId);
            List<TypeOfFlooringSample> objListResult = null;

            ViewBag.ViewBagTypeOfFlooringRefId = objResult.StoredTypeOfFlooringRefId;
            ViewBag.ViewBagFlooringArea = objResult.FlooringArea;
            ViewBag.ViewBagStoredFlooringId = storedFlooringId;
            ViewBag.ViewBagHouseRefId = Convert.ToInt32(objResult.HouseRefId);

            if (objResult != null)
            {
                flooringRepository = new FlooringRepository();
                objListResult = flooringRepository.SamplesListRP(Convert.ToInt32(objResult.StoredTypeOfFlooringRefId));
            }

            return View(objListResult);
        }

        [HttpPost]
        public ActionResult UpdateHouseFlooring()
        {
            houseFlooringStoreRepository = new HouseFlooringStoreRepository();
            storedFlooring = new StoredFlooring();
            flooringRepository = new FlooringRepository();
            var validation = 0;

            var objEntity = houseFlooringStoreRepository.GetStoredFlooring(Convert.ToInt32(Request.Form["Flooring_Id"]));
            storedFlooring.FlooringId = objEntity.FlooringId;
            storedFlooring.HouseRefId = objEntity.HouseRefId;
            storedFlooring.StoredTypeOfFlooringRefId = objEntity.StoredTypeOfFlooringRefId;
            storedFlooring.FlooringCategory = objEntity.FlooringCategory;
            storedFlooring.FlooringType = objEntity.FlooringType;
            storedFlooring.FlooringName = objEntity.FlooringName;
            storedFlooring.TypeOfPartition = objEntity.TypeOfPartition;
            storedFlooring.FlooringArea = objEntity.FlooringArea;
            storedFlooring.SampleImagePath = objEntity.SampleImagePath;

            storedFlooring.FlooringSampleName = Request.Form["Flooring_Sample_Name"];
            storedFlooring.FlooringSampleCode = Request.Form["Flooring_Sample_Code"];
            storedFlooring.FlooringSampleBrand = Request.Form["Flooring_Sample_Brand"];
            storedFlooring.FlooringSampleHight = Convert.ToDecimal(Request.Form["Flooring_Sample_Height"]);
            storedFlooring.FlooringSampleWidth = Convert.ToDecimal(Request.Form["Flooring_Sample_Width"]);
            storedFlooring.FlooringMililiters = Convert.ToDecimal(Request.Form["Flooring_Mililiters"]);
            storedFlooring.FlooringSamplePrice = Convert.ToDecimal(Request.Form["Flooring_Sample_Price"]);
            storedFlooring.FlooringSampleMinAmount = Convert.ToDecimal(Request.Form["Flooring_Sample_Min_Amount"]);
            storedFlooring.FlooringSampleTotalCost = Convert.ToDecimal(Request.Form["Flooring_Sample_Total_Cost"]);
            TypeOfFlooringSample SampleRefObj = null;
            if(storedFlooring.FlooringMililiters == 0)
            {
                SampleRefObj = flooringRepository.SamplesUsingNameRP(storedFlooring.FlooringSampleName, storedFlooring.FlooringSampleCode, Convert.ToInt32(storedFlooring.FlooringSampleHight), Convert.ToInt32(storedFlooring.FlooringSampleWidth));
                if (SampleRefObj != null)
                {
                    storedFlooring.StoredTypeOfFlooringSampleRefId = SampleRefObj.FlooringTypeSampleId;
                }
                
            }
            

            var editStoredFlooring = houseFlooringStoreRepository.EditStoredFlooringRP(storedFlooring);
            //need to get house id. only way is save record in table then get house id

            if (editStoredFlooring != null)
            {
                validation = 1;
            }
            else
            {
                validation = 0;
            }

            var result = new { validation};
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public ActionResult PopulateDropDownList(string flooringTypeSampleName, string flooringTypeSampleCode, int flooringTypeId)
        {

            System.Diagnostics.Debug.WriteLine("asda");
            flooringRepository = new FlooringRepository();
            var Sizes = new List<string>();

            var objListResult = flooringRepository.SameSamplesRP(flooringTypeSampleName, flooringTypeSampleCode, flooringTypeId).Select(i => new { i.FlooringTypeSampleSizeHeight, i.FlooringTypeSampleSizeWidth, i.FlooringTypeSamplePrice}).Distinct().OrderByDescending(i => i.FlooringTypeSampleSizeHeight).ToArray();

            foreach (var i in objListResult)
            {
                Sizes.Add(i.FlooringTypeSampleSizeHeight + "x" + i.FlooringTypeSampleSizeWidth + "x" + i.FlooringTypeSamplePrice);
            }


            if (objListResult == null)
                ViewBag.ViewBagDropDownList = false;
            else
                ViewBag.ViewBagDropDownList = true;

            return Json(Sizes.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MinimalAmountCalculatorForTiles(int height, int width, float area)
        {

            var areaOfTile = (float)(height* width)/144;
            var minimalAmout = (int)Math.Round(area / areaOfTile);

            return Json(minimalAmout, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalCostCalculatorForTiles(float flooringSampleMinAmount, float flooringSamplePrice)
        {

            var totalCost = flooringSampleMinAmount * flooringSamplePrice;

            return Json(totalCost, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int flooringId)
        {
            houseFlooringStoreRepository = new HouseFlooringStoreRepository();

            var houseRefId = houseFlooringStoreRepository.GetStoredFlooring(flooringId).HouseRefId;
            var objResult = houseFlooringStoreRepository.DeleteStoredFlooringRP(flooringId);

            return RedirectToAction("Index", new { houseId = houseRefId });
        }

    }

    
}
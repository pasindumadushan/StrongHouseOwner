using StrongHouseOwner.Data.EntityModel;
using StrongHouseOwner.Data.Repository;
using System;
using System.Collections.Generic;
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
        // GET: HouseFloorStore
        public ActionResult Index(int houseId)
        {
            ViewBag.ViewBagHouseRefId = houseId;

            return View();
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
            var minimalAmout = area / areaOfTile;

            return Json(minimalAmout, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalCostCalculatorForTiles(float flooringSampleMinAmount, float flooringSamplePrice)
        {

            var totalCost = flooringSampleMinAmount * flooringSamplePrice;

            return Json(totalCost, JsonRequestBehavior.AllowGet);
        }

    }

    
}
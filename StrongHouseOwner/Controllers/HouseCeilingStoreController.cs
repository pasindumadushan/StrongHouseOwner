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
    public class HouseCeilingStoreController : Controller
    {
        HouseCeilingStoreRepository houseCeilingStoreRepository;
        CeilingRepository ceilingRepository;
        StoredCeiling storedCeiling;
        SearchRepository searchRepository;

        // GET: HouseFloorStore
        public ActionResult Index(int houseId, string SearchBy, string SearchValue)
        {
            houseCeilingStoreRepository = new HouseCeilingStoreRepository();
            ViewBag.ViewBagHouseRefId = houseId;
            searchRepository = new SearchRepository();
            List<StoredCeiling> objResult = new List<StoredCeiling>();

            if (SearchValue != null)
            {
                objResult = searchRepository.GetHouseStoredCeilingListSearchRP(houseId, SearchBy, SearchValue);
            }
            else
            {
                objResult = houseCeilingStoreRepository.GetHouseStoredCeilingListRP(houseId);
            }

            return View(objResult);
        }

        public ActionResult Create(int houseId)
        {

            ceilingRepository = new CeilingRepository();
            ViewBag.ViewBagHouseRefId = Convert.ToInt32(houseId);

            var objResult = ceilingRepository.GetCeilingListTypesRP();

            return View(objResult);
        }

        [HttpPost]
        public ActionResult CreateHouseCeiling()
        {
            storedCeiling = new StoredCeiling();
            houseCeilingStoreRepository = new HouseCeilingStoreRepository();
            var validation = 0;
            var storedCeilingId = 0;

            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            storedCeiling.HouseRefId = Convert.ToInt32(Request.Form["House_Ref_Id"]);
            storedCeiling.StoredTypeOfCeilingRefId = Convert.ToInt32(Request.Form["Stored_Type_Of_Ceiling_Ref_Id"]);
            storedCeiling.CeilingCategory = Request.Form["Ceiling_Category"];
            storedCeiling.CeilingType = Request.Form["Ceiling_Type"];
            storedCeiling.CeilingName = Request.Form["Ceiling_Name"];
            storedCeiling.TypeOfPartition = Request.Form["Type_Of_Partition"];
            storedCeiling.CeilingArea = Convert.ToDecimal(Request.Form["Ceiling_Area"]);


            var editStoredCeiling = houseCeilingStoreRepository.SaveStoredCeilingRP(storedCeiling);
            //need to get house id. only way is save record in table then get house id

            if (editStoredCeiling != null)
            {
                if (ImageFile != null)
                {

                    string extension = Path.GetExtension(ImageFile.FileName);
                    var fileName = editStoredCeiling.CeilingId + "-" + editStoredCeiling.HouseRefId + extension;
                    editStoredCeiling.SampleImagePath = "~/Images/Store/Ceiling/" + fileName;

                    ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/Store/Ceiling/" + fileName));

                }
                houseCeilingStoreRepository.EditStoredCeilingRP(editStoredCeiling);

                storedCeilingId = editStoredCeiling.CeilingId;
                validation = 1;
            }
            else
            {
                validation = 0;
            }

            var result = new { validation, storedCeilingId };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateUpdate(int storedCeilingId)
        {
            houseCeilingStoreRepository = new HouseCeilingStoreRepository();
            var objResult = houseCeilingStoreRepository.GetStoredCeiling(storedCeilingId);
            List<TypeOfCeilingSample> objListResult = null;

            ViewBag.ViewBagTypeOfCeilingRefId = objResult.StoredTypeOfCeilingRefId;
            ViewBag.ViewBagCeilingArea = objResult.CeilingArea;
            ViewBag.ViewBagStoredCeilingId = storedCeilingId;
            ViewBag.ViewBagHouseRefId = Convert.ToInt32(objResult.HouseRefId);

            if (objResult != null)
            {
                ceilingRepository = new CeilingRepository();
                objListResult = ceilingRepository.SamplesListRP(Convert.ToInt32(objResult.StoredTypeOfCeilingRefId));
            }

            return View(objListResult);
        }

        [HttpPost]
        public ActionResult UpdateHouseCeiling()
        {
            houseCeilingStoreRepository = new HouseCeilingStoreRepository();
            storedCeiling = new StoredCeiling();
            ceilingRepository = new CeilingRepository();
            var validation = 0;

            var objEntity = houseCeilingStoreRepository.GetStoredCeiling(Convert.ToInt32(Request.Form["Ceiling_Id"]));
            storedCeiling.CeilingId = objEntity.CeilingId;
            storedCeiling.HouseRefId = objEntity.HouseRefId;
            storedCeiling.StoredTypeOfCeilingRefId = objEntity.StoredTypeOfCeilingRefId;
            storedCeiling.CeilingCategory = objEntity.CeilingCategory;
            storedCeiling.CeilingType = objEntity.CeilingType;
            storedCeiling.CeilingName = objEntity.CeilingName;
            storedCeiling.TypeOfPartition = objEntity.TypeOfPartition;
            storedCeiling.CeilingArea = objEntity.CeilingArea;
            storedCeiling.SampleImagePath = objEntity.SampleImagePath;

            storedCeiling.CeilingSampleName = Request.Form["Ceiling_Sample_Name"];
            storedCeiling.CeilingSampleCode = Request.Form["Ceiling_Sample_Code"];
            storedCeiling.CeilingSampleBrand = Request.Form["Ceiling_Sample_Brand"];
            storedCeiling.CeilingSampleHight = Convert.ToDecimal(Request.Form["Ceiling_Sample_Height"]);
            storedCeiling.CeilingSampleWidth = Convert.ToDecimal(Request.Form["Ceiling_Sample_Width"]);
            storedCeiling.CeilingMililiters = Convert.ToDecimal(Request.Form["Ceiling_Mililiters"]);
            storedCeiling.CeilingSamplePrice = Convert.ToDecimal(Request.Form["Ceiling_Sample_Price"]);
            storedCeiling.CeilingSampleMinAmount = Convert.ToDecimal(Request.Form["Ceiling_Sample_Min_Amount"]);
            storedCeiling.CeilingSampleTotalCost = Convert.ToDecimal(Request.Form["Ceiling_Sample_Total_Cost"]);
            TypeOfCeilingSample SampleRefObj = null;
            if (storedCeiling.CeilingMililiters == 0)
            {
                SampleRefObj = ceilingRepository.SamplesUsingNameRP(storedCeiling.CeilingSampleName, storedCeiling.CeilingSampleCode, Convert.ToInt32(storedCeiling.CeilingSampleHight), Convert.ToInt32(storedCeiling.CeilingSampleWidth));
                if (SampleRefObj != null)
                {
                    storedCeiling.StoredTypeOfCeilingSampleRefId = SampleRefObj.CeilingTypeSampleId;
                }

            }


            var editStoredCeiling = houseCeilingStoreRepository.EditStoredCeilingRP(storedCeiling);
            //need to get house id. only way is save record in table then get house id

            if (editStoredCeiling != null)
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



        public ActionResult PopulateDropDownList(string ceilingTypeSampleName, string ceilingTypeSampleCode, int ceilingTypeId)
        {

            System.Diagnostics.Debug.WriteLine("asda");
            ceilingRepository = new CeilingRepository();
            var Sizes = new List<string>();

            var objListResult = ceilingRepository.SameSamplesRP(ceilingTypeSampleName, ceilingTypeSampleCode, ceilingTypeId).Select(i => new { i.CeilingTypeSampleSizeHeight, i.CeilingTypeSampleSizeWidth, i.CeilingTypeSamplePrice }).Distinct().OrderByDescending(i => i.CeilingTypeSampleSizeHeight).ToArray();

            foreach (var i in objListResult)
            {
                Sizes.Add(i.CeilingTypeSampleSizeHeight + "x" + i.CeilingTypeSampleSizeWidth + "x" + i.CeilingTypeSamplePrice);
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

        public ActionResult TotalCostCalculatorForTiles(float ceilingSampleMinAmount, float ceilingSamplePrice)
        {

            var totalCost = ceilingSampleMinAmount * ceilingSamplePrice;

            return Json(totalCost, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int ceilingId)
        {
            houseCeilingStoreRepository = new HouseCeilingStoreRepository();

            var houseRefId = houseCeilingStoreRepository.GetStoredCeiling(ceilingId).HouseRefId;
            var objResult = houseCeilingStoreRepository.DeleteStoredCeilingRP(ceilingId);

            return RedirectToAction("Index", new { houseId = houseRefId });
        }
    }


}
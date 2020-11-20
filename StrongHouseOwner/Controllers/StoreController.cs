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
    public class StoreController : Controller
    {
        HouseDetailRepository houseDetailRepository;
        HouseDetail houseDetail;
        SearchRepository searchRepository;
        // GET: Store
        public ActionResult Index()
        {
            
            if (Session["User_Mail"] == null && Session["User_Password"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UserPanel");
            }

        }

        public ActionResult UserPanel(string SearchBy, string SearchValue)
        {

            houseDetailRepository = new HouseDetailRepository();
            searchRepository = new SearchRepository();
            List<HouseDetail> objResult = new List<HouseDetail>();

            if (SearchValue != null)
            {
                objResult = searchRepository.HouseDetailSearchRP((int)Session["User_Id"], SearchBy, SearchValue);
            }
            else
            {
                objResult = houseDetailRepository.GetHouseDetailListRP(Convert.ToInt32(Session["User_Id"]));
            }

            ViewBag.userId = Convert.ToInt32(Session["User_Id"]);
            return View(objResult);

        }

        public ActionResult Create(int userId)
        {

            ViewBag.ViewBaguserId = Convert.ToInt32(userId);

            return View();
        }

        [HttpPost]
        public ActionResult CreateHouse()
        {
            houseDetail = new HouseDetail();
            houseDetailRepository = new HouseDetailRepository();
            var validation = 0;

            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            houseDetail.UserRefId = Convert.ToInt32(Request.Form["UserId"]);
            houseDetail.HouseName = Request.Form["House_Name"];
            houseDetail.HouseAddress = Request.Form["House_Address"];
            houseDetail.HouseAdditionalInformation = Request.Form["Additional_Information"];
            houseDetail.NumberOfFloors = Convert.ToInt32(Request.Form["Number_Of_Floors"]);
            houseDetail.FloorArea = Convert.ToDecimal(Request.Form["Floor_Area"]);
            houseDetail.LandArea = Convert.ToDecimal(Request.Form["Land_Area"]);
            houseDetail.NumberOfLivingRooms = Convert.ToInt32(Request.Form["Number_Of_LivingRooms"]);
            houseDetail.NumberOfDiningRooms = Convert.ToInt32(Request.Form["Number_Of_DiningRooms"]);
            houseDetail.NumberOfBedRooms = Convert.ToInt32(Request.Form["Number_Of_BedRooms"]);
            houseDetail.NumberOfWashRooms = Convert.ToInt32(Request.Form["Number_Of_WashRooms"]);
            houseDetail.NumberOfKitchens = Convert.ToInt32(Request.Form["Number_Of_Kitchens"]);
            houseDetail.NumberOfStoreRooms = Convert.ToInt32(Request.Form["Number_Of_StoreRooms"]);
            houseDetail.NumberOfGarages = Convert.ToInt32(Request.Form["Number_Of_Garages"]);
            houseDetail.EstimatedValue = Convert.ToDecimal(Request.Form["Estimated_Value"]);

            var editHouseDetail = houseDetailRepository.SaveHouseDetailRP(houseDetail);
            //need to get house id. only way is save record in table then get house id

            if(editHouseDetail != null)
            {
                if (ImageFile != null)
                {

                    string extension = Path.GetExtension(ImageFile.FileName);
                    var fileName = editHouseDetail.HouseId + "-" + editHouseDetail.UserRefId + extension;
                    editHouseDetail.HouseImagePath = "~/Images/Store/Houses/" + fileName;

                    ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/Store/Houses/" + fileName));

                }
                houseDetailRepository.EditHouseDetailRP(editHouseDetail);

                validation = 1;
            }
            else
            {
                validation = 0;
            }


            var result = new { validation };
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Edit(int houseId)
        {
            houseDetailRepository = new HouseDetailRepository();
            var objResult = houseDetailRepository.GetHouseDetailRP(houseId);

            ViewBag.ViewBaguserId = Convert.ToInt32(objResult.UserRefId);

            return View(objResult);
        }

        [HttpPost]
        public ActionResult EditHouse()
        {
            houseDetail = new HouseDetail();
            houseDetailRepository = new HouseDetailRepository();
            var validation = 0;

            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            houseDetail.UserRefId = Convert.ToInt32(Request.Form["UserId"]);
            houseDetail.HouseId = Convert.ToInt32(Request.Form["HouseId"]);
            houseDetail.HouseName = Request.Form["House_Name"];
            houseDetail.HouseAddress = Request.Form["House_Address"];
            houseDetail.HouseAdditionalInformation = Request.Form["Additional_Information"];
            houseDetail.NumberOfFloors = Convert.ToInt32(Request.Form["Number_Of_Floors"]);
            houseDetail.FloorArea = Convert.ToDecimal(Request.Form["Floor_Area"]);
            houseDetail.LandArea = Convert.ToDecimal(Request.Form["Land_Area"]);
            houseDetail.NumberOfLivingRooms = Convert.ToInt32(Request.Form["Number_Of_LivingRooms"]);
            houseDetail.NumberOfDiningRooms = Convert.ToInt32(Request.Form["Number_Of_DiningRooms"]);
            houseDetail.NumberOfBedRooms = Convert.ToInt32(Request.Form["Number_Of_BedRooms"]);
            houseDetail.NumberOfWashRooms = Convert.ToInt32(Request.Form["Number_Of_WashRooms"]);
            houseDetail.NumberOfKitchens = Convert.ToInt32(Request.Form["Number_Of_Kitchens"]);
            houseDetail.NumberOfStoreRooms = Convert.ToInt32(Request.Form["Number_Of_StoreRooms"]);
            houseDetail.NumberOfGarages = Convert.ToInt32(Request.Form["Number_Of_Garages"]);
            houseDetail.EstimatedValue = Convert.ToDecimal(Request.Form["Estimated_Value"]);

            if (ImageFile != null)
            {

                string extension = Path.GetExtension(ImageFile.FileName);
                var fileName = houseDetail.HouseId + "-" + houseDetail.UserRefId + extension;
                houseDetail.HouseImagePath = "~/Images/Store/Houses/" + fileName;

                ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/Store/Houses/" + fileName));

            }
            var objResult = houseDetailRepository.EditHouseDetailRP(houseDetail);

            if(objResult != null)
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

        public ActionResult Delete(int houseId)
        {
            houseDetailRepository = new HouseDetailRepository();
            var objResult = houseDetailRepository.DeleteHouseDetailRP(houseId);

            return RedirectToAction("index");
        }
    }

    
}
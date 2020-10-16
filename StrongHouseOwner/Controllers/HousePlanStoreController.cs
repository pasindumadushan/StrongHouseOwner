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
    public class HousePlanStoreController : Controller
    {
        HousePlanRepository housePlanRepository;
        StoredPlan storedPlan;

        // GET: HousePlanStore
        public ActionResult Index(int houseId)
        {

            housePlanRepository = new HousePlanRepository();
            ViewBag.ViewBagHouseRefId = houseId;

            var objResult = housePlanRepository.GetHouseStoredPlanListRP(houseId);
            
            return View(objResult);
        }

        public ActionResult Create(int houseId)
        {

            housePlanRepository = new HousePlanRepository();
            ViewBag.ViewBagHouseRefId = Convert.ToInt32(houseId);

            var objResult = housePlanRepository.GetPlanListRP();

            return View(objResult);
        }

        [HttpPost]
        public ActionResult CreateHousePlan()
        {
            storedPlan = new StoredPlan();
            housePlanRepository = new HousePlanRepository();
            var validation = 0;

            HttpPostedFileBase ImageFile;
            ImageFile = Request.Files["ImageFile"];

            storedPlan.HouseRefId = Convert.ToInt32(Request.Form["House_Ref_Id"]);
            storedPlan.StoredPlanRefId = Convert.ToInt32(Request.Form["Stored_Plan_Ref_Id"]);
            storedPlan.PlanName = Request.Form["Plan_Name"];
            storedPlan.TypeOfPlan = Request.Form["Type_Of_Plan"];
            storedPlan.Scale = Request.Form["Scale"];
            storedPlan.DrawnBy =Request.Form["Drawn_By"];
            storedPlan.AdditionalInformation = Request.Form["Additional_Information"];


            var editStoredPlan = housePlanRepository.SaveStoredPlanRP(storedPlan);
            //need to get house id. only way is save record in table then get StoredPlanId

            if (editStoredPlan != null)
            {
                if (ImageFile != null)
                {

                    string extension = Path.GetExtension(ImageFile.FileName);
                    var fileName = editStoredPlan.StoredPlanId + "-" + editStoredPlan.HouseRefId + extension;
                    editStoredPlan.StoredPlanImagePath = "~/Images/Store/Plans/" + fileName;

                    ImageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/Store/Plans/" + fileName));

                }
                housePlanRepository.EditStoredPlanRP(editStoredPlan);

                validation = 1;
            }
            else
            {
                validation = 0;
            }


            var result = new { validation };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int storedPlanId)
        {
            housePlanRepository = new HousePlanRepository();

            var houseRefId = housePlanRepository.GetHouseStoredPlanRP(storedPlanId).HouseRefId;
            var objResult = housePlanRepository.DeleteStoredPlanRP(storedPlanId);

            return RedirectToAction("Index", new { houseId = houseRefId });
        }
    }
}
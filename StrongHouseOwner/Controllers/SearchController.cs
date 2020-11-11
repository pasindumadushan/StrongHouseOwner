using Newtonsoft.Json;
using StrongHouseOwner.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StrongHouseOwner.Controllers
{
    public class SearchController : Controller
    {
        SearchRepository searchRepository;
        // GET: Search
        public JsonResult SearchHouse(string searchBy, string searchValue)
        {
            searchRepository = new SearchRepository();

            var objResults = searchRepository.HouseDetailSearchRP((int)Session["User_Id"], searchBy, searchValue);

            //var objResultsnew = objResults.Select(x => x.HouseName).ToList();

            foreach (var i in objResults)
            {
                System.Diagnostics.Debug.WriteLine("housename " + i.HouseName);
            }

            string output = JsonConvert.SerializeObject(objResults, Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


            return Json(output, JsonRequestBehavior.AllowGet);
        }
    }
}
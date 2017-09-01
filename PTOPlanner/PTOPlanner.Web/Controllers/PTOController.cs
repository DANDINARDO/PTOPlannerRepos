using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTOPlanner.Models;
using PTOPlanner.Web.Models;
using PTOPlanner.Web.Repository;

namespace PTOPlanner.Controllers
{
    public class PTOController : Controller
    {
        // GET: PTO
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveEntry(PTOEntry entry)
        {
            var resultModel = new
            {
                Success = true,
                Message = string.Empty
            };

            return Json(resultModel, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult LoadYear(int year)
        {

            //List<PTOData> data = new List<PTOData>();

            //PTOData d1 = new PTOData();

            //d1.Comments = "test comments";
            //d1.EmployeeID = 3;
            //d1.EmployeePTOBalanceID = 1;
            //d1.PTOBalance = 25.5M;
            //d1.RequestedHours = 5;
            //d1.WeekEnding = "1/14/2017";
            
            //data.Add(d1);

            //PTOData d2 = new PTOData();

            //d2.Comments = "more test comments";
            //d2.EmployeeID = 3;
            //d2.EmployeePTOBalanceID = 2;
            //d2.PTOBalance = 20.5M;
            //d2.RequestedHours = 0;
            //d2.WeekEnding = "1/28/2017";

            //data.Add(d2);
            var repo = new PTORepo();

            var data = repo.LoadYear(1, year);

            var resultModel = new
            {
                Success = true,
                Message = string.Empty,
                Data = data
            };

            return Json(resultModel, JsonRequestBehavior.DenyGet);

        }
    }
}
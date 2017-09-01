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
            var repo = new PTORepo();
            var employees = repo.LoadEmployees();

            return View(employees);
        }

        [HttpPost]
        public JsonResult SaveEntry(PTOEntry entry)
        {
            var repo = new PTORepo();

            var data = repo.Save(entry);

            var resultModel = new
            {
                Success = true,
                Message = string.Empty,
                Data = data
            };

            return Json(resultModel, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult LoadYear(int year, int empId = 0)
        {

            var repo = new PTORepo();

            var data = repo.LoadYear(empId, year);

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
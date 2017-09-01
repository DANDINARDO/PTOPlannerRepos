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
        public JsonResult LoadYear(int year)
        {

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
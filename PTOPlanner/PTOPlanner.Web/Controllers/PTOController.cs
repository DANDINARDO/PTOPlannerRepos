using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTOPlanner.Models;

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
            var resultModel = new
            {
                Success = true,
                Message = string.Empty
            };

            return Json(resultModel, JsonRequestBehavior.DenyGet);

        }
    }
}
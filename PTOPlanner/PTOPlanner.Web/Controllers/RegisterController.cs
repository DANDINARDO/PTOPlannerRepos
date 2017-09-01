using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTOPlanner.Models;
using PTOPlanner.Web.Repository;

namespace PTOPlanner.Web.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterEmployee(Employee employee)
        {
            var repo = new PTORepo();

            repo.SaveEmployee(employee);

            return RedirectToAction("Index", "PTO");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindTraders.MVC5.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult SearchEmployees()
        {
            return View();
        }
    }
}
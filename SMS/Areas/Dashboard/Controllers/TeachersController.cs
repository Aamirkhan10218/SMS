using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Dashboard.Controllers
{
    public class TeachersController : Controller
    {
        // GET: Dashboard/Teachers
        public ActionResult Index()
        {
            return View();
        }
    }
}
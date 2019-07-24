using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Dashboard.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Dashboard/Reports
        public ActionResult Index()
        {
            return View();
        }
    }
}
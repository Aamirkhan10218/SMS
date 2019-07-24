using SMS.Areas.Dashboard.ViewModels;
using SMS.Entities;
using SMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Dashboard.Controllers
{
    public class ClassesController : Controller
    {
        ClassServices services = new ClassServices();
        // GET: Dashboard/Classes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listing()
        {
            ClassListingModel model = new ClassListingModel();
            model.Classes = services.getAllClasses();
            return PartialView("_Listing",model);
        }
        [HttpGet]
        public ActionResult Action()
        {
            ClassActionModel model = new ClassActionModel();
            return PartialView("_Action",model);
        }
        [HttpPost]
        public ActionResult Action(ClassActionModel model)
        {
            Class cla = new Class();
            cla.ClassName = model.Name;
            services.saveClass(cla);
            return RedirectToAction("Action");
        }
    }
}
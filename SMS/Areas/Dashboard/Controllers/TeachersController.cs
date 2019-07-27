using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Areas.Dashboard.ViewModels;
using SMS.Services;
namespace SMS.Areas.Dashboard.Controllers
{
    public class TeachersController : Controller
    {
        TeacherServices tc = new TeacherServices();
        // GET: Dashboard/Teachers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listing()
        {
            TeacherListingModel model = new TeacherListingModel();
            model.Teachers = tc.getAllTeacher();
            return PartialView("_Listing",model);
        }
        public ActionResult Create()
        {
            TeacherActionModel model = new TeacherActionModel();
            return PartialView("_Create",model);
        }
    }
}
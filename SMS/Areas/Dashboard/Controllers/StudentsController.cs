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
    public class StudentsController : Controller
    {
        StudentsServices studentsServices = new StudentsServices();
        public ActionResult Index()
        {
            return View("");
        }
        public ActionResult Listing()
        {
            StudentsListingModel model = new StudentsListingModel();
            model.Students = studentsServices.getAllStudents();
            return PartialView("_Listing", model);
        }
        [HttpGet]
        public ActionResult Action()
        {
            StudentsActionModel model = new StudentsActionModel();
            return PartialView("_Action",model);
        }
        [HttpPost]
        public ActionResult Action(StudentsActionModel model)
        {
            Teacher std = new Teacher();
            std.Name = model.StdName;
            studentsServices.saveStudent(std);
            return RedirectToAction("Action");
        }
    }
}
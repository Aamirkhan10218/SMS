using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Areas.Dashboard.ViewModels;
using SMS.Entities;
using SMS.Services;
namespace SMS.Areas.Dashboard.Controllers
{
    public class TeachersController : Controller
    {
        TeacherServices services = new TeacherServices();
        // GET: Dashboard/Teachers
        public ActionResult Index(string searchTerm)
        {
            TeacherListingModel model = new TeacherListingModel();
            if (string.IsNullOrEmpty(searchTerm))
            {
                model.Teachers = services.getAllTeacher();
                return View(model);
            }
            model.Teachers = services.searchTeacher(searchTerm);
            searchTerm = null;
            return View(model);
        }
     
        [HttpGet]
        public ActionResult Create()
        {
            TeacherActionModel model = new TeacherActionModel();
            return PartialView("_Create",model);
        }
        [HttpPost]
        public ActionResult Create(TeacherActionModel model)
        {
            Teacher tc = new Teacher();
            tc.Name = model.Name;
            services.saveTeacher(tc);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id=0)
        {
            TeacherActionModel model = new TeacherActionModel();
            model.ID = id.Value;
            return PartialView("_Delete",model);
        }
        [HttpPost]
        public ActionResult Delete(TeacherActionModel model)
        {
            services.DeleteTeacher(model.ID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? ID=0)
        {
            TeacherActionModel model = new TeacherActionModel();
            var getData = services.getTeacherByID(ID.Value);
            model.ID = ID.Value;
            model.Name = getData.Name;
            return PartialView("_Edit",model);
        }
        [HttpPost]
        public ActionResult Edit(TeacherActionModel model)
        {
            Teacher tt = new Teacher();
            tt.ID = model.ID;
            tt.Name = model.Name;
            services.EditTeacher(tt); 
            return RedirectToAction("Index");
        }
       
    }
}
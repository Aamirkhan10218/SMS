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
        StudentsListingModel model = new StudentsListingModel();
        ClassServices clsServices = new ClassServices();
        public ActionResult Index(string stdName,int ID=0)
        {
            model.Classes = clsServices.getAllClasses();
            if (string.IsNullOrEmpty(stdName)&&ID==0)
            {
            model.Students = studentsServices.getAllStudents();
                return View(model);
            }
                model.Students = studentsServices.getAllStudentByName(stdName,ID);
            return View(model);
         //   return PartialView("_Listing", model);
        }
        //public ActionResult Listing()
        //{
        //    if (!string.IsNullOrEmpty(stdName))
        //    {
        //    model.Students = studentsServices.getAllStudentByName(stdName);
        //    }
        //    model.Students = studentsServices.getAllStudents();
        //    return PartialView("_Listing", model);
        //}
        [HttpGet]
        public ActionResult Action()
        {
            StudentsActionModel model = new StudentsActionModel();
            model.Classes = clsServices.getAllClasses();
            return PartialView("_Action",model);
        }
        [HttpPost]
        public ActionResult Action(StudentsActionModel model)
        {
            Student std = new Student();
            std.RollNo = model.RollNo;
            std.StdName = model.StdName;
            std.DOB = model.DOB;
            std.FatherName = model.FatherName;
            std.ClassID = model.ClassID;
            std.Address = model.Address;
            studentsServices.saveStudent(std);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int RollNo)
        {
            StudentsActionModel model = new StudentsActionModel();
        
            var res = studentsServices.getStudentByRoll(RollNo);
            model.Classes = clsServices.getAllClasses();
            model.RollNo = RollNo;
            model.StdName = res.StdName;
            model.DOB = res.DOB;
            model.Address = res.Address;
            model.FatherName = res.FatherName;
            model.ClassID = res.ClassID;
            return PartialView("_Edit", model);
        }
        [HttpPost]
        public ActionResult Edit(StudentsActionModel model)
        {
            Student std = new Student();
            std.RollNo = model.RollNo;
            std.ClassID = model.ClassID;
            std.StdName = model.StdName;
            std.FatherName = model.FatherName;
            std.Address = model.Address;
            std.DOB = model.DOB;
            studentsServices.EditStudent(std);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int RollNo=0)
        {
            StudentsActionModel model = new StudentsActionModel();
            model.RollNo = RollNo;
            return PartialView("_Delete",model);
        }
        [HttpPost]
        public ActionResult Delete(StudentsActionModel model)
        {
            Student std = new Student();
            std.RollNo = model.RollNo;
            studentsServices.DeleteStudent(std);
            return RedirectToAction("Index");
        }
        //public ActionResult SearchStudentByName(string StdName)
        //{
        //    StudentsListingModel model = new StudentsListingModel();
        //   
        //    return PartialView("_Listing", model);
        //}
    }
}
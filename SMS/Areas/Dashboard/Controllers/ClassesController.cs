using SMS.Areas.Dashboard.ViewModels;
using SMS.Entities;
using SMS.Services;
using System.Web.Mvc;

namespace SMS.Areas.Dashboard.Controllers
{
    public class ClassesController : Controller
    {
        ClassServices services = new ClassServices();
        // GET: Dashboard/Classes
        public ActionResult Index(string searchTerm)
        {
            ClassListingModel model = new ClassListingModel();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                model.Classes = services.getSearchResult(searchTerm);
                return View(model);
            }
            model.Classes = services.getAllClasses();
            //To Open main View
            return View(model);
        }
        [HttpGet]
        public ActionResult Action(int? id)
        {
            ClassActionModel model = new ClassActionModel();
            if (id.HasValue)
            {
                var getData = services.getClassbyID(id.Value);
                model.ClassID = getData.ID;
                model.Name = getData.ClassName;
            }
            //Show Modal
            
            return PartialView("_Action",model);
        }
        [HttpPost]
        public ActionResult Action(ClassActionModel model)
        {
            var getData = services.getClassbyID(model.ClassID);
            Class cla = new Class();
            //Save Data from Modal To Database
            if (model.ClassID> 0)
            {
                getData.ClassName = model.Name;
                services.eidtClass(getData);
            }
            else
            {

            cla.ClassName = model.Name;
            services.saveClass(cla);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? ID = 0)
        {
            ClassActionModel model = new ClassActionModel();
            model.ClassID = ID.Value;
            return PartialView("_Delete",model);
        }
        [HttpPost]
        public ActionResult Delete(ClassActionModel model)

        {
            var data = services.getClassbyID(model.ClassID);
            services.deleteClass(data);
            return RedirectToAction("Index");
        }
    }
}
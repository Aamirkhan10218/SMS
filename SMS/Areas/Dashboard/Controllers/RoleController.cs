using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SMS.Areas.Dashboard.ViewModels;
using SMS.Services;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Dashboard.Controllers
{
    public class RoleController : Controller
    {
        #region MSIDENTITY.NET
        private SMSSignInManager _signInManager;
        private SMSUserManager _userManager;
        private SMSRoleManager _roleManager;
        public RoleController()
        {
        }

        public RoleController(SMSUserManager userManager, SMSSignInManager signInManager, SMSRoleManager roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        public SMSSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<SMSSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public SMSUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<SMSUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public SMSRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<SMSRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        #endregion
        RoleListingModel model = new RoleListingModel();

        // GET: Dashboard/User
        public ActionResult Index(string searchTerm)
        {
            
            
            model.Roles = searcRole(searchTerm);
            return View(model);
        }
        public List<IdentityRole> searcRole(string searchTerm)
        {
               var users = RoleManager.Roles;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));

            }
           
            return users.ToList();
        }
     
        [HttpGet]
        public async Task<ActionResult> Edit(string ID)
        {
            RoleActionModel model = new RoleActionModel();
            if (!string.IsNullOrEmpty(ID))
            {
                var role = await RoleManager.FindByIdAsync(ID);
                model.ID = role.Id;
                model.Name = role.Name;
            }
            return PartialView("_Edit", model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(RoleActionModel model)
        {
            var role = await RoleManager.FindByIdAsync(model.ID);
            role.Id = model.ID;
            role.Name = model.Name;
      
            await RoleManager.UpdateAsync(role);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Action()
        {
            RoleActionModel model = new RoleActionModel();
            return PartialView("_Action", model);
        }
        [HttpPost]
        public async Task<ActionResult> Action(RoleActionModel model)
        {
            var role = new IdentityRole();
            role.Name = model.Name;
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            RoleActionModel model = new RoleActionModel();

            var user = await RoleManager.FindByIdAsync(id);
            model.ID = user.Id;
            return PartialView("_Delete", model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(RoleActionModel model)
        {
            var user = await RoleManager.FindByIdAsync(model.ID);
            await RoleManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }
    }
}

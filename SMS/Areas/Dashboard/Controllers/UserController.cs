using Microsoft.AspNet.Identity.Owin;
using SMS.Areas.Dashboard.ViewModels;
using SMS.Entities;
using SMS.Services;
using SMS.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Dashboard.Controllers
{
    public class UserController : Controller
    {

        private SMSSignInManager _signInManager;
        private SMSUserManager _userManager;

        public UserController()
        {
        }

        public UserController(SMSUserManager userManager, SMSSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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
        UserListingModel model = new UserListingModel();
        
        // GET: Dashboard/User
        public ActionResult Index(string searchTerm,string roleid,int? page)
        {
            int recordSize = 5;
            page = page ?? 1;
            int totalCountAll = searchUserCount(searchTerm, page.Value, recordSize);
            model.Pager = new Pager(totalCountAll, page, recordSize);
            model.Users = searchUser(searchTerm,page.Value,recordSize);
            return View(model);
        }
        public List<SMSUser> searchUser(string searchTerm,int page,int recordSize)
        {
            var users = UserManager.Users;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(a => a.UserName.ToLower().Contains(searchTerm.ToLower()));
               
            }
            var skip = (page - 1) * recordSize;
            return users.OrderBy(x => x.Email).Skip(skip).Take(recordSize).ToList();
        }
        public int searchUserCount(string searchTerm, int page, int recordSize)
        {
            var users = UserManager.Users;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(a => a.Email.ToLower().Contains(searchTerm.ToLower()));

            }
            
            return users.Count();
        }
        [HttpGet]
        public async Task<ActionResult> Edit(string ID)
        {
            UserActionModel model = new UserActionModel();
            if (!string.IsNullOrEmpty(ID))
            {
                var user = await UserManager.FindByIdAsync(ID);
                model.ID = user.Id;
                model.UserName = user.UserName;
                model.FullName = user.FullName;
                model.Address = user.Address;
                model.Phone = user.Phone;
                model.Email = user.Email;
            }
            return PartialView("_Edit",model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(UserActionModel model)
        {
            var user = await UserManager.FindByIdAsync(model.ID);
            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.Address = model.Address;
            await UserManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Action()
        {
            UserActionModel model = new UserActionModel();
            return PartialView("_Action",model);
        }
        [HttpPost]
        public  async Task<ActionResult> Action(UserActionModel model)
        {
            var user = new SMSUser();
            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.Address = model.Address;
            await UserManager.CreateAsync(user);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            UserActionModel model = new UserActionModel();
              
            var user = await UserManager.FindByIdAsync(id);
            model.ID = user.Id;
            return PartialView("_Delete", model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(UserActionModel model)
        {
            var user = await UserManager.FindByIdAsync(model.ID);
            await UserManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }
    }
}
using Microsoft.AspNet.Identity.Owin;
using SMS.Areas.Dashboard.ViewModels;
using SMS.Services;
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
        public ActionResult Index()
        {
            model.Users = UserManager.Users;
            return View(model);
        }
    }
}
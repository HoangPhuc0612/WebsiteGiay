using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebsiteGiay.Identity;
using WebsiteGiay.ViewModel;

namespace WebsiteGiay.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM rmv)
        {
            if (ModelState.IsValid)
            {
                var appDbcontext = new AppDBContext();
                var userStore = new AppUserStore(appDbcontext);
                var userManager = new AppUserManager(userStore);
                var passWordHash = Crypto.HashPassword(rmv.Password);
                var user = new AppUser()
                {
                    Email = rmv.Email,
                    UserName = rmv.UserName,
                    PasswordHash = passWordHash,
                    Birthday = rmv.DateOfBirth,
                    Address = rmv.Address,
                    City = rmv.City,
                    PhoneNumber = rmv.PhoneNumber,
                };
                IdentityResult identity = userManager.Create(user);
                if (identity.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return RedirectToAction("Register", "Account");
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            var appDbcontext = new AppDBContext();
            var userStore = new AppUserStore(appDbcontext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(loginVM.UserName, loginVM.Password);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Sai tài khoản hoặc sai mật khẩu");
                return View();
            }

        }

        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyProfile()
        {
            var appDbcontext = new AppDBContext();
            var userStore = new AppUserStore(appDbcontext);
            var userManager = new AppUserManager(userStore);
            var user = new AppUser();
            user = userManager.FindById(User.Identity.GetUserId());
            return View(user);
        }

        public ActionResult EditProfile(string id)
        {
            var appDbcontext = new AppDBContext();
            var userStore = new AppUserStore(appDbcontext);
            var userManager = new AppUserManager(userStore);
            AppUser user = userManager.FindById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditProfile(AppUser user)
        {
            var appDbcontext = new AppDBContext();
            var userStore = new AppUserStore(appDbcontext);
            var userManager = new AppUserManager(userStore);
            AppUser user_change = userManager.FindById(user.Id);
            user_change.UserName= user.UserName;
            user_change.Email= user.Email;
            user_change.PhoneNumber=user.PhoneNumber;
            user_change.Address= user.Address;
            user_change.Birthday= user.Birthday;
            user_change.City = user.City;
            appDbcontext.SaveChanges();
            return RedirectToAction("MyProfile", "Account");
        }


    }
}
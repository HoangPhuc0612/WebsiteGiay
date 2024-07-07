using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteGiay.Identity;
using WebsiteGiay.Filter;
namespace WebsiteGiay.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            AppDBContext Db = new AppDBContext();
            List<AppUser> Users = Db.Users.ToList();
            return View(Users);
        }
    }
}
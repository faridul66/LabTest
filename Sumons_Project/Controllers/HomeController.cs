using BJProduction.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using System.Threading;

namespace BJProduction.Controllers
{[Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public HomeController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        private ApplicationDbContext db = new ApplicationDbContext();


        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Picval()
        {
            string userIdq = User.Identity.GetUserId();
            var user = UserManager.FindById(userIdq);
            string Picval = user.PictureFile;
            if (Picval==null || Picval == "")
            {
                string Pic = "Blank-Profile-Pic.PNG";
                return Content(Pic);
            }
            else
            {
                string Pic = Picval;
                return Content(Pic);

            }
            
        }
        public ActionResult FullName()
        {
            string userIdq = User.Identity.GetUserId();
            var user = UserManager.FindById(userIdq);
            string fullname = user.FirstName+" "+user.LastName;
            return Content(fullname);

        }
        public ActionResult FirstName()
        {
            string userIdq = User.Identity.GetUserId();
            var user = UserManager.FindById(userIdq);
            string firstname = user.FirstName;
            return Content(firstname);
        }



        public JsonResult GetCompany()
        {
            return Json(db.Companies, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult GetSite(int id)
        {
            return Json(db.Company_Location.Join(db.Locations, a => a.Locationid, b => b.id, (a, b) => new { Locations = b, Company_Location = a }).Where(x => x.Company_Location.CompanyId == id).Join(db.Locations, a => a.Locations.parent_location, b => b.id, (a, b) => new { Locations = b }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMachine(int[] id)
        {
            var companyId = id[0];
            var siteId = id[1];
            var machines = db.Machines.Where(x => x.Companyid == companyId && x.Locationid==siteId);
            return Json(machines, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetProductId(int id)
        {
            return Json(db.Machine_Product.Include(x=>x.Machine).Include(x=>x.Product_Type).Where(x=>x.Machineid==id).Select(x=>x.Product_Type), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetShiftHour(int id)
        {
            return Json(db.Shifts.FirstOrDefault(x=>x.id==id).duration, JsonRequestBehavior.AllowGet);
        }


    }
}

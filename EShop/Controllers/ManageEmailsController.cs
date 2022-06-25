using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class ManageEmailsController : Controller
    {
        MyEShopEntities db = new MyEShopEntities();

        public ActionResult ActiveEmail()
        {
            return PartialView();
        }

        public ActionResult ActiveUser(string id)
        {
            var user = db.Users.SingleOrDefault(u => u.ActiveCode == id);

            if (user == null)
            {
                return HttpNotFound();
            }
            user.IsActive = true;
            user.ActiveCode = Guid.NewGuid().ToString();
            ViewBag.UserName = user.UserName;
            db.SaveChanges();

            return View();
        }

        public ActionResult RecoveryPassword()
        {
            return PartialView();
        }
    }
}
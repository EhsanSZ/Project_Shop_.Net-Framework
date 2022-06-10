using DataLayer;
using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class AccountController : Controller
    {
        MyEShopEntities db = new MyEShopEntities();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register (RegisterViewModel register)
        {
            return null;
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}
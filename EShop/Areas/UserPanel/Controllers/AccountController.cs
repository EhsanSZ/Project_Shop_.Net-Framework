using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataLayer;
using DataLayer.ViewModels;

namespace EShop.Areas.UserPanel.Controllers
{
    public class AccountController : Controller
    {
        MyEShopEntities db = new MyEShopEntities();

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel change)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Single(u => u.UserName == User.Identity.Name);

                string oldPasswordHash = 
                    FormsAuthentication.HashPasswordForStoringInConfigFile(change.OldPassword, "MD5");

                if (user.Password == oldPasswordHash)
                {
                    string hashNewPassword = 
                        FormsAuthentication.HashPasswordForStoringInConfigFile(change.Password, "MD5");

                    user.Password = hashNewPassword;
                    db.SaveChanges();
                    ViewBag.Success = true;
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "کلمه عبور فعلی درست نمیباشد");
                }
            }
            return View();
        }
    }
}
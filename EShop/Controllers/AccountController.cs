using DataLayer;
using DataLayer.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EShop.Controllers
{
    public class AccountController : Controller
    {
        MyEShopEntities _db = new MyEShopEntities();

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                //Edit by Ajax (#Edit)

                if (_db.Users.Any(u => u.Email == register.Email.Trim().ToLower()))
                {
                    ModelState.AddModelError("Email", "ایمیل وارد شده تکراری است");
                    return View(register);
                }

                if (_db.Users.Any(u => u.UserName == register.UserName))
                {
                    ModelState.AddModelError("UserName", "نام کاربری وارد شده تکراری است");
                    return View(register);
                }

                Users user = new Users()
                {
                    Email = register.Email.Trim().ToLower(),
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5"),
                    ActiveCode = Guid.NewGuid().ToString(),
                    IsActive = false,
                    RegisterDate = DateTime.Now,
                    RoleID = 1,
                    UserName = register.UserName
                };

                _db.Users.Add(user);
                _db.SaveChanges();

                //Send Active Email
                string body = PartialToStringClass.RenderPartialView("ManageEmails", "ActiveEmail", user);
                SendEmail.Send(user.Email, "ایمیل فعال سازی", body);
                //End Send Active Email
                //Add Recaptchar Later (#Edit)

                return View("SuccessRegister", user);
            }
            else
            {
                return View(register);
            }
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login , string ReturnUrl ="/")
        {
            if (ModelState.IsValid)
            {

                string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");
                string email = login.Email.Trim().ToLower();

                var user = _db.Users.SingleOrDefault(u=> u.Email == email && u.Password== hashPassword);

                if (user != null)
                {
                    if (user.IsActive)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, login.RememberMe);
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "حسابی کاربری شما فعال نمیباشد");
                        return View(login);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "حسابی با این مشخصات یافت نشد");
                    return View(login);
                }
            }
            return View(login);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        public ActionResult ActiveUser()
        {
            return View();
        }

    }
}
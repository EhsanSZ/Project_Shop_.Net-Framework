using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class ProductController : Controller
    {
        MyEShopEntities db = new MyEShopEntities();

        public ActionResult ShowGroups()
        {
            return PartialView(db.ProductGroups.ToList());
        }
    }
}
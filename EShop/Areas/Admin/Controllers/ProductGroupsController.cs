using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace EShop.Areas.Admin.Controllers
{
    public class ProductGroupsController : Controller
    {
        private MyEShopEntities db = new MyEShopEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListGroups()
        {
            var productGroups = db.ProductGroups.Where(g => g.ParentID == null);
            return PartialView(productGroups.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroups productGroups = db.ProductGroups.Find(id);
            if (productGroups == null)
            {
                return HttpNotFound();
            }
            return View(productGroups);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle,ParentID")] ProductGroups productGroups)
        {
            if (ModelState.IsValid)
            {
                db.ProductGroups.Add(productGroups);
                db.SaveChanges();
                return PartialView("ListGroups", db.ProductGroups.Where(g => g.ParentID == null));
            }

            ViewBag.ParentID = new SelectList(db.ProductGroups, "GroupID", "GroupTitle", productGroups.ParentID);
            return View(productGroups);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroups productGroups = db.ProductGroups.Find(id);
            if (productGroups == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.ProductGroups, "GroupID", "GroupTitle", productGroups.ParentID);
            return View(productGroups);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle,ParentID")] ProductGroups productGroups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productGroups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentID = new SelectList(db.ProductGroups, "GroupID", "GroupTitle", productGroups.ParentID);
            return View(productGroups);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroups productGroups = db.ProductGroups.Find(id);
            if (productGroups == null)
            {
                return HttpNotFound();
            }
            return View(productGroups);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductGroups productGroups = db.ProductGroups.Find(id);
            db.ProductGroups.Remove(productGroups);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

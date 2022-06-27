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

        // GET: Admin/ProductGroups
        public ActionResult Index()
        {
            var productGroups = db.ProductGroups.Where(g=> g.ParentID == null);
            return View(productGroups.ToList());
        }

        // GET: Admin/ProductGroups/Details/5
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

        // GET: Admin/ProductGroups/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.ProductGroups, "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/ProductGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle,ParentID")] ProductGroups productGroups)
        {
            if (ModelState.IsValid)
            {
                db.ProductGroups.Add(productGroups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentID = new SelectList(db.ProductGroups, "GroupID", "GroupTitle", productGroups.ParentID);
            return View(productGroups);
        }

        // GET: Admin/ProductGroups/Edit/5
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

        // POST: Admin/ProductGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Admin/ProductGroups/Delete/5
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

        // POST: Admin/ProductGroups/Delete/5
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

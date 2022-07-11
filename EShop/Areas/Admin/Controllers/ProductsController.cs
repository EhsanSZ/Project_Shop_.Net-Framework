using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace EShop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private MyEShopEntities db = new MyEShopEntities();

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        public ActionResult Create()
        {
            ViewBag.Groups = db.ProductGroups.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Title,ShortDescription,Text,Price,ImageName,CreateDate")] Products products,List<int> selectedGroups,HttpPostedFileBase imageProduct , string tags)
        {
            if (ModelState.IsValid)
            {
                if (selectedGroups == null)
                {
                    ViewBag.ErrorSelectedGroup = true;
                    ViewBag.Groups = db.ProductGroups.ToList();
                    return View(products);
                }

                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split(',');
                    foreach (string t in tag)
                    {
                        db.Product_Tags.Add(new Product_Tags()
                        {
                            ProductID = products.ProductID ,
                            Tag = t.Trim()
                        });
                    }
                }

                products.ImageName = "images.jpg";
                if(imageProduct != null && imageProduct.IsImage())
                {
                    products.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Images/ProductImages/"+products.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Images/ProductImages/" + products.ImageName),
                        Server.MapPath("/Images/ProductImages/Thumb/" + products.ImageName));
                }

                products.CreateDate = DateTime.Now;
                db.Products.Add(products);

                foreach (var selectGroup in selectedGroups)
                {
                    db.Product_Selected_Groups.Add(new Product_Selected_Groups()
                    {
                        ProductID = products.ProductID ,
                        GroupID = selectGroup
                    });
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Groups = db.ProductGroups.ToList();
            return View(products);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.SelectedGroups = products.Product_Selected_Groups.ToList();
            ViewBag.Groups = db.ProductGroups.ToList();
            ViewBag.Tags = string.Join(",", products.Product_Tags.Select(t=> t.Tag).ToList());
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Title,ShortDescription,Text,Price,ImageName,CreateDate")] Products products, List<int> selectedGroups, HttpPostedFileBase imageProduct, string tags)
        {
            if (ModelState.IsValid)
            {
                if (imageProduct!= null && imageProduct.IsImage())
                {
                    if (products.ImageName != "images.jpg")
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/ProductImages/"+products.ImageName));
                        System.IO.File.Delete(Server.MapPath("/Images/ProductImages/Thumb/" + products.ImageName));
                    }

                    products.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Images/ProductImages/" + products.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Images/ProductImages/" + products.ImageName),
                        Server.MapPath("/Images/ProductImages/Thumb/" + products.ImageName));
                }


                db.Product_Tags.Where(t => t.ProductID == products.ProductID).ToList()
                    .ForEach(t => db.Product_Tags.Remove(t));

                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split(',');
                    foreach (string t in tag)
                    {
                        db.Product_Tags.Add(new Product_Tags()
                        {
                            ProductID = products.ProductID,
                            Tag = t.Trim()
                        });
                    }
                }


                db.Product_Selected_Groups.Where(g => g.ProductID == products.ProductID).ToList()
                    .ForEach(g => db.Product_Selected_Groups.Remove(g));

                foreach (var selectGroup in selectedGroups)
                {
                    db.Product_Selected_Groups.Add(new Product_Selected_Groups()
                    {
                        ProductID = products.ProductID,
                        GroupID = selectGroup
                    });
                }


                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SelectedGroups = selectedGroups;
            ViewBag.Groups = db.ProductGroups.ToList();
            ViewBag.Tags = tags;

            return View(products);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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

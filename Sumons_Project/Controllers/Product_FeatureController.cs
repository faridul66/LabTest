using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BJProduction.Models;

namespace BJProduction.Controllers
{
    public class Product_FeatureController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product_Feature
        public ActionResult Index()
        {
            var product_Feature = db.Product_Feature.Include(p => p.Feature).Include(p => p.Product).Include(p => p.Unit_Measurement);
            return View(product_Feature.ToList());
        }

        // GET: Product_Feature/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Feature product_Feature = db.Product_Feature.Find(id);
            if (product_Feature == null)
            {
                return HttpNotFound();
            }
            return View(product_Feature);
        }

        // GET: Product_Feature/Create
        public ActionResult Create()
        {
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code");
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial");
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code");
            return View();
        }

        // POST: Product_Feature/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Productid,Featureid,Value,Unit_Measurementid,status,chged_by,chgd_date")] Product_Feature product_Feature)
        {
            if (ModelState.IsValid)
            {
                db.Product_Feature.Add(product_Feature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", product_Feature.Featureid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", product_Feature.Productid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", product_Feature.Unit_Measurementid);
            return View(product_Feature);
        }

        // GET: Product_Feature/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Feature product_Feature = db.Product_Feature.Find(id);
            if (product_Feature == null)
            {
                return HttpNotFound();
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", product_Feature.Featureid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", product_Feature.Productid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", product_Feature.Unit_Measurementid);
            return View(product_Feature);
        }

        // POST: Product_Feature/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Productid,Featureid,Value,Unit_Measurementid,status,chged_by,chgd_date")] Product_Feature product_Feature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Feature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", product_Feature.Featureid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", product_Feature.Productid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", product_Feature.Unit_Measurementid);
            return View(product_Feature);
        }

        // GET: Product_Feature/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Feature product_Feature = db.Product_Feature.Find(id);
            if (product_Feature == null)
            {
                return HttpNotFound();
            }
            return View(product_Feature);
        }

        // POST: Product_Feature/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Feature product_Feature = db.Product_Feature.Find(id);
            db.Product_Feature.Remove(product_Feature);
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

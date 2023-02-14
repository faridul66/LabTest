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
    public class ProductType_FeatureTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductType_FeatureType
        public ActionResult Index()
        {
            var productType_FeatureType = db.ProductType_FeatureType.Include(p => p.Feature_Type).Include(p => p.Product_Type);
            return View(productType_FeatureType.ToList());
        }

        // GET: ProductType_FeatureType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType_FeatureType productType_FeatureType = db.ProductType_FeatureType.Find(id);
            if (productType_FeatureType == null)
            {
                return HttpNotFound();
            }
            return View(productType_FeatureType);
        }

        // GET: ProductType_FeatureType/Create
        public ActionResult Create()
        {
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code");
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code");
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code");
            return View();
        }

        // POST: ProductType_FeatureType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Product_Typeid,Featureid,Unit_Measurementid,status,chged_by,chgd_date")] ProductType_FeatureType productType_FeatureType)
        {
            if (ModelState.IsValid)
            {
                db.ProductType_FeatureType.Add(productType_FeatureType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", productType_FeatureType.Feature_Typeid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", productType_FeatureType.Product_Typeid);
            return View(productType_FeatureType);
        }

        // GET: ProductType_FeatureType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType_FeatureType productType_FeatureType = db.ProductType_FeatureType.Find(id);
            if (productType_FeatureType == null)
            {
                return HttpNotFound();
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", productType_FeatureType.Feature_Typeid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", productType_FeatureType.Product_Typeid);
            return View(productType_FeatureType);
        }

        // POST: ProductType_FeatureType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Product_Typeid,Featureid,Unit_Measurementid,status,chged_by,chgd_date")] ProductType_FeatureType productType_FeatureType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productType_FeatureType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", productType_FeatureType.Feature_Typeid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", productType_FeatureType.Product_Typeid);
            return View(productType_FeatureType);
        }

        // GET: ProductType_FeatureType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType_FeatureType productType_FeatureType = db.ProductType_FeatureType.Find(id);
            if (productType_FeatureType == null)
            {
                return HttpNotFound();
            }
            return View(productType_FeatureType);
        }

        // POST: ProductType_FeatureType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductType_FeatureType productType_FeatureType = db.ProductType_FeatureType.Find(id);
            db.ProductType_FeatureType.Remove(productType_FeatureType);
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

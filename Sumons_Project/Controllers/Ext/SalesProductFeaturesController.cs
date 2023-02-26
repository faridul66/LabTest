using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BJProduction.Models;

namespace BJProduction.Controllers.Ext
{
    public class SalesProductFeaturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SalesProductFeatures
        public ActionResult Index()
        {
            return View(db.SalesProductFeatures.ToList());
        }

        // GET: SalesProductFeatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesProductFeatures salesProductFeatures = db.SalesProductFeatures.Find(id);
            if (salesProductFeatures == null)
            {
                return HttpNotFound();
            }
            return View(salesProductFeatures);
        }

        // GET: SalesProductFeatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesProductFeatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderNo,ProductTypeId,FeatureTypeId,FearureId,UnitId,TxtValue,CompanyId,LotNumber")] SalesProductFeatures salesProductFeatures)
        {
            if (ModelState.IsValid)
            {
                db.SalesProductFeatures.Add(salesProductFeatures);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesProductFeatures);
        }

        // GET: SalesProductFeatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesProductFeatures salesProductFeatures = db.SalesProductFeatures.Find(id);
            if (salesProductFeatures == null)
            {
                return HttpNotFound();
            }
            return View(salesProductFeatures);
        }

        // POST: SalesProductFeatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderNo,ProductTypeId,FeatureTypeId,FearureId,UnitId,TxtValue,CompanyId,LotNumber")] SalesProductFeatures salesProductFeatures)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesProductFeatures).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesProductFeatures);
        }

        // GET: SalesProductFeatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesProductFeatures salesProductFeatures = db.SalesProductFeatures.Find(id);
            if (salesProductFeatures == null)
            {
                return HttpNotFound();
            }
            return View(salesProductFeatures);
        }

        // POST: SalesProductFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesProductFeatures salesProductFeatures = db.SalesProductFeatures.Find(id);
            db.SalesProductFeatures.Remove(salesProductFeatures);
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

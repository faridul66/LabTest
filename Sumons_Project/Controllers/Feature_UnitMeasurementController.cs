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
    public class Feature_UnitMeasurementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Feature_UnitMeasurement
        public ActionResult Index()
        {
            var feature_UnitMeasurement = db.Feature_UnitMeasurement.Include(f => f.Feature).Include(f => f.Unit_Measurement);
            return View(feature_UnitMeasurement.ToList());
        }

        // GET: Feature_UnitMeasurement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature_UnitMeasurement feature_UnitMeasurement = db.Feature_UnitMeasurement.Find(id);
            if (feature_UnitMeasurement == null)
            {
                return HttpNotFound();
            }
            return View(feature_UnitMeasurement);
        }

        // GET: Feature_UnitMeasurement/Create
        public ActionResult Create()
        {
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code");
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code");
            return View();
        }

        // POST: Feature_UnitMeasurement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Featureid,Unit_Measurementid,status,chged_by,chgd_date")] Feature_UnitMeasurement feature_UnitMeasurement)
        {
            if (ModelState.IsValid)
            {
                db.Feature_UnitMeasurement.Add(feature_UnitMeasurement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", feature_UnitMeasurement.Featureid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", feature_UnitMeasurement.Unit_Measurementid);
            return View(feature_UnitMeasurement);
        }

        // GET: Feature_UnitMeasurement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature_UnitMeasurement feature_UnitMeasurement = db.Feature_UnitMeasurement.Find(id);
            if (feature_UnitMeasurement == null)
            {
                return HttpNotFound();
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", feature_UnitMeasurement.Featureid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", feature_UnitMeasurement.Unit_Measurementid);
            return View(feature_UnitMeasurement);
        }

        // POST: Feature_UnitMeasurement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Featureid,Unit_Measurementid,status,chged_by,chgd_date")] Feature_UnitMeasurement feature_UnitMeasurement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feature_UnitMeasurement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", feature_UnitMeasurement.Featureid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", feature_UnitMeasurement.Unit_Measurementid);
            return View(feature_UnitMeasurement);
        }

        // GET: Feature_UnitMeasurement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature_UnitMeasurement feature_UnitMeasurement = db.Feature_UnitMeasurement.Find(id);
            if (feature_UnitMeasurement == null)
            {
                return HttpNotFound();
            }
            return View(feature_UnitMeasurement);
        }

        // POST: Feature_UnitMeasurement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feature_UnitMeasurement feature_UnitMeasurement = db.Feature_UnitMeasurement.Find(id);
            db.Feature_UnitMeasurement.Remove(feature_UnitMeasurement);
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

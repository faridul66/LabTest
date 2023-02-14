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
    public class Temp_FeatureController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Temp_Feature
        public ActionResult Index()
        {
            var temp_Feature = db.Temp_Feature.Include(t => t.Feature).Include(t => t.Feature_Type).Include(t => t.Transaction_Type).Include(t => t.Unit_Measurement);
            return View(temp_Feature.ToList());
        }

        // GET: Temp_Feature/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temp_Feature temp_Feature = db.Temp_Feature.Find(id);
            if (temp_Feature == null)
            {
                return HttpNotFound();
            }
            return View(temp_Feature);
        }

        // GET: Temp_Feature/Create
        public ActionResult Create()
        {
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code");
            ViewBag.Feature_Typeid = new SelectList(db.Feature_Type, "id", "type_code");
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code");
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code");
            return View();
        }

        // POST: Temp_Feature/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Transaction_Typeid,Orderid,Lot,Featureid,Feature_Typeid,FeatureValue,Unit_Measurementid")] Temp_Feature temp_Feature)
        {
            if (ModelState.IsValid)
            {
                db.Temp_Feature.Add(temp_Feature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", temp_Feature.Featureid);
            ViewBag.Feature_Typeid = new SelectList(db.Feature_Type, "id", "type_code", temp_Feature.Feature_Typeid);
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code", temp_Feature.Transaction_Typeid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", temp_Feature.Unit_Measurementid);
            return View(temp_Feature);
        }

        // GET: Temp_Feature/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temp_Feature temp_Feature = db.Temp_Feature.Find(id);
            if (temp_Feature == null)
            {
                return HttpNotFound();
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", temp_Feature.Featureid);
            ViewBag.Feature_Typeid = new SelectList(db.Feature_Type, "id", "type_code", temp_Feature.Feature_Typeid);
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code", temp_Feature.Transaction_Typeid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", temp_Feature.Unit_Measurementid);
            return View(temp_Feature);
        }

        // POST: Temp_Feature/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Transaction_Typeid,Orderid,Lot,Featureid,Feature_Typeid,FeatureValue,Unit_Measurementid")] Temp_Feature temp_Feature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temp_Feature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", temp_Feature.Featureid);
            ViewBag.Feature_Typeid = new SelectList(db.Feature_Type, "id", "type_code", temp_Feature.Feature_Typeid);
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code", temp_Feature.Transaction_Typeid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", temp_Feature.Unit_Measurementid);
            return View(temp_Feature);
        }

        // GET: Temp_Feature/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temp_Feature temp_Feature = db.Temp_Feature.Find(id);
            if (temp_Feature == null)
            {
                return HttpNotFound();
            }
            return View(temp_Feature);
        }

        // POST: Temp_Feature/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Temp_Feature temp_Feature = db.Temp_Feature.Find(id);
            db.Temp_Feature.Remove(temp_Feature);
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

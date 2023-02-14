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
    public class Unit_MeasurementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Unit_Measurement
        public ActionResult Index()
        {
            return View(db.Unit_Measurement.ToList());
        }

        // GET: Unit_Measurement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit_Measurement unit_Measurement = db.Unit_Measurement.Find(id);
            if (unit_Measurement == null)
            {
                return HttpNotFound();
            }
            return View(unit_Measurement);
        }

        // GET: Unit_Measurement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unit_Measurement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,parent_id,code,name,parent_sum,status,chged_by,chgd_date")] Unit_Measurement unit_Measurement)
        {
            if (ModelState.IsValid)
            {
                db.Unit_Measurement.Add(unit_Measurement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit_Measurement);
        }

        // GET: Unit_Measurement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit_Measurement unit_Measurement = db.Unit_Measurement.Find(id);
            if (unit_Measurement == null)
            {
                return HttpNotFound();
            }
            return View(unit_Measurement);
        }

        // POST: Unit_Measurement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,parent_id,code,name,parent_sum,status,chged_by,chgd_date")] Unit_Measurement unit_Measurement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit_Measurement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit_Measurement);
        }

        // GET: Unit_Measurement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit_Measurement unit_Measurement = db.Unit_Measurement.Find(id);
            if (unit_Measurement == null)
            {
                return HttpNotFound();
            }
            return View(unit_Measurement);
        }

        // POST: Unit_Measurement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit_Measurement unit_Measurement = db.Unit_Measurement.Find(id);
            db.Unit_Measurement.Remove(unit_Measurement);
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

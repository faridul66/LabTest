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
    public class TransferProductFeaturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TransferProductFeatures
        public ActionResult Index()
        {
            return View(db.TransferProductFeatures.ToList());
        }

        // GET: TransferProductFeatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferProductFeatures transferProductFeatures = db.TransferProductFeatures.Find(id);
            if (transferProductFeatures == null)
            {
                return HttpNotFound();
            }
            return View(transferProductFeatures);
        }

        // GET: TransferProductFeatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransferProductFeatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderId,ProdyctTypeId,FearureId,UnitId,TxtValue")] TransferProductFeatures transferProductFeatures)
        {
            if (ModelState.IsValid)
            {
                db.TransferProductFeatures.Add(transferProductFeatures);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transferProductFeatures);
        }

        // GET: TransferProductFeatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferProductFeatures transferProductFeatures = db.TransferProductFeatures.Find(id);
            if (transferProductFeatures == null)
            {
                return HttpNotFound();
            }
            return View(transferProductFeatures);
        }

        // POST: TransferProductFeatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderId,ProdyctTypeId,FearureId,UnitId,TxtValue")] TransferProductFeatures transferProductFeatures)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transferProductFeatures).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transferProductFeatures);
        }

        // GET: TransferProductFeatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferProductFeatures transferProductFeatures = db.TransferProductFeatures.Find(id);
            if (transferProductFeatures == null)
            {
                return HttpNotFound();
            }
            return View(transferProductFeatures);
        }

        // POST: TransferProductFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransferProductFeatures transferProductFeatures = db.TransferProductFeatures.Find(id);
            db.TransferProductFeatures.Remove(transferProductFeatures);
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

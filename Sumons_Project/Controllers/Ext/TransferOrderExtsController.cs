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
    public class TransferOrderExtsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TransferOrderExts
        public ActionResult Index()
        {
            return View(db.TransferOrderExts.ToList());
        }

        // GET: TransferOrderExts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferOrderExt transferOrderExt = db.TransferOrderExts.Find(id);
            if (transferOrderExt == null)
            {
                return HttpNotFound();
            }
            return View(transferOrderExt);
        }

        // GET: TransferOrderExts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransferOrderExts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FromSite,FromWarehouse,ToSite,ToWarehouse")] TransferOrderExt transferOrderExt)
        {
            if (ModelState.IsValid)
            {
                db.TransferOrderExts.Add(transferOrderExt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transferOrderExt);
        }

        // GET: TransferOrderExts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferOrderExt transferOrderExt = db.TransferOrderExts.Find(id);
            if (transferOrderExt == null)
            {
                return HttpNotFound();
            }
            return View(transferOrderExt);
        }

        // POST: TransferOrderExts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FromSite,FromWarehouse,ToSite,ToWarehouse")] TransferOrderExt transferOrderExt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transferOrderExt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transferOrderExt);
        }

        // GET: TransferOrderExts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferOrderExt transferOrderExt = db.TransferOrderExts.Find(id);
            if (transferOrderExt == null)
            {
                return HttpNotFound();
            }
            return View(transferOrderExt);
        }

        // POST: TransferOrderExts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransferOrderExt transferOrderExt = db.TransferOrderExts.Find(id);
            db.TransferOrderExts.Remove(transferOrderExt);
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

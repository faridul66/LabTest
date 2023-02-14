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
    public class ResidualsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Residuals
        public ActionResult Index()
        {
            return View(db.Residuals.ToList());
        }

        // GET: Residuals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residuals residuals = db.Residuals.Find(id);
            if (residuals == null)
            {
                return HttpNotFound();
            }
            return View(residuals);
        }

        // GET: Residuals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Residuals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LedgerId,ProductId,ProductTypeId,ResidualValue,PreviousValue,UnitId")] Residuals residuals)
        {
            if (ModelState.IsValid)
            {
                db.Residuals.Add(residuals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(residuals);
        }

        // GET: Residuals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residuals residuals = db.Residuals.Find(id);
            if (residuals == null)
            {
                return HttpNotFound();
            }
            return View(residuals);
        }

        // POST: Residuals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LedgerId,ProductId,ProductTypeId,ResidualValue,PreviousValue,UnitId")] Residuals residuals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(residuals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(residuals);
        }

        // GET: Residuals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residuals residuals = db.Residuals.Find(id);
            if (residuals == null)
            {
                return HttpNotFound();
            }
            return View(residuals);
        }

        // POST: Residuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Residuals residuals = db.Residuals.Find(id);
            db.Residuals.Remove(residuals);
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

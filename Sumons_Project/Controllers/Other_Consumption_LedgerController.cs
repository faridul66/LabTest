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
    public class Other_Consumption_LedgerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Other_Consumption_Ledger
        public ActionResult Index()
        {
            var other_Consumption_Ledger = db.Other_Consumption_Ledger.Include(o => o.Product);
            return View(other_Consumption_Ledger.ToList());
        }

        // GET: Other_Consumption_Ledger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Consumption_Ledger other_Consumption_Ledger = db.Other_Consumption_Ledger.Find(id);
            if (other_Consumption_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(other_Consumption_Ledger);
        }

        // GET: Other_Consumption_Ledger/Create
        public ActionResult Create()
        {
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial");
            return View();
        }

        // POST: Other_Consumption_Ledger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Productid,cons_count,other_consumption_id,from_warehouse_id,consumption_date,status,chged_by,chgd_date")] Other_Consumption_Ledger other_Consumption_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Other_Consumption_Ledger.Add(other_Consumption_Ledger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", other_Consumption_Ledger.Productid);
            return View(other_Consumption_Ledger);
        }

        // GET: Other_Consumption_Ledger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Consumption_Ledger other_Consumption_Ledger = db.Other_Consumption_Ledger.Find(id);
            if (other_Consumption_Ledger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", other_Consumption_Ledger.Productid);
            return View(other_Consumption_Ledger);
        }

        // POST: Other_Consumption_Ledger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Productid,cons_count,other_consumption_id,from_warehouse_id,consumption_date,status,chged_by,chgd_date")] Other_Consumption_Ledger other_Consumption_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(other_Consumption_Ledger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", other_Consumption_Ledger.Productid);
            return View(other_Consumption_Ledger);
        }

        // GET: Other_Consumption_Ledger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Consumption_Ledger other_Consumption_Ledger = db.Other_Consumption_Ledger.Find(id);
            if (other_Consumption_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(other_Consumption_Ledger);
        }

        // POST: Other_Consumption_Ledger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Other_Consumption_Ledger other_Consumption_Ledger = db.Other_Consumption_Ledger.Find(id);
            db.Other_Consumption_Ledger.Remove(other_Consumption_Ledger);
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

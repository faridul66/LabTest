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
    public class Transfer_LedgerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transfer_Ledger
        public ActionResult Index()
        {
            var transfer_Ledger = db.Transfer_Ledger.Include(t => t.Product);
            return View(transfer_Ledger.ToList());
        }

        // GET: Transfer_Ledger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer_Ledger transfer_Ledger = db.Transfer_Ledger.Find(id);
            if (transfer_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(transfer_Ledger);
        }

        // GET: Transfer_Ledger/Create
        public ActionResult Create()
        {
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial");
            return View();
        }

        // POST: Transfer_Ledger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Productid,tr_count,transfer_order_id,to_warehouse_id,arrival_date,status,chged_by,chgd_date")] Transfer_Ledger transfer_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Transfer_Ledger.Add(transfer_Ledger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", transfer_Ledger.Productid);
            return View(transfer_Ledger);
        }

        // GET: Transfer_Ledger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer_Ledger transfer_Ledger = db.Transfer_Ledger.Find(id);
            if (transfer_Ledger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", transfer_Ledger.Productid);
            return View(transfer_Ledger);
        }

        // POST: Transfer_Ledger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Productid,tr_count,transfer_order_id,to_warehouse_id,arrival_date,status,chged_by,chgd_date")] Transfer_Ledger transfer_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transfer_Ledger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", transfer_Ledger.Productid);
            return View(transfer_Ledger);
        }

        // GET: Transfer_Ledger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer_Ledger transfer_Ledger = db.Transfer_Ledger.Find(id);
            if (transfer_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(transfer_Ledger);
        }

        // POST: Transfer_Ledger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transfer_Ledger transfer_Ledger = db.Transfer_Ledger.Find(id);
            db.Transfer_Ledger.Remove(transfer_Ledger);
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

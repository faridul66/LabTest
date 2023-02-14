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
    public class Purchase_LedgerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Purchase_Ledger
        public ActionResult Index()
        {
            var purchase_Ledger = db.Purchase_Ledger.Include(p => p.Location).Include(p => p.Product).Include(p => p.Purchase_Order);
            return View(purchase_Ledger.ToList());
        }

        // GET: Purchase_Ledger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Ledger purchase_Ledger = db.Purchase_Ledger.Find(id);
            if (purchase_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(purchase_Ledger);
        }

        // GET: Purchase_Ledger/Create
        public ActionResult Create()
        {
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name");
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial");
            ViewBag.Purchase_Orderid = new SelectList(db.Purchase_Order, "id", "order_no");
            return View();
        }

        // POST: Purchase_Ledger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Productid,pur_count,Locationid,arrival_date,Purchase_Orderid,status,chged_by,chgd_date")] Purchase_Ledger purchase_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Purchase_Ledger.Add(purchase_Ledger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", purchase_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", purchase_Ledger.Productid);
            ViewBag.Purchase_Orderid = new SelectList(db.Purchase_Order, "id", "order_no", purchase_Ledger.Purchase_Orderid);
            return View(purchase_Ledger);
        }

        // GET: Purchase_Ledger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Ledger purchase_Ledger = db.Purchase_Ledger.Find(id);
            if (purchase_Ledger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", purchase_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", purchase_Ledger.Productid);
            ViewBag.Purchase_Orderid = new SelectList(db.Purchase_Order, "id", "order_no", purchase_Ledger.Purchase_Orderid);
            return View(purchase_Ledger);
        }

        // POST: Purchase_Ledger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Productid,pur_count,Locationid,arrival_date,Purchase_Orderid,status,chged_by,chgd_date")] Purchase_Ledger purchase_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase_Ledger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", purchase_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", purchase_Ledger.Productid);
            ViewBag.Purchase_Orderid = new SelectList(db.Purchase_Order, "id", "order_no", purchase_Ledger.Purchase_Orderid);
            return View(purchase_Ledger);
        }

        // GET: Purchase_Ledger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Ledger purchase_Ledger = db.Purchase_Ledger.Find(id);
            if (purchase_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(purchase_Ledger);
        }

        // POST: Purchase_Ledger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase_Ledger purchase_Ledger = db.Purchase_Ledger.Find(id);
            db.Purchase_Ledger.Remove(purchase_Ledger);
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

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
    public class Return_LedgerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Return_Ledger
        public ActionResult Index()
        {
            var return_Ledger = db.Return_Ledger.Include(r => r.Location).Include(r => r.Product).Include(r => r.ReturnOrder);
            return View(return_Ledger.ToList());
        }

        // GET: Return_Ledger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return_Ledger return_Ledger = db.Return_Ledger.Find(id);
            if (return_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(return_Ledger);
        }

        // GET: Return_Ledger/Create
        public ActionResult Create()
        {
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name");
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial");
            ViewBag.Return_Orderid = new SelectList(db.Return_Order, "id", "return_order_code");
            return View();
        }

        // POST: Return_Ledger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Productid,Return_Orderid,Locationid,actual_return_date,return_value,status,chged_by,chgd_date")] Return_Ledger return_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Return_Ledger.Add(return_Ledger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", return_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", return_Ledger.Productid);
            ViewBag.Return_Orderid = new SelectList(db.Return_Order, "id", "return_order_code", return_Ledger.Return_Orderid);
            return View(return_Ledger);
        }

        // GET: Return_Ledger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return_Ledger return_Ledger = db.Return_Ledger.Find(id);
            if (return_Ledger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", return_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", return_Ledger.Productid);
            ViewBag.Return_Orderid = new SelectList(db.Return_Order, "id", "return_order_code", return_Ledger.Return_Orderid);
            return View(return_Ledger);
        }

        // POST: Return_Ledger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Productid,Return_Orderid,Locationid,actual_return_date,return_value,status,chged_by,chgd_date")] Return_Ledger return_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(return_Ledger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", return_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", return_Ledger.Productid);
            ViewBag.Return_Orderid = new SelectList(db.Return_Order, "id", "return_order_code", return_Ledger.Return_Orderid);
            return View(return_Ledger);
        }

        // GET: Return_Ledger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return_Ledger return_Ledger = db.Return_Ledger.Find(id);
            if (return_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(return_Ledger);
        }

        // POST: Return_Ledger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Return_Ledger return_Ledger = db.Return_Ledger.Find(id);
            db.Return_Ledger.Remove(return_Ledger);
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

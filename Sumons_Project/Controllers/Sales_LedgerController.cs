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
    public class Sales_LedgerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sales_Ledger
        public ActionResult Index()
        {
            var sales_Ledger = db.Sales_Ledger.Include(s => s.Location).Include(s => s.Product).Include(s => s.Sales_Order);
            return View(sales_Ledger.ToList());
        }

        // GET: Sales_Ledger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Ledger sales_Ledger = db.Sales_Ledger.Find(id);
            if (sales_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(sales_Ledger);
        }

        // GET: Sales_Ledger/Create
        public ActionResult Create()
        {
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name");
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial");
            ViewBag.Sales_Orderid = new SelectList(db.Sales_Order, "id", "order_no");
            return View();
        }

        // POST: Sales_Ledger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Productid,sale_count,Locationid,delivery_date,Sales_Orderid,status,chged_by,chgd_date")] Sales_Ledger sales_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Sales_Ledger.Add(sales_Ledger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", sales_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", sales_Ledger.Productid);
            ViewBag.Sales_Orderid = new SelectList(db.Sales_Order, "id", "order_no", sales_Ledger.Sales_Orderid);
            return View(sales_Ledger);
        }

        // GET: Sales_Ledger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Ledger sales_Ledger = db.Sales_Ledger.Find(id);
            if (sales_Ledger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", sales_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", sales_Ledger.Productid);
            ViewBag.Sales_Orderid = new SelectList(db.Sales_Order, "id", "order_no", sales_Ledger.Sales_Orderid);
            return View(sales_Ledger);
        }

        // POST: Sales_Ledger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Productid,sale_count,Locationid,delivery_date,Sales_Orderid,status,chged_by,chgd_date")] Sales_Ledger sales_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales_Ledger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", sales_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", sales_Ledger.Productid);
            ViewBag.Sales_Orderid = new SelectList(db.Sales_Order, "id", "order_no", sales_Ledger.Sales_Orderid);
            return View(sales_Ledger);
        }

        // GET: Sales_Ledger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Ledger sales_Ledger = db.Sales_Ledger.Find(id);
            if (sales_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(sales_Ledger);
        }

        // POST: Sales_Ledger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sales_Ledger sales_Ledger = db.Sales_Ledger.Find(id);
            db.Sales_Ledger.Remove(sales_Ledger);
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

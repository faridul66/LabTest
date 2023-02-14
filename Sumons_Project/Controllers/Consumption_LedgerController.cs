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
    public class Consumption_LedgerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consumption_Ledger
        public ActionResult Index()
        {
            var consumption_Ledger = db.Consumption_Ledger.Include(c => c.Location).Include(c => c.Product).Include(c => c.Production_Indent);
            return View(consumption_Ledger.ToList());
        }

        // GET: Consumption_Ledger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumption_Ledger consumption_Ledger = db.Consumption_Ledger.Find(id);
            if (consumption_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(consumption_Ledger);
        }

        // GET: Consumption_Ledger/Create
        public ActionResult Create()
        {
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name");
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial");
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no");
            return View();
        }

        // POST: Consumption_Ledger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Productid,prod_count,Production_Indentid,Locationid,consumption_date,status,chged_by,chgd_date")] Consumption_Ledger consumption_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Consumption_Ledger.Add(consumption_Ledger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", consumption_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", consumption_Ledger.Productid);
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", consumption_Ledger.Production_Indentid);
            return View(consumption_Ledger);
        }

        // GET: Consumption_Ledger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumption_Ledger consumption_Ledger = db.Consumption_Ledger.Find(id);
            if (consumption_Ledger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", consumption_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", consumption_Ledger.Productid);
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", consumption_Ledger.Production_Indentid);
            return View(consumption_Ledger);
        }

        // POST: Consumption_Ledger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Productid,prod_count,Production_Indentid,Locationid,consumption_date,status,chged_by,chgd_date")] Consumption_Ledger consumption_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumption_Ledger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", consumption_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", consumption_Ledger.Productid);
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", consumption_Ledger.Production_Indentid);
            return View(consumption_Ledger);
        }

        // GET: Consumption_Ledger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumption_Ledger consumption_Ledger = db.Consumption_Ledger.Find(id);
            if (consumption_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(consumption_Ledger);
        }

        // POST: Consumption_Ledger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumption_Ledger consumption_Ledger = db.Consumption_Ledger.Find(id);
            db.Consumption_Ledger.Remove(consumption_Ledger);
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

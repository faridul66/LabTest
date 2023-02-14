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
    public class Production_LedgerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Production_Ledger
        public ActionResult Index()
        {
            var production_Ledger = db.Production_Ledger.Include(p => p.Location).Include(p => p.Product).Include(p => p.Production_Indent);
            return View(production_Ledger.ToList());
        }

        // GET: Production_Ledger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production_Ledger production_Ledger = db.Production_Ledger.Find(id);
            if (production_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(production_Ledger);
        }

        // GET: Production_Ledger/Create
        public ActionResult Create()
        {
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name");
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial");
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no");
            return View();
        }

        // POST: Production_Ledger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Productid,prod_count,Production_Indentid,Locationid,production_date,status,chged_by,chgd_date")] Production_Ledger production_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Production_Ledger.Add(production_Ledger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", production_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", production_Ledger.Productid);
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", production_Ledger.Production_Indentid);
            return View(production_Ledger);
        }

        // GET: Production_Ledger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production_Ledger production_Ledger = db.Production_Ledger.Find(id);
            if (production_Ledger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", production_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", production_Ledger.Productid);
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", production_Ledger.Production_Indentid);
            return View(production_Ledger);
        }

        // POST: Production_Ledger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Productid,prod_count,Production_Indentid,Locationid,production_date,status,chged_by,chgd_date")] Production_Ledger production_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(production_Ledger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", production_Ledger.Locationid);
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", production_Ledger.Productid);
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", production_Ledger.Production_Indentid);
            return View(production_Ledger);
        }

        // GET: Production_Ledger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production_Ledger production_Ledger = db.Production_Ledger.Find(id);
            if (production_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(production_Ledger);
        }

        // POST: Production_Ledger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Production_Ledger production_Ledger = db.Production_Ledger.Find(id);
            db.Production_Ledger.Remove(production_Ledger);
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

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
    public class General_LedgerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: General_Ledger
        public ActionResult Index()
        {
            var general_Ledger = db.General_Ledger.Include(g => g.Product).Include(g => g.Transaction_Type);
            return View(general_Ledger.ToList());
        }

        // GET: General_Ledger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General_Ledger general_Ledger = db.General_Ledger.Find(id);
            if (general_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(general_Ledger);
        }

        // GET: General_Ledger/Create
        public ActionResult Create()
        {
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial");
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code");
            return View();
        }

        // POST: General_Ledger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Productid,Transaction_Typeid,trans_ref_id,trans_date,is_current,status,chged_by,chgd_date")] General_Ledger general_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.General_Ledger.Add(general_Ledger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", general_Ledger.Productid);
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code", general_Ledger.Transaction_Typeid);
            return View(general_Ledger);
        }

        // GET: General_Ledger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General_Ledger general_Ledger = db.General_Ledger.Find(id);
            if (general_Ledger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", general_Ledger.Productid);
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code", general_Ledger.Transaction_Typeid);
            return View(general_Ledger);
        }

        // POST: General_Ledger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Productid,Transaction_Typeid,trans_ref_id,trans_date,is_current,status,chged_by,chgd_date")] General_Ledger general_Ledger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(general_Ledger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Productid = new SelectList(db.Products, "id", "product_serial", general_Ledger.Productid);
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code", general_Ledger.Transaction_Typeid);
            return View(general_Ledger);
        }

        // GET: General_Ledger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General_Ledger general_Ledger = db.General_Ledger.Find(id);
            if (general_Ledger == null)
            {
                return HttpNotFound();
            }
            return View(general_Ledger);
        }

        // POST: General_Ledger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            General_Ledger general_Ledger = db.General_Ledger.Find(id);
            db.General_Ledger.Remove(general_Ledger);
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

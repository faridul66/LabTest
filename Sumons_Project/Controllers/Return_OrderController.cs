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
    public class Return_OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Return_Order
        public ActionResult Index()
        {
            var return_Order = db.Return_Order.Include(r => r.Company).Include(r => r.Feature).Include(r => r.TransactionType).Include(r => r.UnitMeasurement);
            return View(return_Order.ToList());
        }

        // GET: Return_Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return_Order return_Order = db.Return_Order.Find(id);
            if (return_Order == null)
            {
                return HttpNotFound();
            }
            return View(return_Order);
        }

        // GET: Return_Order/Create
        public ActionResult Create()
        {
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code");
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code");
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code");
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code");
            return View();
        }

        // POST: Return_Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Companyid,Transaction_Typeid,return_date,qty,Featureid,Unit_Measurementid,return_order_code,description,status,chged_by,chgd_date")] Return_Order return_Order)
        {
            if (ModelState.IsValid)
            {
                db.Return_Order.Add(return_Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", return_Order.Companyid);
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", return_Order.Featureid);
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code", return_Order.Transaction_Typeid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", return_Order.Unit_Measurementid);
            return View(return_Order);
        }

        // GET: Return_Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return_Order return_Order = db.Return_Order.Find(id);
            if (return_Order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", return_Order.Companyid);
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", return_Order.Featureid);
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code", return_Order.Transaction_Typeid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", return_Order.Unit_Measurementid);
            return View(return_Order);
        }

        // POST: Return_Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Companyid,Transaction_Typeid,return_date,qty,Featureid,Unit_Measurementid,return_order_code,description,status,chged_by,chgd_date")] Return_Order return_Order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(return_Order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", return_Order.Companyid);
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", return_Order.Featureid);
            ViewBag.Transaction_Typeid = new SelectList(db.Transaction_Type, "id", "type_code", return_Order.Transaction_Typeid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", return_Order.Unit_Measurementid);
            return View(return_Order);
        }

        // GET: Return_Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Return_Order return_Order = db.Return_Order.Find(id);
            if (return_Order == null)
            {
                return HttpNotFound();
            }
            return View(return_Order);
        }

        // POST: Return_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Return_Order return_Order = db.Return_Order.Find(id);
            db.Return_Order.Remove(return_Order);
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

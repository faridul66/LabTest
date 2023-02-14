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
    public class Other_ConsumptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Other_Consumption
        public ActionResult Index()
        {
            var other_Consumption = db.Other_Consumption.Include(o => o.Company);
            return View(other_Consumption.ToList());
        }

        // GET: Other_Consumption/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Consumption other_Consumption = db.Other_Consumption.Find(id);
            if (other_Consumption == null)
            {
                return HttpNotFound();
            }
            return View(other_Consumption);
        }

        // GET: Other_Consumption/Create
        public ActionResult Create()
        {
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code");
            return View();
        }

        // POST: Other_Consumption/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type_code,type_name,Companyid,product_type,other_type,qty,cons_feature,cons_count,cons_unit,description,other_start_date,status,chged_by,chgd_date")] Other_Consumption other_Consumption)
        {
            if (ModelState.IsValid)
            {
                db.Other_Consumption.Add(other_Consumption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", other_Consumption.Companyid);
            return View(other_Consumption);
        }

        // GET: Other_Consumption/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Consumption other_Consumption = db.Other_Consumption.Find(id);
            if (other_Consumption == null)
            {
                return HttpNotFound();
            }
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", other_Consumption.Companyid);
            return View(other_Consumption);
        }

        // POST: Other_Consumption/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type_code,type_name,Companyid,product_type,other_type,qty,cons_feature,cons_count,cons_unit,description,other_start_date,status,chged_by,chgd_date")] Other_Consumption other_Consumption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(other_Consumption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", other_Consumption.Companyid);
            return View(other_Consumption);
        }

        // GET: Other_Consumption/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Consumption other_Consumption = db.Other_Consumption.Find(id);
            if (other_Consumption == null)
            {
                return HttpNotFound();
            }
            return View(other_Consumption);
        }

        // POST: Other_Consumption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Other_Consumption other_Consumption = db.Other_Consumption.Find(id);
            db.Other_Consumption.Remove(other_Consumption);
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

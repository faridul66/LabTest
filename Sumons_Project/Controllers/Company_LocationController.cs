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
    public class Company_LocationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Company_Location
        public ActionResult Index()
        {
            var company_Location = db.Company_Location.Include(c => c.Company).Include(c => c.Location);
            return View(company_Location.ToList());
        }

        // GET: Company_Location/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Location company_Location = db.Company_Location.Find(id);
            if (company_Location == null)
            {
                return HttpNotFound();
            }
            return View(company_Location);
        }

        // GET: Company_Location/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Company_Code");
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name");
            return View();
        }

        // POST: Company_Location/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,Locationid,status,Chged_by,chgd_date")] Company_Location company_Location)
        {
            if (ModelState.IsValid)
            {
                db.Company_Location.Add(company_Location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Company_Code", company_Location.CompanyId);
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", company_Location.Locationid);
            return View(company_Location);
        }

        // GET: Company_Location/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Location company_Location = db.Company_Location.Find(id);
            if (company_Location == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Company_Code", company_Location.CompanyId);
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", company_Location.Locationid);
            return View(company_Location);
        }

        // POST: Company_Location/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyId,Locationid,status,Chged_by,chgd_date")] Company_Location company_Location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Company_Code", company_Location.CompanyId);
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", company_Location.Locationid);
            return View(company_Location);
        }

        // GET: Company_Location/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Location company_Location = db.Company_Location.Find(id);
            if (company_Location == null)
            {
                return HttpNotFound();
            }
            return View(company_Location);
        }

        // POST: Company_Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company_Location company_Location = db.Company_Location.Find(id);
            db.Company_Location.Remove(company_Location);
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

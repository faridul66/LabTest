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
    public class MachinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Machines
        public ActionResult Index()
        {
            var machines = db.Machines.Include(m => m.Company).Include(m => m.Location).Include(m => m.Machine_Type);
            return View(machines.ToList());
        }

        // GET: Machines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        // GET: Machines/Create
        public ActionResult Create()
        {
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code");
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name");
            ViewBag.Machine_Typeid = new SelectList(db.Machine_Type, "id", "name");
            return View();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,Machine_Typeid,Companyid,Locationid,status,chged_by,chgd_date")] Machine machine)
        {
            if (ModelState.IsValid)
            {
                db.Machines.Add(machine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", machine.Companyid);
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", machine.Locationid);
            ViewBag.Machine_Typeid = new SelectList(db.Machine_Type, "id", "name", machine.Machine_Typeid);
            return View(machine);
        }

        // GET: Machines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", machine.Companyid);
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", machine.Locationid);
            ViewBag.Machine_Typeid = new SelectList(db.Machine_Type, "id", "name", machine.Machine_Typeid);
            return View(machine);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,Machine_Typeid,Companyid,Locationid,status,chged_by,chgd_date")] Machine machine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", machine.Companyid);
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", machine.Locationid);
            ViewBag.Machine_Typeid = new SelectList(db.Machine_Type, "id", "name", machine.Machine_Typeid);
            return View(machine);
        }

        // GET: Machines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Machine machine = db.Machines.Find(id);
            db.Machines.Remove(machine);
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

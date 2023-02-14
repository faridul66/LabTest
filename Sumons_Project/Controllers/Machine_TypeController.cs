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
    public class Machine_TypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Machine_Type
        public ActionResult Index()
        {
            return View(db.Machine_Type.ToList());
        }

        // GET: Machine_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine_Type machine_Type = db.Machine_Type.Find(id);
            if (machine_Type == null)
            {
                return HttpNotFound();
            }
            return View(machine_Type);
        }

        // GET: Machine_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Machine_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,status,chged_by,chgd_date")] Machine_Type machine_Type)
        {
            if (ModelState.IsValid)
            {
                db.Machine_Type.Add(machine_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(machine_Type);
        }

        // GET: Machine_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine_Type machine_Type = db.Machine_Type.Find(id);
            if (machine_Type == null)
            {
                return HttpNotFound();
            }
            return View(machine_Type);
        }

        // POST: Machine_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,status,chged_by,chgd_date")] Machine_Type machine_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machine_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(machine_Type);
        }

        // GET: Machine_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine_Type machine_Type = db.Machine_Type.Find(id);
            if (machine_Type == null)
            {
                return HttpNotFound();
            }
            return View(machine_Type);
        }

        // POST: Machine_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Machine_Type machine_Type = db.Machine_Type.Find(id);
            db.Machine_Type.Remove(machine_Type);
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

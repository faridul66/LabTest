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
    public class Location_TypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Location_Type
        public ActionResult Index()
        {
            return View(db.Location_Type.ToList());
        }

        // GET: Location_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location_Type location_Type = db.Location_Type.Find(id);
            if (location_Type == null)
            {
                return HttpNotFound();
            }
            return View(location_Type);
        }

        // GET: Location_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,parent_type,code,name,status,chged_by,chged_datetime")] Location_Type location_Type)
        {
            if (ModelState.IsValid)
            {
                db.Location_Type.Add(location_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(location_Type);
        }

        // GET: Location_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location_Type location_Type = db.Location_Type.Find(id);
            if (location_Type == null)
            {
                return HttpNotFound();
            }
            return View(location_Type);
        }

        // POST: Location_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,parent_type,code,name,status,chged_by,chged_datetime")] Location_Type location_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location_Type);
        }

        // GET: Location_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location_Type location_Type = db.Location_Type.Find(id);
            if (location_Type == null)
            {
                return HttpNotFound();
            }
            return View(location_Type);
        }

        // POST: Location_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location_Type location_Type = db.Location_Type.Find(id);
            db.Location_Type.Remove(location_Type);
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

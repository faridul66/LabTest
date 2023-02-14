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
    public class Other_TypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Other_Type
        public ActionResult Index()
        {
            return View(db.Other_Type.ToList());
        }

        // GET: Other_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Type other_Type = db.Other_Type.Find(id);
            if (other_Type == null)
            {
                return HttpNotFound();
            }
            return View(other_Type);
        }

        // GET: Other_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Other_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type_code,type_name,status,chged_by,chgd_date")] Other_Type other_Type)
        {
            if (ModelState.IsValid)
            {
                db.Other_Type.Add(other_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(other_Type);
        }

        // GET: Other_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Type other_Type = db.Other_Type.Find(id);
            if (other_Type == null)
            {
                return HttpNotFound();
            }
            return View(other_Type);
        }

        // POST: Other_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type_code,type_name,status,chged_by,chgd_date")] Other_Type other_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(other_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(other_Type);
        }

        // GET: Other_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other_Type other_Type = db.Other_Type.Find(id);
            if (other_Type == null)
            {
                return HttpNotFound();
            }
            return View(other_Type);
        }

        // POST: Other_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Other_Type other_Type = db.Other_Type.Find(id);
            db.Other_Type.Remove(other_Type);
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

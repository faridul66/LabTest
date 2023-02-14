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
    public class Feature_TypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Feature_Type
        public ActionResult Index()
        {
            return View(db.Feature_Type.ToList());
        }

        // GET: Feature_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature_Type feature_Type = db.Feature_Type.Find(id);
            if (feature_Type == null)
            {
                return HttpNotFound();
            }
            return View(feature_Type);
        }

        // GET: Feature_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feature_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,parent_type,type_code,type_name,status,chged_by,chgd_date")] Feature_Type feature_Type)
        {
            if (ModelState.IsValid)
            {
                db.Feature_Type.Add(feature_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feature_Type);
        }

        // GET: Feature_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature_Type feature_Type = db.Feature_Type.Find(id);
            if (feature_Type == null)
            {
                return HttpNotFound();
            }
            return View(feature_Type);
        }

        // POST: Feature_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,parent_type,type_code,type_name,status,chged_by,chgd_date")] Feature_Type feature_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feature_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feature_Type);
        }

        // GET: Feature_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature_Type feature_Type = db.Feature_Type.Find(id);
            if (feature_Type == null)
            {
                return HttpNotFound();
            }
            return View(feature_Type);
        }

        // POST: Feature_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feature_Type feature_Type = db.Feature_Type.Find(id);
            db.Feature_Type.Remove(feature_Type);
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

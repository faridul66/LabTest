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
    public class Product_Indent_FeatureController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product_Indent_Feature
        public ActionResult Index()
        {
            var product_Indent_Feature = db.Product_Indent_Feature.Include(p => p.Feature).Include(p => p.Production_Indent);
            return View(product_Indent_Feature.ToList());
        }

        // GET: Product_Indent_Feature/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Indent_Feature product_Indent_Feature = db.Product_Indent_Feature.Find(id);
            if (product_Indent_Feature == null)
            {
                return HttpNotFound();
            }
            return View(product_Indent_Feature);
        }

        // GET: Product_Indent_Feature/Create
        public ActionResult Create()
        {
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code");
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no");
            return View();
        }

        // POST: Product_Indent_Feature/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Production_Indentid,Featureid")] Product_Indent_Feature product_Indent_Feature)
        {
            if (ModelState.IsValid)
            {
                db.Product_Indent_Feature.Add(product_Indent_Feature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", product_Indent_Feature.Featureid);
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", product_Indent_Feature.Production_Indentid);
            return View(product_Indent_Feature);
        }

        // GET: Product_Indent_Feature/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Indent_Feature product_Indent_Feature = db.Product_Indent_Feature.Find(id);
            if (product_Indent_Feature == null)
            {
                return HttpNotFound();
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", product_Indent_Feature.Featureid);
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", product_Indent_Feature.Production_Indentid);
            return View(product_Indent_Feature);
        }

        // POST: Product_Indent_Feature/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Production_Indentid,Featureid")] Product_Indent_Feature product_Indent_Feature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Indent_Feature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", product_Indent_Feature.Featureid);
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", product_Indent_Feature.Production_Indentid);
            return View(product_Indent_Feature);
        }

        // GET: Product_Indent_Feature/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Indent_Feature product_Indent_Feature = db.Product_Indent_Feature.Find(id);
            if (product_Indent_Feature == null)
            {
                return HttpNotFound();
            }
            return View(product_Indent_Feature);
        }

        // POST: Product_Indent_Feature/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Indent_Feature product_Indent_Feature = db.Product_Indent_Feature.Find(id);
            db.Product_Indent_Feature.Remove(product_Indent_Feature);
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

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
    public class Machine_ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Machine_Product
        public ActionResult Index()
        {
            var machine_Product = db.Machine_Product.Include(m => m.Machine).Include(m => m.Product_Type);
            return View(machine_Product.ToList());
        }

        // GET: Machine_Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine_Product machine_Product = db.Machine_Product.Find(id);
            if (machine_Product == null)
            {
                return HttpNotFound();
            }
            return View(machine_Product);
        }

        // GET: Machine_Product/Create
        public ActionResult Create()
        {
            ViewBag.Machineid = new SelectList(db.Machines, "id", "name");
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code");
            return View();
        }

        // POST: Machine_Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Machineid,Product_Typeid,status,chged_by,chgd_date")] Machine_Product machine_Product)
        {
            if (ModelState.IsValid)
            {
                db.Machine_Product.Add(machine_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Machineid = new SelectList(db.Machines, "id", "name", machine_Product.Machineid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", machine_Product.Product_Typeid);
            return View(machine_Product);
        }

        // GET: Machine_Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine_Product machine_Product = db.Machine_Product.Find(id);
            if (machine_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Machineid = new SelectList(db.Machines, "id", "name", machine_Product.Machineid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", machine_Product.Product_Typeid);
            return View(machine_Product);
        }

        // POST: Machine_Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Machineid,Product_Typeid,status,chged_by,chgd_date")] Machine_Product machine_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machine_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Machineid = new SelectList(db.Machines, "id", "name", machine_Product.Machineid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", machine_Product.Product_Typeid);
            return View(machine_Product);
        }

        // GET: Machine_Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Machine_Product machine_Product = db.Machine_Product.Find(id);
            if (machine_Product == null)
            {
                return HttpNotFound();
            }
            return View(machine_Product);
        }

        // POST: Machine_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Machine_Product machine_Product = db.Machine_Product.Find(id);
            db.Machine_Product.Remove(machine_Product);
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

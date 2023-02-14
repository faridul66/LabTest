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
    public class Shift_EndController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Shift_End
        public ActionResult Index()
        {
            var shift_End = db.Shift_End.Include(s => s.Production_Indent);
            return View(shift_End.ToList());
        }

        // GET: Shift_End/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift_End shift_End = db.Shift_End.Find(id);
            if (shift_End == null)
            {
                return HttpNotFound();
            }
            return View(shift_End);
        }

        // GET: Shift_End/Create
        public ActionResult Create()
        {
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no");
            return View();
        }

        // POST: Shift_End/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Production_Indentid,consumption_residual,product_wastage,residual_unit,wastage_unit,shift_end,status,chged_by,chgd_date")] Shift_End shift_End)
        {
            if (ModelState.IsValid)
            {
                db.Shift_End.Add(shift_End);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", shift_End.Production_Indentid);
            return View(shift_End);
        }

        // GET: Shift_End/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift_End shift_End = db.Shift_End.Find(id);
            if (shift_End == null)
            {
                return HttpNotFound();
            }
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", shift_End.Production_Indentid);
            return View(shift_End);
        }

        // POST: Shift_End/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Production_Indentid,consumption_residual,product_wastage,residual_unit,wastage_unit,shift_end,status,chged_by,chgd_date")] Shift_End shift_End)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shift_End).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Production_Indentid = new SelectList(db.Production_Indent, "id", "indent_no", shift_End.Production_Indentid);
            return View(shift_End);
        }

        // GET: Shift_End/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift_End shift_End = db.Shift_End.Find(id);
            if (shift_End == null)
            {
                return HttpNotFound();
            }
            return View(shift_End);
        }

        // POST: Shift_End/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shift_End shift_End = db.Shift_End.Find(id);
            db.Shift_End.Remove(shift_End);
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

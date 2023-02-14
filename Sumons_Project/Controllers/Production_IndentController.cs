using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BJProduction.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BJProduction.Controllers
{
    public class Production_IndentController : Controller
    {
        public Production_IndentController()
        {

        }


        public Production_IndentController(ApplicationUserManager userManager,
           ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }


        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Production_Indent
        public ActionResult Index()
        {
            var production_Indent = db.Production_Indent.Include(p => p.Feature).Include(p => p.Machine).Include(p => p.Product_Type).Include(p => p.Shift).Include(p => p.Unit_Measurement);
            return View(production_Indent.ToList());
        }

        // GET: Production_Indent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production_Indent production_Indent = db.Production_Indent.Find(id);
            if (production_Indent == null)
            {
                return HttpNotFound();
            }
            return View(production_Indent);
        }

        // GET: Production_Indent/Create
        public ActionResult Create()
        {
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code");
            ViewBag.Machineid = new SelectList(db.Machines, "id", "name");
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_name");
            ViewBag.Shiftid = new SelectList(db.Shifts, "id", "name");
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code");
            return View();
        }

        // POST: Production_Indent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Machineid,Product_Typeid,MyProperty,Shiftid,qty,batch_count,Featureid,prod_count,Unit_Measurementid,indent_no,indent_date,shift_start,status,chged_by,chgd_date")] Production_Indent production_Indent)
        {
            if (ModelState.IsValid)
            {
                db.Production_Indent.Add(production_Indent);
                db.SaveChanges();
                return RedirectToAction("Edit");
            }

            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", production_Indent.Featureid);
            ViewBag.Machineid = new SelectList(db.Machines, "id", "name", production_Indent.Machineid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_name", production_Indent.Product_Typeid);
            ViewBag.Shiftid = new SelectList(db.Shifts, "id", "shift_code", production_Indent.Shiftid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", production_Indent.Unit_Measurementid);
            return View(production_Indent);
        }

        // GET: Production_Indent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production_Indent production_Indent = db.Production_Indent.Find(id);
            if (production_Indent == null)
            {
                return HttpNotFound();
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", production_Indent.Featureid);
            ViewBag.Machineid = new SelectList(db.Machines, "id", "name", production_Indent.Machineid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_name", production_Indent.Product_Typeid);
            ViewBag.Shiftid = new SelectList(db.Shifts, "id", "shift_code", production_Indent.Shiftid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", production_Indent.Unit_Measurementid);
            return View(production_Indent);
        }

        // POST: Production_Indent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Machineid,Product_Typeid,MyProperty,Shiftid,qty,batch_count,Featureid,prod_count,Unit_Measurementid,indent_no,indent_date,shift_start,status,chged_by,chgd_date")] Production_Indent production_Indent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(production_Indent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", production_Indent.Featureid);
            ViewBag.Machineid = new SelectList(db.Machines, "id", "name", production_Indent.Machineid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", production_Indent.Product_Typeid);
            ViewBag.Shiftid = new SelectList(db.Shifts, "id", "shift_code", production_Indent.Shiftid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", production_Indent.Unit_Measurementid);
            return View(production_Indent);
        }

        // GET: Production_Indent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production_Indent production_Indent = db.Production_Indent.Find(id);
            if (production_Indent == null)
            {
                return HttpNotFound();
            }
            return View(production_Indent);
        }

        // POST: Production_Indent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Production_Indent production_Indent = db.Production_Indent.Find(id);
            db.Production_Indent.Remove(production_Indent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public JsonResult SaveData(string[][][] values) // machineId, shiftId, qty, batchCount, indentNo, indentDate, shiftStart, productTypeId, mainFeatureId, productCount, unitId
        {
            Production_Indent production_Indent = new Production_Indent();
            production_Indent.Machineid = Convert.ToInt32(values[0][0][0]);
            production_Indent.Shiftid = Convert.ToInt32(values[0][1][0]);
            production_Indent.qty = Convert.ToInt32(values[0][2][0]);
            production_Indent.batch_count = Convert.ToInt32(values[0][3][0]);
            production_Indent.indent_no = values[0][4][0];
            production_Indent.indent_date = Convert.ToDateTime(values[0][5][0]);
            production_Indent.shift_start = Convert.ToDateTime(values[0][6][0]);
            production_Indent.Product_Typeid = Convert.ToInt32(values[0][7][0]);
            production_Indent.Featureid = Convert.ToInt32(values[0][8][0]);
            production_Indent.prod_count = Convert.ToInt32(values[0][9][0]);
            production_Indent.Unit_Measurementid = Convert.ToInt32(values[0][10][0]);
            production_Indent.status = "";
            production_Indent.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
            production_Indent.chgd_date = DateTime.UtcNow;
            db.Production_Indent.Add(production_Indent);
            db.SaveChanges();
            var productionIndentId = production_Indent.id;
            for (int i = 0; i < values[1].Length; i++)
            {
                Product_Indent_Feature product_Indent_Feature = new Product_Indent_Feature();
                product_Indent_Feature.Production_Indentid = productionIndentId;
                product_Indent_Feature.Feature_Typeid = Convert.ToInt32(values[1][i][0]);
                product_Indent_Feature.Featureid = Convert.ToInt32(values[1][i][1]);
                db.Product_Indent_Feature.Add(product_Indent_Feature);
                db.SaveChanges();
            }
            for (int i = 0; i < values[2].Length; i++)
            {

                Product_Indent_Feature product_Indent_Feature = new Product_Indent_Feature();
                product_Indent_Feature.Production_Indentid = productionIndentId;
                product_Indent_Feature.Feature_Typeid = Convert.ToInt32(values[2][i][0]);
                product_Indent_Feature.FeatureValue = Convert.ToInt32(values[2][i][1]);
                product_Indent_Feature.Unit_Measurementid = Convert.ToInt32(values[2][i][2]);
                product_Indent_Feature.Featureid = db.Features.Where(x => x.Feature_Typeid == product_Indent_Feature.Feature_Typeid).FirstOrDefault().id;
                db.Product_Indent_Feature.Add(product_Indent_Feature);
                db.SaveChanges();


            }

            return Json(productionIndentId, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Update(string[][][] values)
        {
            int productionIndentId = Convert.ToInt32(values[0][11][0]);
            var production_Indent = db.Production_Indent.Find(productionIndentId);
            production_Indent.Machineid = Convert.ToInt32(values[0][0][0]);
            production_Indent.Shiftid = Convert.ToInt32(values[0][1][0]);
            production_Indent.qty = Convert.ToInt32(values[0][2][0]);
            production_Indent.batch_count = Convert.ToInt32(values[0][3][0]);
            production_Indent.indent_no = values[0][4][0];
            production_Indent.indent_date = Convert.ToDateTime(values[0][5][0]);
            production_Indent.shift_start = Convert.ToDateTime(values[0][6][0]);
            production_Indent.Product_Typeid = Convert.ToInt32(values[0][7][0]);
            production_Indent.Featureid = Convert.ToInt32(values[0][8][0]);
            production_Indent.prod_count = Convert.ToInt32(values[0][9][0]);
            production_Indent.Unit_Measurementid = Convert.ToInt32(values[0][10][0]);
            production_Indent.status = "";
            production_Indent.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
            production_Indent.chgd_date = DateTime.UtcNow;
            //db.Production_Indent.Add(production_Indent);
            db.SaveChanges();

            var productionIndentFeature = db.Product_Indent_Feature.Where(x => x.Production_Indentid == productionIndentId);
            db.Product_Indent_Feature.RemoveRange(productionIndentFeature);
            db.SaveChanges();

            //var productionIndentId = production_Indent.id;
            for (int i = 0; i < values[1].Length; i++)
            {
                Product_Indent_Feature product_Indent_Feature = new Product_Indent_Feature();
                product_Indent_Feature.Production_Indentid = productionIndentId;
                product_Indent_Feature.Feature_Typeid = Convert.ToInt32(values[1][i][0]);
                product_Indent_Feature.Featureid = Convert.ToInt32(values[1][i][1]);
                db.Product_Indent_Feature.Add(product_Indent_Feature);
                db.SaveChanges();


            }
            for (int i = 0; i < values[2].Length; i++)
            {
                Product_Indent_Feature product_Indent_Feature = new Product_Indent_Feature();
                product_Indent_Feature.Production_Indentid = productionIndentId;
                product_Indent_Feature.Feature_Typeid = Convert.ToInt32(values[2][i][0]);
                product_Indent_Feature.FeatureValue = Convert.ToInt32(values[2][i][1]);
                product_Indent_Feature.Unit_Measurementid = Convert.ToInt32(values[2][i][2]);
                product_Indent_Feature.Featureid = db.Features.Where(x => x.Feature_Typeid == product_Indent_Feature.Feature_Typeid).FirstOrDefault().id;
                db.Product_Indent_Feature.Add(product_Indent_Feature);
                db.SaveChanges();
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetFeatures(int id)
        {
            var featurs = db.Product_Indent_Feature.Include(x => x.Feature).Include(x => x.Feature_Type).Where(x => x.Production_Indentid == id);
            return Json(featurs.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanySite(int id)
        {
            var companysite = db.Machines.FirstOrDefault(x => x.id == id);
            return Json(companysite, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Start(int id)
        {
            var productionIndent = db.Production_Indent.Find(id);
            productionIndent.status = "S";
            db.SaveChanges();
            return Json(productionIndent, JsonRequestBehavior.AllowGet);
        }



        public JsonResult PrintandSave(string[] values)
        {
            Product product = new Product();
            product.Product_Typeid = Convert.ToInt32(values[1]);
            product.product_serial = Convert.ToInt32(values[3]) + DateTime.Now.ToString("MMddyyhhmmss");
            db.Products.Add(product);
            db.SaveChanges();

            Production_Ledger productionLedger = new Production_Ledger();
            productionLedger.Productid = product.id;
            productionLedger.prod_count = Convert.ToInt32(values[2]);
            productionLedger.Production_Indentid = Convert.ToInt32(values[0]);
            productionLedger.Locationid = Convert.ToInt32(values[3]);
            productionLedger.production_date = DateTime.Now;
            db.Production_Ledger.Add(productionLedger);
            db.SaveChanges();


            var productIndentFeatures = db.Product_Indent_Feature.Where(x => x.Production_Indentid == productionLedger.Production_Indentid).ToList();
            for (int i = 0; i < productIndentFeatures.Count; i++)
            {
                Product_Feature product_Feature = new Product_Feature();
                product_Feature.Productid = product.id;
                product_Feature.Featureid = productIndentFeatures[i].Featureid ?? 0;
                product_Feature.Value = Convert.ToInt32(productIndentFeatures[i].FeatureValue);
                product_Feature.Unit_Measurementid = productIndentFeatures[i].Unit_Measurementid;
                product_Feature.status = "";
                product_Feature.chgd_date = DateTime.UtcNow;
                product_Feature.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
                db.Product_Feature.Add(product_Feature);
                db.SaveChanges();
            }



            var producedItems = db.Production_Ledger.Include(x => x.Production_Indent).Include(x => x.Product).Include(x => x.Production_Indent.Unit_Measurement).OrderByDescending(x => x.production_date)
                .Where(x => x.Production_Indentid == productionLedger.Production_Indentid).ToList();


            return Json(producedItems, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ProducedItems(int id)
        {
            var producedItems = db.Production_Ledger.Include(x => x.Production_Indent).Include(x => x.Product)
                .Include(x => x.Production_Indent.Unit_Measurement).OrderByDescending(x => x.production_date)
                .Where(x => x.Production_Indentid == id).ToList();

            return Json(producedItems, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadProductTypeCon(int id)
        {
            var producttypeid = db.Product_Type.Where(x => x.id != id);
            return Json(producttypeid, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadProduct(int[] values)
        {
            int productTypeId = values[0];
            int wareHouseId = values[1];
            #region
            //var Products =
            //    (from a in db.General_Ledger
            //     join b in db.Purchase_Ledger on a.trans_ref_id equals b.id
            //     where a.Transaction_Typeid == 1 && b.status == "C"
            //     join c in db.Products on b.Productid equals c.id
            //     join o in db.Purchase_Order on b.Purchase_Orderid equals o.id
            //     join u in db.Unit_Measurement on o.Unit_Measurementid equals u.id
            //     where c.Product_Typeid == productTypeId && b.Locationid == wareHouseId
            //     select new
            //     {
            //         c.Product_Typeid,
            //         c.product_serial,
            //         count = b.pur_count,
            //         a.Productid,
            //         a.is_current,
            //         a.trans_ref_id,
            //         o.Unit_Measurementid,
            //         u.code,
            //         a.Transaction_Typeid,
            //         b.Locationid
            //     }).Union
            //     (from a in db.General_Ledger
            //      join b in db.Production_Ledger on a.trans_ref_id equals b.id
            //      where a.Transaction_Typeid == 2 && b.status == "C"
            //      join c in db.Products on b.Productid equals c.id
            //      join o in db.Production_Indent on b.Production_Indentid equals o.id
            //      join u in db.Unit_Measurement on o.Unit_Measurementid equals u.id
            //      where c.Product_Typeid == productTypeId && b.Locationid == wareHouseId
            //      select new
            //      {
            //          c.Product_Typeid,
            //          c.product_serial,
            //          count = b.prod_count,
            //          a.Productid,
            //          a.is_current,
            //          a.trans_ref_id,
            //          o.Unit_Measurementid,
            //          u.code,
            //          a.Transaction_Typeid,
            //          b.Locationid
            //      }).Union
            //     (from a in db.General_Ledger
            //      join b in db.Transfer_Ledger on a.trans_ref_id equals b.id
            //      where a.Transaction_Typeid == 4 && b.status == "C"
            //      join c in db.Products on b.Productid equals c.id
            //      join o in db.Transfer_Order on b.Transfer_Orderid equals o.id
            //      join u in db.Unit_Measurement on o.Unit_Measurementid equals u.id
            //      where c.Product_Typeid == productTypeId && b.Locationid == wareHouseId
            //      select new
            //      {
            //          c.Product_Typeid,
            //          c.product_serial,
            //          count = b.tr_count,
            //          a.Productid,
            //          a.is_current,
            //          a.trans_ref_id,
            //          o.Unit_Measurementid,
            //          u.code,
            //          a.Transaction_Typeid,
            //          b.Locationid
            //      });

            #endregion

            var Products =
              (from a in db.General_Ledger
               join b in db.Purchase_Ledger on a.trans_ref_id equals b.id
               where a.Transaction_Typeid == 1 && b.status == "C"
               join c in db.Products on b.Productid equals c.id
               where c.Product_Typeid == productTypeId && b.Locationid == wareHouseId
               select new
               {
                   GLID = a.id,
                   ProductTypeId = c.Product_Typeid,
                   ProductSerial = c.product_serial,
                   QValue = b.pur_count,
                   ProductId = a.Productid,
                   IsCurrent = a.is_current,
                   LocationId = b.Locationid

               }).Union
                (from a in db.General_Ledger
                 join b in db.Production_Ledger on a.trans_ref_id equals b.id
                 where a.Transaction_Typeid == 2 && b.status == "C"
                 join c in db.Products on b.Productid equals c.id
                 where c.Product_Typeid == productTypeId && b.Locationid == wareHouseId
                 select new
                 {
                     GLID = a.id,
                     ProductTypeId = c.Product_Typeid,
                     ProductSerial = c.product_serial,
                     QValue = b.prod_count,
                     ProductId = a.Productid,
                     IsCurrent = a.is_current,
                     LocationId = b.Locationid
                 }).Union
                (from a in db.General_Ledger
                 join b in db.Transfer_Ledger on a.trans_ref_id equals b.id
                 where a.Transaction_Typeid == 4 && b.status == "C"
                 join c in db.Products on b.Productid equals c.id
                 where c.Product_Typeid == productTypeId && b.Locationid == wareHouseId
                 select new
                 {
                     GLID = a.id,
                     ProductTypeId = c.Product_Typeid,
                     ProductSerial = c.product_serial,
                     QValue = b.tr_count,
                     ProductId = a.Productid,
                     IsCurrent = a.is_current,
                     LocationId = b.Locationid
                 }).Union
                (from a in db.General_Ledger
                 join b in db.Sales_Ledger on a.trans_ref_id equals b.id
                 where a.Transaction_Typeid == 3 && b.status == "C"
                 join c in db.Products on b.Productid equals c.id
                 where c.Product_Typeid == productTypeId && b.Locationid == wareHouseId
                 select new
                 {
                     GLID = a.id,
                     ProductTypeId = c.Product_Typeid,
                     ProductSerial = c.product_serial,
                     QValue = -b.sale_count,
                     ProductId = a.Productid,
                     IsCurrent = a.is_current,
                     LocationId = b.Locationid
                 }).Union
                (from a in db.General_Ledger
                 join b in db.Consumption_Ledger on a.trans_ref_id equals b.id
                 where a.Transaction_Typeid == 5 && b.status == "C"
                 join c in db.Products on b.Productid equals c.id
                 where c.Product_Typeid == productTypeId && b.Locationid == wareHouseId
                 select new
                 {
                     GLID = a.id,
                     ProductTypeId = c.Product_Typeid,
                     ProductSerial = c.product_serial,
                     QValue = -b.prod_count,
                     ProductId = a.Productid,
                     IsCurrent = a.is_current,
                     LocationId = b.Locationid
                 });


            List<ProductToConsume> finalList = Products.GroupBy(x => new { x.IsCurrent, x.LocationId, x.ProductId, x.ProductSerial, x.ProductTypeId }).Select(x => new ProductToConsume
            {
                IsCurrent = x.Key.IsCurrent,
                LocationId = x.Key.LocationId,
                ProductId = x.Key.ProductId,
                ProductSerial = x.Key.ProductSerial,
                ProductTypeId = x.Key.ProductTypeId,
                QValue = x.Sum(y => y.QValue)
            }).ToList();


            var productsToExclude = (from a in db.Consumption_Ledger
                                     join b in db.Products on a.Productid equals b.id
                                     where b.Product_Typeid == productTypeId && a.status != "C"
                                     select a.Productid).Union(
            from a in db.Sales_Ledger
            join b in db.Products on a.Productid equals b.id
            where b.Product_Typeid == productTypeId && a.status != "C"
            select a.Productid).ToList();



            return Json(finalList.Where(x => !productsToExclude.Contains(x.ProductId) && x.QValue > 0), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Consumption(string[] values)
        {
            int productionIndentId = Convert.ToInt32(values[0]);
            int productTypeId = Convert.ToInt32(values[1]);
            int productId = Convert.ToInt32(values[2]);
            int count = Convert.ToInt32(values[3]);
            int wareHouse = Convert.ToInt32(values[4]);
            //int transTypeId = Convert.ToInt32(values[5]);
            //int transRefId = Convert.ToInt32(values[6]);

            Consumption_Ledger consumption_Ledger = new Consumption_Ledger();
            consumption_Ledger.Productid = productId;
            consumption_Ledger.prod_count = count;
            consumption_Ledger.Production_Indentid = productionIndentId;
            consumption_Ledger.Locationid = wareHouse;
            consumption_Ledger.consumption_date = DateTime.Now;
            consumption_Ledger.status = "";
            consumption_Ledger.chgd_date = DateTime.Now;
            consumption_Ledger.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
            db.Consumption_Ledger.Add(consumption_Ledger);
            db.SaveChanges();

            //var consumptionLedgerData = db.Consumption_Ledger.Find(consumption_Ledger.id);
            //var glData = new int[] { transTypeId, transRefId };

            //return Json(new dynamic[] { consumptionLedgerData, glData }, JsonRequestBehavior.AllowGet);
            var consumedItems = db.Consumption_Ledger.Join(db.Products, a => a.Productid, b => b.id, (a, b) => new { a, b })
                           .Join(db.Product_Type, ab => ab.b.Product_Typeid, c => c.id, (ab, c) => new { ab, c })
                           .Where(abc => abc.ab.a.Production_Indentid == productionIndentId)
                           .Select(abc => new
                           {
                               abc.ab.a.id,
                               abc.c.type_name,
                               abc.ab.b.product_serial,
                               abc.ab.a.prod_count,
                               abc.ab.a.consumption_date
                           });
            return Json(consumedItems, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsumedItems(int id)
        {
            var consumedItems = db.Consumption_Ledger.Join(db.Products, a => a.Productid, b => b.id, (a, b) => new { a, b })
                               .Join(db.Product_Type, ab => ab.b.Product_Typeid, c => c.id, (ab, c) => new { ab, c })
                               .Where(abc => abc.ab.a.Production_Indentid == id)
                               .Select(abc => new
                               {
                                   abc.ab.a.id,
                                   abc.c.type_name,
                                   abc.ab.b.product_serial,
                                   abc.ab.a.prod_count,
                                   abc.ab.a.consumption_date
                               });
            return Json(consumedItems, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteConsumedItems(int id)
        {
            string message;
            try
            {
                Consumption_Ledger consumption_Ledger = db.Consumption_Ledger.Find(id);
                db.Consumption_Ledger.Remove(consumption_Ledger);
                db.SaveChanges();
                message = "Success";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LoadResiduals(int[] id)
        {
            int productIndentId = id[0];
            int wareHouseId = id[1];
            var resideuals = (from a in db.Consumption_Ledger
                              join b in db.Products on a.Productid equals b.id
                              join c in db.Product_Type on b.Product_Typeid equals c.id
                              where a.Production_Indentid == productIndentId && a.Locationid == wareHouseId
                              select new { a.Productid, a.id, producyTypeId = c.id, c.type_name, b.product_serial, a.prod_count }).ToList();
            return Json(resideuals, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SubmitIndent(string[][][] values)
        {
            string message;
            try
            {
                int wastageUnit = Convert.ToInt32(values[0][2][0]);
                double wastageValue = Convert.ToDouble(values[0][1][0]);
                int indentId = Convert.ToInt32(values[0][0][0]);

                if (values.Length > 1)
                {
                    for (int i = 0; i < values[1].Length; i++)
                    {
                        int consumptionLedgerId = Convert.ToInt32(values[1][i][0]);
                        double Value = Convert.ToDouble(values[1][i][1]);

                        Residuals residuals = new Residuals();
                        residuals.ProductId = db.Consumption_Ledger.Find(consumptionLedgerId).Productid;
                        residuals.LedgerId = consumptionLedgerId;
                        residuals.PreviousValue = db.Consumption_Ledger.Find(consumptionLedgerId).prod_count;
                        residuals.ResidualValue = Value;
                        residuals.ProductionIndentId = indentId;
                        residuals.UnitId = 5;  // NCCC
                        residuals.ProductTypeId = db.Products.Find(db.Consumption_Ledger.Find(consumptionLedgerId).Productid).Product_Typeid;
                        db.Residuals.Add(residuals);
                        db.SaveChanges();

                        Consumption_Ledger consumption_Ledger = db.Consumption_Ledger.Find(consumptionLedgerId);
                        consumption_Ledger.prod_count = consumption_Ledger.prod_count - Value;
                        db.SaveChanges();
                    }
                }


                Shift_End shift_End = new Shift_End();
                shift_End.Production_Indentid = indentId;
                shift_End.wastage_unit = wastageUnit;
                shift_End.product_wastage = wastageValue;
                shift_End.shift_end = DateTime.Now;
                shift_End.status = "";
                shift_End.chgd_date = DateTime.Now;
                shift_End.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;



                shift_End.consumption_residual = 0;
                shift_End.residual_unit = 5; //c
                db.Shift_End.Add(shift_End);
                db.SaveChanges();

                List<int> productionLedger = db.Production_Ledger.Include(x => x.Production_Indent).Where(x => x.Production_Indent.id == indentId).Select(x => x.id).ToList();
                var transTypeId = db.Transaction_Type.FirstOrDefault(x => x.type_code == "PI").id;
                foreach (var item in productionLedger)
                {
                    var ledger = db.Production_Ledger.Find(item);
                    ledger.status = "C";
                    db.SaveChanges();
                    General_Ledger generalLedger = new General_Ledger();
                    generalLedger.Productid = ledger.Productid;
                    generalLedger.Transaction_Typeid = transTypeId;
                    generalLedger.trans_ref_id = ledger.id;
                    generalLedger.trans_date = ledger.production_date;
                    generalLedger.is_current = true;
                    generalLedger.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
                    generalLedger.chgd_date = DateTime.Now;
                    db.General_Ledger.Add(generalLedger);
                    db.SaveChanges();

                }



                List<int> consumptionLedger = db.Consumption_Ledger.Include(x => x.Production_Indent).Where(x => x.Production_Indent.id == indentId).Select(x => x.id).ToList();

                transTypeId = db.Transaction_Type.FirstOrDefault(x => x.type_code == "C").id;
                foreach (var item in consumptionLedger)
                {
                    var ledger = db.Consumption_Ledger.Find(item);
                    ledger.status = "C";
                    db.SaveChanges();
                    General_Ledger generalLedger = new General_Ledger();
                    generalLedger.Productid = ledger.Productid;
                    generalLedger.Transaction_Typeid = transTypeId;
                    generalLedger.trans_ref_id = ledger.id;
                    generalLedger.trans_date = ledger.consumption_date;
                    generalLedger.is_current = true;
                    generalLedger.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
                    generalLedger.chgd_date = DateTime.Now;
                    db.General_Ledger.Add(generalLedger);
                    db.SaveChanges();

                }

                Production_Indent production_Indent = db.Production_Indent.Find(indentId);
                production_Indent.status = "C";
                db.SaveChanges();

                message = "Success";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }



        public JsonResult LoadWastageC(int id)
        {
            Shift_End shift_End = db.Shift_End.FirstOrDefault(x => x.Production_Indentid == id);
            return Json(shift_End, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadResidualC(int id)
        {
            var residuals = db.Residuals.Join(db.Product_Type, a => a.ProductTypeId, b => b.id, (a, b) => new { a, b })
                .Join(db.Products, ab => ab.a.ProductId, c => c.id, (ab, c) => new { ab, c }).Select(abc => new
                {
                    abc.ab.a.LedgerId,
                    abc.ab.b.type_name,
                    abc.ab.a.PreviousValue,
                    abc.c.product_serial,
                    abc.ab.a.UnitId,
                    abc.ab.a.ResidualValue,
                    abc.ab.a.ProductionIndentId
                }).Where(x => x.ProductionIndentId == id).ToList();
            return Json(residuals, JsonRequestBehavior.AllowGet);
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

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
    public class Transfer_OrderController : Controller
    {
        public Transfer_OrderController()
        {
        }


        public Transfer_OrderController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
        }

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            set { _userManager = value; }
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transfer_Order
        public ActionResult Index()
        {
            var transfer_Order = db.Transfer_Order.Include(t => t.Feature).Include(t => t.Product_Type)
                .Include(t => t.Unit_Measurement);
            return View(transfer_Order.ToList());
        }

        // GET: Transfer_Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Transfer_Order transfer_Order = db.Transfer_Order.Find(id);
            if (transfer_Order == null)
            {
                return HttpNotFound();
            }

            return View(transfer_Order);
        }

        // GET: Transfer_Order/Create
        public ActionResult Create()
        {
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code");
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_name");
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code");
            return View();
        }

        // POST: Transfer_Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include =
                "id,from_company_id,to_company_id,Product_Typeid,qty,Featureid,tr_count,Unit_Measurementid,order_no,transfer_from_date,status,chged_by,chgd_date")]
            Transfer_Order transfer_Order)
        {
            if (ModelState.IsValid)
            {
                db.Transfer_Order.Add(transfer_Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", transfer_Order.Featureid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", transfer_Order.Product_Typeid);
            ViewBag.Unit_Measurementid =
                new SelectList(db.Unit_Measurement, "id", "code", transfer_Order.Unit_Measurementid);
            return View(transfer_Order);
        }

        // GET: Transfer_Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Transfer_Order transfer_Order = db.Transfer_Order.Find(id);
            if (transfer_Order == null)
            {
                return HttpNotFound();
            }

            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", transfer_Order.Featureid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_name", transfer_Order.Product_Typeid);
            ViewBag.Unit_Measurementid =
                new SelectList(db.Unit_Measurement, "id", "code", transfer_Order.Unit_Measurementid);
            return View(transfer_Order);
        }

        // POST: Transfer_Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include =
                "id,from_company_id,to_company_id,Product_Typeid,qty,Featureid,tr_count,Unit_Measurementid,order_no,transfer_from_date,status,chged_by,chgd_date")]
            Transfer_Order transfer_Order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transfer_Order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", transfer_Order.Featureid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", transfer_Order.Product_Typeid);
            ViewBag.Unit_Measurementid =
                new SelectList(db.Unit_Measurement, "id", "code", transfer_Order.Unit_Measurementid);
            return View(transfer_Order);
        }

        // GET: Transfer_Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Transfer_Order transfer_Order = db.Transfer_Order.Find(id);
            if (transfer_Order == null)
            {
                return HttpNotFound();
            }

            return View(transfer_Order);
        }

        // POST: Transfer_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transfer_Order transfer_Order = db.Transfer_Order.Find(id);
            db.Transfer_Order.Remove(transfer_Order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Authorize]
        public JsonResult SaveData(string[][][] values)
        {
            string orderNo = values[0][0][0];
            int productTypeId = Convert.ToInt32(values[0][1][0]);
            int qty = Convert.ToInt32(values[0][2][0]);
            DateTime transferDate = Convert.ToDateTime(values[0][3][0]);
            int fromCompany = Convert.ToInt32(values[0][4][0]);
            int toCompany = Convert.ToInt32(values[0][5][0]);
            int fromSite = Convert.ToInt32(values[0][6][0]);
            int toSite = Convert.ToInt32(values[0][7][0]);
            int fromWarehouse = Convert.ToInt32(values[0][8][0]);
            int toWarehouse = Convert.ToInt32(values[0][9][0]);
            int transferCount = Convert.ToInt32(values[0][10][0]);
            int unitId = Convert.ToInt32(values[0][11][0]);
            int mainFeatureId = Convert.ToInt32(values[0][12][0]);

            Transfer_Order transfer_Order = new Transfer_Order();
            transfer_Order.order_no = orderNo;
            transfer_Order.Product_Typeid = productTypeId;
            transfer_Order.qty = qty;
            transfer_Order.transfer_from_date = transferDate;
            transfer_Order.from_company_id = fromCompany;
            transfer_Order.to_company_id = toCompany;
            transfer_Order.Featureid = mainFeatureId;
            transfer_Order.tr_count = transferCount;
            transfer_Order.Unit_Measurementid = unitId;
            transfer_Order.status = "";
            transfer_Order.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
            transfer_Order.chgd_date = DateTime.UtcNow;
            db.Transfer_Order.Add(transfer_Order);
            db.SaveChanges();

            TransferOrderExt transferOrderExt = new TransferOrderExt();
            transferOrderExt.OrderId = transfer_Order.id;
            transferOrderExt.FromSite = fromSite;
            transferOrderExt.FromWarehouse = fromWarehouse;
            transferOrderExt.ToSite = toSite;
            transferOrderExt.ToWarehouse = toWarehouse;
            db.TransferOrderExts.Add(transferOrderExt);
            db.SaveChanges();


            for (int i = 0; i < values[1].Length; i++)
            {
                TransferProductFeatures transferProductFeatures = new TransferProductFeatures();
                transferProductFeatures.OrderId = transfer_Order.id;
                transferProductFeatures.ProductTypeId = productTypeId;
                transferProductFeatures.FeatureTypeId = Convert.ToInt32(values[1][i][0]);
                transferProductFeatures.FearureId = Convert.ToInt32(values[1][i][1]);
                //transferProductFeatures.UnitId = 0;
                //transferProductFeatures.TxtValue = 0;
                db.TransferProductFeatures.Add(transferProductFeatures);
                db.SaveChanges();
            }

            for (int i = 0; i < values[2].Length; i++)
            {
                TransferProductFeatures transferProductFeatures = new TransferProductFeatures();
                transferProductFeatures.OrderId = transfer_Order.id;
                transferProductFeatures.ProductTypeId = productTypeId;
                transferProductFeatures.FeatureTypeId = Convert.ToInt32(values[2][0][0]);
                transferProductFeatures.FearureId = db.Features
                    .FirstOrDefault(x => x.Feature_Typeid == transferProductFeatures.FeatureTypeId).id;
                transferProductFeatures.UnitId = Convert.ToInt32(values[2][0][2]);
                transferProductFeatures.TxtValue = Convert.ToInt32(values[2][0][1]);
                db.TransferProductFeatures.Add(transferProductFeatures);
                db.SaveChanges();
            }


            //Production_Indent production_Indent = new Production_Indent();
            //production_Indent.Machineid = Convert.ToInt32(values[0][0][0]);
            //production_Indent.Shiftid = Convert.ToInt32(values[0][1][0]);
            //production_Indent.qty = Convert.ToInt32(values[0][2][0]);
            //production_Indent.batch_count = Convert.ToInt32(values[0][3][0]);
            //production_Indent.indent_no = values[0][4][0];
            //production_Indent.indent_date = Convert.ToDateTime(values[0][5][0]);
            //production_Indent.shift_start = Convert.ToDateTime(values[0][6][0]);
            //production_Indent.Product_Typeid = Convert.ToInt32(values[0][7][0]);
            //production_Indent.Featureid = Convert.ToInt32(values[0][8][0]);
            //production_Indent.prod_count = Convert.ToInt32(values[0][9][0]);
            //production_Indent.Unit_Measurementid = Convert.ToInt32(values[0][10][0]);
            //production_Indent.status = "";
            //production_Indent.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
            //production_Indent.chgd_date = DateTime.UtcNow;
            //db.Production_Indent.Add(production_Indent);
            //db.SaveChanges();
            //var productionIndentId = production_Indent.id;
            //for (int i = 0; i < values[1].Length; i++)
            //{
            //    Product_Indent_Feature product_Indent_Feature = new Product_Indent_Feature();
            //    product_Indent_Feature.Production_Indentid = productionIndentId;
            //    product_Indent_Feature.Feature_Typeid = Convert.ToInt32(values[1][i][0]);
            //    product_Indent_Feature.Featureid = Convert.ToInt32(values[1][i][1]);
            //    db.Product_Indent_Feature.Add(product_Indent_Feature);
            //    db.SaveChanges();
            //}
            //for (int i = 0; i < values[2].Length; i++)
            //{

            //    Product_Indent_Feature product_Indent_Feature = new Product_Indent_Feature();
            //    product_Indent_Feature.Production_Indentid = productionIndentId;
            //    product_Indent_Feature.Feature_Typeid = Convert.ToInt32(values[2][i][0]);
            //    product_Indent_Feature.FeatureValue = Convert.ToInt32(values[2][i][1]);
            //    product_Indent_Feature.Unit_Measurementid = Convert.ToInt32(values[2][i][2]);
            //    product_Indent_Feature.Featureid = db.Features.Where(x => x.Feature_Typeid == product_Indent_Feature.Feature_Typeid).FirstOrDefault().id;
            //    db.Product_Indent_Feature.Add(product_Indent_Feature);
            //    db.SaveChanges();


            //}

            return Json(transfer_Order.id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public JsonResult UpdateData(string[][][] values)
        {
            int orderId = Convert.ToInt32(values[0][13][0]);
            string orderNo = values[0][0][0];
            int productTypeId = Convert.ToInt32(values[0][1][0]);
            int qty = Convert.ToInt32(values[0][2][0]);
            DateTime transferDate = Convert.ToDateTime(values[0][3][0]);
            int fromCompany = Convert.ToInt32(values[0][4][0]);
            int toCompany = Convert.ToInt32(values[0][5][0]);
            int fromSite = Convert.ToInt32(values[0][6][0]);
            int toSite = Convert.ToInt32(values[0][7][0]);
            int fromWarehouse = Convert.ToInt32(values[0][8][0]);
            int toWarehouse = Convert.ToInt32(values[0][9][0]);
            int transferCount = Convert.ToInt32(values[0][10][0]);
            int unitId = Convert.ToInt32(values[0][11][0]);
            int mainFeatureId = Convert.ToInt32(values[0][12][0]);

            Transfer_Order transfer_Order = db.Transfer_Order.Find(orderId);
            transfer_Order.order_no = orderNo;
            transfer_Order.Product_Typeid = productTypeId;
            transfer_Order.qty = qty;
            transfer_Order.transfer_from_date = transferDate;
            transfer_Order.from_company_id = fromCompany;
            transfer_Order.to_company_id = toCompany;
            transfer_Order.Featureid = mainFeatureId;
            transfer_Order.tr_count = transferCount;
            transfer_Order.Unit_Measurementid = unitId;
            transfer_Order.status = "";
            transfer_Order.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
            transfer_Order.chgd_date = DateTime.UtcNow;
            db.SaveChanges();

            TransferOrderExt transferOrderExt =
                db.TransferOrderExts.Find(db.TransferOrderExts.FirstOrDefault(x => x.OrderId == orderId).Id);
            transferOrderExt.OrderId = transfer_Order.id;
            transferOrderExt.FromSite = fromSite;
            transferOrderExt.FromWarehouse = fromWarehouse;
            transferOrderExt.ToSite = toSite;
            transferOrderExt.ToWarehouse = toWarehouse;
            db.SaveChanges();


            var TransferProductFeature = db.TransferProductFeatures.Where(x => x.OrderId == orderId);
            db.TransferProductFeatures.RemoveRange(TransferProductFeature);
            db.SaveChanges();


            for (int i = 0; i < values[1].Length; i++)
            {
                TransferProductFeatures transferProductFeatures = new TransferProductFeatures();
                transferProductFeatures.OrderId = transfer_Order.id;
                transferProductFeatures.ProductTypeId = productTypeId;
                transferProductFeatures.FeatureTypeId = Convert.ToInt32(values[1][i][0]);
                transferProductFeatures.FearureId = Convert.ToInt32(values[1][i][1]);
                //transferProductFeatures.UnitId = 0;
                //transferProductFeatures.TxtValue = 0;
                db.TransferProductFeatures.Add(transferProductFeatures);
                db.SaveChanges();
            }

            for (int i = 0; i < values[2].Length; i++)
            {
                TransferProductFeatures transferProductFeatures = new TransferProductFeatures();
                transferProductFeatures.OrderId = transfer_Order.id;
                transferProductFeatures.ProductTypeId = productTypeId;
                transferProductFeatures.FeatureTypeId = Convert.ToInt32(values[2][0][0]);
                transferProductFeatures.FearureId = db.Features
                    .FirstOrDefault(x => x.Feature_Typeid == transferProductFeatures.FeatureTypeId).id;
                transferProductFeatures.UnitId = Convert.ToInt32(values[2][0][2]);
                transferProductFeatures.TxtValue = Convert.ToInt32(values[2][0][1]);
                db.TransferProductFeatures.Add(transferProductFeatures);
                db.SaveChanges();
            }


            //Production_Indent production_Indent = new Production_Indent();
            //production_Indent.Machineid = Convert.ToInt32(values[0][0][0]);
            //production_Indent.Shiftid = Convert.ToInt32(values[0][1][0]);
            //production_Indent.qty = Convert.ToInt32(values[0][2][0]);
            //production_Indent.batch_count = Convert.ToInt32(values[0][3][0]);
            //production_Indent.indent_no = values[0][4][0];
            //production_Indent.indent_date = Convert.ToDateTime(values[0][5][0]);
            //production_Indent.shift_start = Convert.ToDateTime(values[0][6][0]);
            //production_Indent.Product_Typeid = Convert.ToInt32(values[0][7][0]);
            //production_Indent.Featureid = Convert.ToInt32(values[0][8][0]);
            //production_Indent.prod_count = Convert.ToInt32(values[0][9][0]);
            //production_Indent.Unit_Measurementid = Convert.ToInt32(values[0][10][0]);
            //production_Indent.status = "";
            //production_Indent.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
            //production_Indent.chgd_date = DateTime.UtcNow;
            //db.Production_Indent.Add(production_Indent);
            //db.SaveChanges();
            //var productionIndentId = production_Indent.id;
            //for (int i = 0; i < values[1].Length; i++)
            //{
            //    Product_Indent_Feature product_Indent_Feature = new Product_Indent_Feature();
            //    product_Indent_Feature.Production_Indentid = productionIndentId;
            //    product_Indent_Feature.Feature_Typeid = Convert.ToInt32(values[1][i][0]);
            //    product_Indent_Feature.Featureid = Convert.ToInt32(values[1][i][1]);
            //    db.Product_Indent_Feature.Add(product_Indent_Feature);
            //    db.SaveChanges();
            //}
            //for (int i = 0; i < values[2].Length; i++)
            //{

            //    Product_Indent_Feature product_Indent_Feature = new Product_Indent_Feature();
            //    product_Indent_Feature.Production_Indentid = productionIndentId;
            //    product_Indent_Feature.Feature_Typeid = Convert.ToInt32(values[2][i][0]);
            //    product_Indent_Feature.FeatureValue = Convert.ToInt32(values[2][i][1]);
            //    product_Indent_Feature.Unit_Measurementid = Convert.ToInt32(values[2][i][2]);
            //    product_Indent_Feature.Featureid = db.Features.Where(x => x.Feature_Typeid == product_Indent_Feature.Feature_Typeid).FirstOrDefault().id;
            //    db.Product_Indent_Feature.Add(product_Indent_Feature);
            //    db.SaveChanges();


            //}

            return Json(transfer_Order.id, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFeatures(int id)
        {
            var featurs = db.TransferProductFeatures
                .Join(db.Feature_Type, a => a.FeatureTypeId, b => b.id, (a, b) => new { a, b })
                .Where(x => x.a.OrderId == id);
            return Json(featurs.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTransferInfo(int id)
        {
            var transFeature = db.TransferOrderExts.Where(x => x.OrderId == id);
            return Json(transFeature.ToArray(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetProducts()
        {
            int productTypeId = 1;
            int wareHouseId = 14;
            //         var Products =
            //             (from a in db.General_Ledger
            //              join b in db.Purchase_Ledger on a.trans_ref_id equals b.id
            //              where a.Transaction_Typeid == 1 && b.status == "C"
            //              join c in db.Products on b.Productid equals c.id
            //              where c.Product_Typeid == productTypeId && b.Locationid == wareHouseId
            //              select new
            //{
            //    GLID = a.id,
            //    ProductTypeId = c.Product_Typeid,
            //    ProductSerial = c.product_serial,
            //    QValue = b.pur_count,
            //    ProductId = a.Productid,
            //    IsCurrent = a.is_current,
            //    LocationId = b.Locationid

            //}).Union
            // (from a in db.General_Ledger
            //  join b in db.Production_Ledger on a.trans_ref_id equals b.id
            //  where a.Transaction_Typeid == 2 && b.status == "C"
            //  join c in db.Products on b.Productid equals c.id
            //  where c.Product_Typeid == productTypeId && b.Locationid == wareHouseId
            //  select new
            //  {
            //      GLID = a.id,
            //      ProductTypeId = c.Product_Typeid,
            //      ProductSerial = c.product_serial,
            //      QValue = b.prod_count,
            //      ProductId = a.Productid,
            //      IsCurrent = a.is_current,
            //      LocationId = b.Locationid
            //  }).Union
            // (from a in db.General_Ledger
            //  join b in db.Transfer_Ledger on a.trans_ref_id equals b.id
            //  where a.Transaction_Typeid == 4 && b.status == "C" && a.is_current == true
            //  join c in db.Products on b.Productid equals c.id
            //  where c.Product_Typeid == productTypeId && b.Locationid == wareHouseId
            //  select new
            //  {
            //      GLID = a.id,
            //      ProductTypeId = c.Product_Typeid,
            //      ProductSerial = c.product_serial,
            //      QValue = b.tr_count,
            //      ProductId = a.Productid,
            //      IsCurrent = a.is_current,
            //      LocationId = b.Locationid
            //  });


            var Products = (
                from a in db.General_Ledger
                join b in db.Purchase_Ledger on a.trans_ref_id equals b.id
                join c in db.Purchase_Order on b.Purchase_Orderid equals c.id
                join d in db.Products on a.Productid equals d.id
                join e in db.Product_Type on d.Product_Typeid equals e.id
                where a.Transaction_Typeid == 1 && a.is_current == true
                select new
                {
                    GLID = a.id,
                    CompanyId = c.Companyid,
                    WarehouseId = b.Locationid,
                    Product = e.type_name,
                    ProductTypeId = d.Product_Typeid,
                    ProductId = a.Productid,
                    QTY = b.pur_count,
                    Serial = d.product_serial,
                    UnitId = c.Unit_Measurementid
                }
            ).Union(
                from a in db.General_Ledger
                join b in db.Production_Ledger on a.trans_ref_id equals b.id
                join c in db.Production_Indent on b.Production_Indentid equals c.id
                join d in db.Products on a.Productid equals d.id
                join e in db.Product_Type on d.Product_Typeid equals e.id
                join f in db.Machines on c.Machineid equals f.id
                where a.Transaction_Typeid == 2 && a.is_current == true
                select new
                {
                    GLID = a.id,
                    CompanyId = f.Companyid,
                    WarehouseId = b.Locationid,
                    Product = e.type_name,
                    ProductTypeId = d.Product_Typeid,
                    ProductId = a.Productid,
                    QTY = b.prod_count,
                    Serial = d.product_serial,
                    UnitId = c.Unit_Measurementid

                }
            ).Union(
                from a in db.General_Ledger
                join b in db.Transfer_Ledger on a.trans_ref_id equals b.id
                join c in db.Transfer_Order on b.Transfer_Orderid equals c.id
                join d in db.Products on a.Productid equals d.id
                join e in db.Product_Type on d.Product_Typeid equals e.id
                where a.Transaction_Typeid == 4 && a.is_current == true
                select new
                {
                    GLID = a.id,
                    CompanyId = c.to_company_id,
                    WarehouseId = b.Locationid,
                    Product = e.type_name,
                    ProductTypeId = d.Product_Typeid,
                    ProductId = a.Productid,
                    QTY = b.tr_count,
                    Serial = d.product_serial,
                    UnitId = c.Unit_Measurementid
                }
            );


            var productsToExclude =
                (from a in db.Consumption_Ledger
                    join b in db.Products on a.Productid equals b.id
                    where b.Product_Typeid == productTypeId
                    select a.Productid).Union(
                    from a in db.Sales_Ledger
                    join b in db.Products on a.Productid equals b.id
                    where b.Product_Typeid == productTypeId
                    select a.Productid).Union(
                    from a in db.Transfer_Ledger
                    join b in db.Products on a.Productid equals b.id
                    where b.Product_Typeid == productTypeId && a.status != "C"
                    select a.Productid).ToList();
            return Json(Products.Where(x => !productsToExclude.Contains(x.ProductId)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SendToLedger(string[][] values)
        {
            // values items =  productId,  QTY,  transferOrderId, toWareHouseId 

            for (int i = 0; i < values.Length; i++)
            {
                Transfer_Ledger transfer_Ledger = new Transfer_Ledger();
                transfer_Ledger.Productid = Convert.ToInt32(values[i][0]);
                transfer_Ledger.tr_count = Convert.ToDouble(values[i][1]);
                transfer_Ledger.Transfer_Orderid = Convert.ToInt32(values[i][2]);
                transfer_Ledger.Locationid = Convert.ToInt32(values[i][3]);
                transfer_Ledger.arrival_date = DateTime.Now;
                transfer_Ledger.status = "";
                transfer_Ledger.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
                transfer_Ledger.chgd_date = DateTime.UtcNow;
                db.Transfer_Ledger.Add(transfer_Ledger);
                db.SaveChanges();
            }


            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult YetToTransferItems(int id)
        {
            var products = db.Transfer_Ledger.Include(x => x.Product).Include(x => x.Product.Product_Type)
                .Where(x => x.Transfer_Orderid == id);
            return Json(products, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteYetToTransfer(int id)
        {
            string message;
            try
            {
                Transfer_Ledger transfer_Ledger = db.Transfer_Ledger.Find(id);
                db.Transfer_Ledger.Remove(transfer_Ledger);
                db.SaveChanges();
                message = "Success";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return Json(message, JsonRequestBehavior.AllowGet);
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
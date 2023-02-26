using System;
using System.Collections;
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
    public class Purchase_OrderController : Controller
    {

        public Purchase_OrderController()
        {

        }


        public Purchase_OrderController(ApplicationUserManager userManager,
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

        // GET: Purchase_Order
        public ActionResult Index()
        {
            var purchaseOrder = db.Purchase_Order.Include(p => p.Company).Include(p => p.Feature).Include(p => p.Location).Include(p => p.Product_Type).Include(p => p.Unit_Measurement).Include(p => p.Vendor);
            return View(purchaseOrder.ToList());
        }

        // GET: Purchase_Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Order purchaseOrder = db.Purchase_Order.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // GET: Purchase_Order/Create
        public ActionResult Create()
        {
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Name");
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_name");
            ViewBag.Locationid = new SelectList(db.Locations.Include(l => l.Location_Type).Where(l => l.Location_Type.name == "Country"), "id", "name");
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_name");
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code");
            ViewBag.Vendorid = new SelectList(db.Vendors, "id", "name");
            return View();
        }

        // POST: Purchase_Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Companyid,Vendorid,Product_Typeid,qty,Featureid,pur_count,Unit_Measurementid,Locationid,order_no,lc_number,lc_date,purchase_date,status,chged_by,chgd_date")] Purchase_Order purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.Purchase_Order.Add(purchaseOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", purchaseOrder.Companyid);
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", purchaseOrder.Featureid);
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", purchaseOrder.Locationid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", purchaseOrder.Product_Typeid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", purchaseOrder.Unit_Measurementid);
            ViewBag.Vendorid = new SelectList(db.Vendors, "id", "code", purchaseOrder.Vendorid);
            return View(purchaseOrder);
        }

        // GET: Purchase_Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Order purchaseOrder = db.Purchase_Order.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", purchaseOrder.Companyid);
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", purchaseOrder.Featureid);
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", purchaseOrder.Locationid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", purchaseOrder.Product_Typeid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", purchaseOrder.Unit_Measurementid);
            ViewBag.Vendorid = new SelectList(db.Vendors, "id", "code", purchaseOrder.Vendorid);
            return View(purchaseOrder);
        }

        // POST: Purchase_Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Companyid,Vendorid,Product_Typeid,qty,Featureid,pur_count,Unit_Measurementid,Locationid,order_no,lc_number,lc_date,purchase_date,status,chged_by,chgd_date")] Purchase_Order purchase_Order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase_Order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Companyid = new SelectList(db.Companies, "Id", "Company_Code", purchase_Order.Companyid);
            ViewBag.Featureid = new SelectList(db.Features, "id", "feature_code", purchase_Order.Featureid);
            ViewBag.Locationid = new SelectList(db.Locations, "id", "name", purchase_Order.Locationid);
            ViewBag.Product_Typeid = new SelectList(db.Product_Type, "id", "type_code", purchase_Order.Product_Typeid);
            ViewBag.Unit_Measurementid = new SelectList(db.Unit_Measurement, "id", "code", purchase_Order.Unit_Measurementid);
            ViewBag.Vendorid = new SelectList(db.Vendors, "id", "code", purchase_Order.Vendorid);
            return View(purchase_Order);
        }

        // GET: Purchase_Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase_Order purchase_Order = db.Purchase_Order.Find(id);
            if (purchase_Order == null)
            {
                return HttpNotFound();
            }
            return View(purchase_Order);
        }

        // POST: Purchase_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase_Order purchase_Order = db.Purchase_Order.Find(id);
            db.Purchase_Order.Remove(purchase_Order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public JsonResult GetPtn()
        {
            return Json(db.Product_Type.SqlQuery("select * from Product_Type").ToList(), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult GetFid(int id)
        {
            return Json(db.ProductType_FeatureType.Include(x => x.Product_Type).Include(x => x.Feature_Type).Where(x => x.Product_Typeid == id), JsonRequestBehavior.AllowGet);
            //return Json(db.Product_Type.Join(db.ProductType_FeatureType,a=>a.id,b=>b.Product_Typeid,(a,b)=>new {ProductType_FeatureType=b }).Where(x=>x.ProductType_FeatureType.Product_Typeid==id).Join(db.Feature_Type,a=>a.ProductType_FeatureType.Feature_Typeid,b=>b.id,(a,b)=>new {Feature_Type=b }), JsonRequestBehavior.AllowGet);
        }


        //[Authorize]
        //public JsonResult GetFIDM(int id)
        //{
        //    return Json(db.Features.Join(db.Feature_Type,a=>a.Feature_Typeid,b=>b.id,(a,b)=> new {Feature_Type =b,Feature=a}).Join(db.ProductType_FeatureType,a=>a.Feature_Type.id,b=>b.Feature_Typeid,(a,b)=> new { ProductType_FeatureType=b, Features=a }).Where(x=>x.ProductType_FeatureType.status=="M" && x.ProductType_FeatureType.Product_Typeid==id), JsonRequestBehavior.AllowGet);
        //    //return Json(db.Product_Type.Join(db.ProductType_FeatureType,a=>a.id,b=>b.Product_Typeid,(a,b)=>new {ProductType_FeatureType=b }).Where(x=>x.ProductType_FeatureType.Product_Typeid==id).Join(db.Feature_Type,a=>a.ProductType_FeatureType.Feature_Typeid,b=>b.id,(a,b)=>new {Feature_Type=b }), JsonRequestBehavior.AllowGet);
        //}


        [Authorize]
        public JsonResult GetUnit(int id)
        {
            int featureId = db.Features.FirstOrDefault(x => x.Feature_Typeid == id).id;
            return Json(db.Feature_UnitMeasurement.Include(x => x.Unit_Measurement).Where(x => x.Featureid == featureId), JsonRequestBehavior.AllowGet);

        }



        [Authorize]
        public JsonResult GetFt(int id)
        {
            return Json(db.Features.Where(x => x.Feature_Typeid == id), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult GetSite(int id)
        {
            return Json(db.Company_Location.Join(db.Locations, a => a.Locationid, b => b.id, (a, b) => new { Locations = b, Company_Location = a }).Where(x => x.Company_Location.CompanyId == id).Join(db.Locations, a => a.Locations.parent_location, b => b.id, (a, b) => new { Locations = b }), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult GetWh(int id)
        {
            return Json(db.Locations.Where(x => x.parent_location == id), JsonRequestBehavior.AllowGet);
        }



        [Authorize]
        [HttpPost]
        public JsonResult SubmitData(string[] values)
        {
            var orderNo = values[0];
            var lotNumber = values[1];
            var transTypeId = db.Transaction_Type.FirstOrDefault(x => x.type_code == "PO").id;
            var orderId = db.Purchase_Order.FirstOrDefault(x => x.order_no == orderNo).id;
            List<int> purchaseLedger = db.Purchase_Ledger.Include(x => x.Purchase_Order).Where(x => x.Purchase_Order.order_no == orderNo && x.lot_number == lotNumber).Select(x => x.id).ToList();
            foreach (var items in purchaseLedger)
            {
                var ledger = db.Purchase_Ledger.Find(items);
                ledger.status = "C";
                db.SaveChanges();
                General_Ledger generalLedger = new General_Ledger();
                generalLedger.Productid = ledger.Productid;
                generalLedger.Transaction_Typeid = transTypeId;
                generalLedger.trans_ref_id = ledger.id;
                generalLedger.trans_date = ledger.arrival_date;
                generalLedger.is_current = true;
                generalLedger.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
                generalLedger.chgd_date = DateTime.Now;
                db.General_Ledger.Add(generalLedger);
                db.SaveChanges();
            }
            var purchaseOrder = db.Purchase_Order.Find(orderId);
            if (purchaseOrder != null) purchaseOrder.status = "C";
            db.SaveChanges();


            return Json("", JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        [HttpPost]
        public JsonResult SaveData(string[][][] values)
        {

            var orderNo = values[0][8][0];
            var lotNumber = values[0][15][0];
            var companyId = Convert.ToInt32(values[0][0][0]);
            

            List<string> missingProducts = new List<string>();
            if (db.Purchase_Ledger.Include(x => x.Purchase_Order).Where(x => x.Purchase_Order.order_no == orderNo && x.lot_number != lotNumber && x.Purchase_Order.Companyid == companyId).ToList().Count != 0)
            {
                var purchaseOrderId = db.Purchase_Ledger.Include(x => x.Purchase_Order).Where(x => x.Purchase_Order.Companyid == companyId && x.Purchase_Order.order_no == orderNo).FirstOrDefault().Purchase_Order.id;
                Purchase_Order po = db.Purchase_Order.Find(purchaseOrderId) ?? throw new ArgumentNullException("db.Purchase_Order.Find(purchaseOrderId)");
                po.status = "C";
                db.SaveChanges();

            }
            if (db.Purchase_Ledger.Include(x => x.Purchase_Order).Where(x => x.Purchase_Order.order_no == orderNo && x.lot_number == lotNumber && x.Purchase_Order.Companyid == companyId).ToList().Count != 0)
            {
                var purchaseOrderId = db.Purchase_Ledger.Include(x => x.Purchase_Order).FirstOrDefault(x => x.lot_number == lotNumber && x.Purchase_Order.order_no == orderNo && x.Purchase_Order.Companyid == companyId).Purchase_Order.id;
                Purchase_Order po = db.Purchase_Order.Find(purchaseOrderId);

                var productId = db.Purchase_Ledger.Include(x => x.Purchase_Order).Where(x => x.lot_number == lotNumber && x.Purchase_Order.order_no == orderNo && x.Purchase_Order.Companyid == companyId).Select(x => x.Productid).ToList();

                foreach (var item in productId)
                {
                    var productFeature = db.Product_Feature.Where(x => x.Productid == item);
                    db.Product_Feature.RemoveRange(productFeature);
                    db.SaveChanges();

                    var purchaseLedger = db.Purchase_Ledger.Where(x => x.Productid == item);
                    db.Purchase_Ledger.RemoveRange(purchaseLedger);
                    db.SaveChanges();

                    var product = db.Products.Where(x => x.id == item);
                    db.Products.RemoveRange(product);
                    db.SaveChanges();

                }

                if (po.status != "C")
                {
                    db.Purchase_Order.Remove(po);
                    db.SaveChanges();
                }
            }
            Purchase_Order purchaseOrder = new Purchase_Order();
            // First Array Element Order in Front end (Company_Id, Vendor_Id, Product_Type_Id, Total_Count, MainFeature_Id, MainFeature_Value, Main_Unit, Country_Id, Order_No, LC_Number, LC_Date, Purchase_Date, Arrival_Date, Site_Id, Warehouse_Id,Lot_Number)
            purchaseOrder.Companyid = Convert.ToInt32(values[0][0][0]);
            purchaseOrder.Vendorid = Convert.ToInt32(values[0][1][0]);
            purchaseOrder.Product_Typeid = Convert.ToInt32(values[0][2][0]);
            purchaseOrder.qty = Convert.ToInt32(values[0][3][0]);

            int featureTypeid = Convert.ToInt32(values[0][4][0]);
            int featureId = db.Features.FirstOrDefault(x => x.Feature_Typeid == featureTypeid).id;
            purchaseOrder.Featureid = featureId;

            purchaseOrder.pur_count = Convert.ToDouble(values[0][5][0]);
            purchaseOrder.Unit_Measurementid = Convert.ToInt32(values[0][6][0]);
            purchaseOrder.Locationid = Convert.ToInt32(values[0][7][0]);
            purchaseOrder.order_no = values[0][8][0];
            purchaseOrder.lc_number = values[0][9][0] ?? "";
            if (values[0][10][0] =="" || values[0][10][0] == null)
            {
            }
            else if (values[0][10][0] == "Invalid date")
            {

            }
            else
            {
                purchaseOrder.lc_date = Convert.ToDateTime(values[0][10][0]);
            }
            purchaseOrder.purchase_date = Convert.ToDateTime(values[0][11][0]);
            purchaseOrder.status = "";
            purchaseOrder.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
            purchaseOrder.chgd_date = DateTime.UtcNow;

            Purchase_Order po1 = db.Purchase_Order.FirstOrDefault(x => x.order_no == orderNo && x.Companyid== companyId);  // Need to test
            int poid;
            if (po1 == null || po1.status != "C")
            {
                db.Purchase_Order.Add(purchaseOrder);
                db.SaveChanges();
                poid = purchaseOrder.id;
            }
            else
            {
                poid = po1.id;
            }


            for (int i = 0; i < values[2].Length; i++)
            {
                Product product = new Product();
                Purchase_Ledger purchaseLedger = new Purchase_Ledger();

                product.Product_Typeid = Convert.ToInt32(values[0][2][0]);
                product.product_serial = values[2][i][1];
                product.status = "";
                product.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
                product.chgd_date = DateTime.UtcNow;
                db.Products.Add(product);
                db.SaveChanges();

                purchaseLedger.Productid = product.id;
                purchaseLedger.pur_count = Convert.ToDouble(values[2][i][2]);
                purchaseLedger.Locationid = Convert.ToInt32(values[0][14][0]); ;
                purchaseLedger.arrival_date = Convert.ToDateTime(values[0][12][0]);
                purchaseLedger.Purchase_Orderid = poid;
                purchaseLedger.lot_number = values[0][15][0];
                purchaseLedger.status = "";
                purchaseLedger.chgd_date = DateTime.UtcNow;
                purchaseLedger.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
                db.Purchase_Ledger.Add(purchaseLedger);
                db.SaveChanges();

                for (int j = 0; j < values[1].Length; j++)
                {
                    Product_Feature productFeature = new Product_Feature();
                    productFeature.Productid = product.id;
                    productFeature.Featureid = Convert.ToInt32(values[1][j][1]);
                    productFeature.Value = 0;
                    productFeature.Unit_Measurementid = null;//purchaseOrder.Unit_Measurementid;
                    productFeature.status = "";
                    productFeature.chgd_date = DateTime.UtcNow;
                    productFeature.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
                    db.Product_Feature.Add(productFeature);
                    db.SaveChanges();
                }
                if (values.Length == 4)
                {
                    for (int k = 0; k < values[3].Length; k++)
                    {
                        Product_Feature productFeature = new Product_Feature();
                        productFeature.Productid = product.id;
                        var FeatureTypeId = Convert.ToInt32(values[3][k][0]);
                        productFeature.Featureid = db.Features.Where(x => x.Feature_Typeid == FeatureTypeId).FirstOrDefault().id;
                        productFeature.Value = Convert.ToInt32(values[3][k][1]);
                        productFeature.Unit_Measurementid = Convert.ToInt32(values[3][k][2]);
                        productFeature.status = "";
                        productFeature.chgd_date = DateTime.UtcNow;
                        productFeature.chged_by = UserManager.FindById(User.Identity.GetUserId()).UserName;
                        db.Product_Feature.Add(productFeature);
                        db.SaveChanges();
                    }
                }




            }

            return Json(missingProducts.ToArray(), JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public JsonResult GetFormData(string[] cpl)
        {
            int companyId = Convert.ToInt32(cpl[0]);
            string purchaseOrder = cpl[1];
            string lotNumber = cpl[2];
            string[] messages = new string[2];


            if (db.Purchase_Ledger.Include(x => x.Purchase_Order).Where(x => x.lot_number == lotNumber && x.Purchase_Order.order_no == purchaseOrder && x.Purchase_Order.Companyid == companyId && x.status == "C").ToList().Count != 0)
            {
                messages[0] = "C";
                if (db.Purchase_Order.Where(x => x.order_no == purchaseOrder && x.Companyid == companyId && x.status == "C").ToList().Count != 0)
                {
                    messages[1] = "C";
                }
                else
                {
                    messages[1] = "N";
                }
                return Json(messages, JsonRequestBehavior.AllowGet);
            }
            else if (db.Purchase_Ledger.Include(x => x.Purchase_Order).Where(x => x.lot_number == lotNumber && x.Purchase_Order.order_no == purchaseOrder && x.Purchase_Order.Companyid == companyId).ToList().Count != 0)
            {
                messages[0] = "F";
                if (db.Purchase_Order.Where(x => x.order_no == purchaseOrder && x.Companyid == companyId && x.status == "C").ToList().Count != 0)
                {
                    messages[1] = "C";
                }
                else
                {
                    messages[1] = "N";
                }
                var purchaseOrders = db.Purchase_Order.Where(x => x.order_no == purchaseOrder && x.Companyid == companyId).ToList();
                var productAndPurchaseLedger = db.Purchase_Ledger.Include(x => x.Product).Include(x => x.Purchase_Order).Where(x => x.lot_number == lotNumber && x.Purchase_Order.order_no == purchaseOrder).ToList();
                var productId = db.Purchase_Ledger.Include(y => y.Product).Include(y => y.Purchase_Order).Where(y => y.lot_number == lotNumber && y.Purchase_Order.order_no == purchaseOrder && y.Purchase_Order.Companyid==companyId).FirstOrDefault().Productid;
                var productFeature = db.Product_Feature.Include(x => x.Feature).Include(x => x.Feature.Feature_Type).Where(x => x.Productid == productId).ToList();
                var warehouseId = db.Purchase_Ledger.Include(x => x.Purchase_Order).Where(x => x.lot_number == lotNumber && x.Purchase_Order.order_no == purchaseOrder && x.Purchase_Order.Companyid == companyId).FirstOrDefault().Locationid;
                var warehouse = db.Locations.Where(x => x.id == warehouseId);
                var orderData = new dynamic[] { messages, purchaseOrders, productAndPurchaseLedger, productFeature, warehouse };
                return Json(orderData, JsonRequestBehavior.AllowGet);
            }

            else
            {
                messages[0] = "N";
                if (db.Purchase_Order.Where(x => x.order_no == purchaseOrder && x.Companyid == companyId && x.status == "C").ToList().Count != 0)
                {
                    messages[1] = "C";
                }
                else
                {
                    messages[1] = "N";
                }
                return Json(messages, JsonRequestBehavior.AllowGet);
            }

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

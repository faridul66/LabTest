using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Sales
    {
    }

    public class Sales_Order
    {
        public int id { get; set; }
        public int Companyid { get; set; }
        public Company Company  { get; set; }
        public int Customerid { get; set; }
        public Customer Customer { get; set; }
        public int Product_Typeid { get; set; }
        public Product_Type Product_Type { get; set; }
        public int qty { get; set; }
        public int Featureid { get; set; }
        public Feature Feature { get; set; }
        public double sale_count { get; set; }
        public int Unit_Measurementid { get; set; }
        public Unit_Measurement Unit_Measurement { get; set; }
        public int Locationid { get; set; }
        public Location Location { get; set; }
        public string order_no { get; set; }
        public DateTime sell_date { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;
    }

    public class SalesProductFeatures
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int ProductTypeId { get; set; }
        public int FeatureTypeId { get; set; }
        public int FearureId { get; set; }
        public int? UnitId { get; set; }
        public double? TxtValue { get; set; }
        public int CompanyId { get; set; }
        public string LotNumber { get; set; }
    }

    public class SalesOrderProductFeature
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductTypeId { get; set; }
        public int FeatureTypeId { get; set; }
        public int FearureId { get; set; }
        public int? UnitId { get; set; }
        public double? TxtValue { get; set; }
        public int CompanyId { get; set; }
        public string LotNumber { get; set; }
    }

    public class SalesOrderExt
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public int UnitId { get; set; }
        public int OrderId { get; set; }
        public string Lot { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SiteId { get; set; }
        public int WarehouseId { get; set; }
        
    }

}
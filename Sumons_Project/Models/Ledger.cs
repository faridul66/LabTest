using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Ledger
    {
    }

    public class Sales_Ledger
    {
        public int id { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }
        public double sale_count { get; set; }
        public int Locationid { get; set; }
        public Location Location { get; set; }
        public DateTime delivery_date { get; set; }
        public int Sales_Orderid { get; set; }
        public Sales_Order Sales_Order { get; set; }
        public string lot_number { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;

    }

    public class Purchase_Ledger
    {
        public int id { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }
        public double pur_count { get; set; }
        public int Locationid { get; set; }
        public Location Location { get; set; }
        public DateTime arrival_date { get; set; }
        public string lot_number { get; set; }
        public int Purchase_Orderid { get; set; }
        public Purchase_Order Purchase_Order { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;

    }
    public class Consumption_Ledger
    {
        public int id { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }
        public double prod_count { get; set; }
        public int Production_Indentid { get; set; }
        public Production_Indent Production_Indent { get; set; }
        public int Locationid { get; set; }
        public Location Location { get; set; }
        public DateTime consumption_date { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;

    }
    public class Production_Ledger
    {
        public int id { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }
        public double prod_count { get; set; }
        public int Production_Indentid { get; set; }
        public Production_Indent Production_Indent { get; set; }
        public int Locationid { get; set; }
        public Location Location { get; set; }
        public DateTime production_date { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;

    }

    public class General_Ledger
    {
        public int id { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }
        public int Transaction_Typeid { get; set; }
        public Transaction_Type Transaction_Type { get; set; }
        public int trans_ref_id { get; set; }
        public DateTime trans_date { get; set; }
        public bool is_current { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;

    }

    public class Transfer_Ledger
    {
        public int id { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }
        public double tr_count { get; set; }
        public int Transfer_Orderid { get; set; }
        public Transfer_Order Transfer_Order { get; set; }
        public int Locationid { get; set; }
        public Location Location { get; set; }
        public DateTime arrival_date { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;

    }

    public class Residuals
    {
        public int Id { get; set; }
        public int LedgerId { get; set; }
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductionIndentId { get; set; }
        public double ResidualValue { get; set; }
        public double PreviousValue { get; set; }
        public int UnitId { get; set; }
    }
}

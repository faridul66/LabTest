using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Purchase
    {
    }
    public class Purchase_Order
    {
        public int id { get; set; }
        [Display(Name="Company")]
        public int Companyid { get; set; }
        public Company Company { get; set; }
        [Display(Name = "Vendor")]
        public int Vendorid { get; set; }
        public Vendor Vendor { get; set; }

        public int Product_Typeid { get; set; }
        public Product_Type Product_Type { get; set; }
        [Display(Name = "Quantity")]
        public int qty { get; set; }
        [Display(Name = "Feature")]
        public int Featureid { get; set; }
        public Feature Feature { get; set; }
        public double pur_count { get; set; }
        public int Unit_Measurementid { get; set; }
        public Unit_Measurement Unit_Measurement { get; set; }
        public int Locationid { get; set; }
        public Location Location { get; set; }
        [Display(Name = "Purchase Order")]
        public string order_no { get; set; }
        [Display(Name = "LC Number")]
        public string lc_number { get; set; }
        [Display(Name = "LC Date")]
        public DateTime? lc_date { get; set; }
        [Display(Name = "Purchase Date")]
        public DateTime purchase_date { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;
    }

}
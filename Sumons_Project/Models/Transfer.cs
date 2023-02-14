using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Transfer
    {
    }

    public class Transfer_Order
    {
        public int id { get; set; }
        public int from_company_id { get; set; }
        public int to_company_id { get; set; }
        public int Product_Typeid { get; set; }
        public Product_Type Product_Type { get; set; }
        [Display(Name = "QTY")]
        public int qty { get; set; }
        public int Featureid { get; set; }
        public Feature Feature { get; set; }
        public double tr_count { get; set; }
        public int Unit_Measurementid { get; set; }
        public Unit_Measurement Unit_Measurement { get; set; }
        [Display(Name = "Order No")]
        public string order_no { get; set; }
        [Display(Name = "Transfer Date")]
        public DateTime transfer_from_date { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;

    }

    public class TransferOrderExt
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FromSite { get; set; }
        public int FromWarehouse { get; set; }
        public int ToSite { get; set; }
        public int ToWarehouse { get; set; }
    }


    public class TransferProductFeatures
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductTypeId { get; set; }
        public int FeatureTypeId { get; set; }
        public int FearureId { get; set; }
        public int? UnitId { get; set; }
        public double? TxtValue { get; set; }
    }



}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Return_Order
    {
        public int id { get; set; }
        public int Companyid { get; set; }
        public Company Company { get; set; }
        public int Transaction_Typeid { get; set; }
        public Transaction_Type TransactionType { get; set; }
        public DateTime return_date { get; set; }
        public int qty { get; set; }
        public double return_value { get; set; }

        public int Featureid { get; set; }
        public Feature Feature { get; set; }
        public int Unit_Measurementid { get; set; }
        public Unit_Measurement UnitMeasurement { get; set; }
        public string return_order_code { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;

    }




}
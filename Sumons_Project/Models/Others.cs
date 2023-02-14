using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Others
    {
    }

    public class Other_Type
    {
        public int id { get; set; }
        public string type_code { get; set; }
        public string type_name { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;

    }


    public class Other_Consumption
    {
        public int id { get; set; }

        public int Companyid { get; set; }
        public Company Company { get; set; }

        public int Product_Typeid { get; set; }
        public Product_Type Product_Type { get; set; }
        public int Other_Typeid { get; set; }
        public Other_Type Other_Type { get; set; }
        public int qty { get; set; }
        public int cons_feature { get; set; }
        public double cons_count { get; set; }
        public int cons_unit { get; set; }
        public string description { get; set; }
        public DateTime other_start_date { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;

    }

    public class Other_Consumption_Ledger
    {
        public int id { get; set; }

        public int Productid { get; set; }
        public Product Product { get; set; }
        public double cons_count { get; set; }

        public int Other_Consumptionid { get; set; }
        public Other_Consumption Other_Consumption { get; set; }
        public int Locationid { get; set; }
        public Location Location { get; set; }
        public DateTime consumption_date { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;

    }
}
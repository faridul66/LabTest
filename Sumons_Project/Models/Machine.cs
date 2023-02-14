using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Machine
    {
        public int id { get; set; }
        public string name { get; set; }
        public int Machine_Typeid { get; set; }
        public Machine_Type Machine_Type { get; set; }
        public int Companyid { get; set; }
        public Company Company { get; set; }
        public int Locationid { get; set; }
        public Location Location { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;
    }

    public class Machine_Type
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;


    }
    

    public class Machine_Product
    {
        public int id { get; set; }
        public int Machineid { get; set; }
        public Machine Machine { get; set; }
        public int Product_Typeid { get; set; }
        public Product_Type Product_Type { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;
    }
}
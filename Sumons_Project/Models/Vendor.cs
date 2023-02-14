using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Vendor
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;
    }

}
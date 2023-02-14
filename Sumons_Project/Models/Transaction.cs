using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Transaction
    {
    }
    public class Transaction_Type
    {
        public int id { get; set; }
        public string type_code { get; set; }
        public string type_name { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;
    }
    
}
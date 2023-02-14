using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Return_Ledger
    {
        public int id { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }
        public int Return_Orderid { get; set; }
        public Return_Order ReturnOrder { get; set; }
        public int Locationid { get; set; }
        public Location Location { get; set; }
        public DateTime actual_return_date { get; set; }
        public double return_value { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;

    }
}
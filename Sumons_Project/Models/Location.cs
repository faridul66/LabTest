using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Location
    {
        public int id { get; set; }
        public int parent_location { get; set; }
        public int Location_Typeid { get; set; }
        public Location_Type Location_Type { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;

    }




    public class Location_Type
    {
        public int id { get; set; }
        public int? parent_type { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chged_datetime { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Shift
    {
        public int id { get; set; }
        public string shift_code { get; set; }
        public string name { get; set; }
        public int duration { get; set; }
        public int Unit_Measurementid { get; set; }
        public Unit_Measurement Unit_Measurement { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;
    }

    public class Shift_End
    {
        public int id { get; set; }
        public int Production_Indentid { get; set; }
        public Production_Indent Production_Indent { get; set; }
        public double consumption_residual { get; set; }
        public double product_wastage { get; set; }
        public int residual_unit { get; set; }
        public int wastage_unit { get; set; }
        public DateTime shift_end { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Production_Indent
    {
        public int id { get; set; }
        public int Machineid { get; set; }
        public Machine Machine { get; set; }
        public int Product_Typeid { get; set; }
        public Product_Type Product_Type { get; set; }
        public int Shiftid { get; set; }
        public Shift Shift { get; set; }
        public int qty { get; set; }
        public int batch_count { get; set; }
        public int Featureid { get; set; }
        public Feature Feature { get; set; }
        public double prod_count { get; set; }
        public int Unit_Measurementid { get; set; }
        public Unit_Measurement Unit_Measurement { get; set; }
        public string indent_no { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime indent_date { get; set; }
        public DateTime shift_start { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;

    }
    public class Product_Indent_Feature
    {
        public int id { get; set; }
        public int Production_Indentid { get; set; }
        public Production_Indent Production_Indent { get; set; }
        public int? Featureid { get; set; }
        public Feature Feature { get; set; }
        public int? Feature_Typeid { get; set; }
        public Feature_Type Feature_Type { get; set; }
        public double? FeatureValue { get; set; }
        public int? Unit_Measurementid { get; set; }
        public Unit_Measurement Unit_Measurement { get; set; }
    }


    public class Temp_Feature
    {
        public int id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int Transaction_Typeid { get; set; }
        public Transaction_Type Transaction_Type { get; set; }
        public string OrderNo { get; set; }
        public string Lot { get; set; }
        public int? Featureid { get; set; }
        public Feature Feature { get; set; }
        public int? Feature_Typeid { get; set; }
        public Feature_Type Feature_Type { get; set; }
        public double? FeatureValue { get; set; }
        public int? Unit_Measurementid { get; set; }
        public Unit_Measurement Unit_Measurement { get; set; }
    }


}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BJProduction.Models
{
    public class Product
    {
        public int id { get; set; }
        public int Product_Typeid { get; set; }
        public Product_Type Product_Type { get; set; }
        public string product_serial { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;
    }

    public class Product_Type
    {
        public int id { get; set; }
        public int? parent_type { get; set; }
        public string type_code { get; set; }
        [Display(Name = "Product")]
        public string type_name { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;

    }

    public class Feature_Type
    {
        public int id { get; set; }
        public int? parent_type { get; set; }
        public string type_code { get; set; }
        public string type_name { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;

    }

    public class Feature
    {
        public int id { get; set; }
        public int Feature_Typeid { get; set; }
        public Feature_Type Feature_Type { get; set; }
        public string feature_code { get; set; }
        public string feature_name { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;
    }

    public class Product_Feature
    {
        public int id { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }
        public int Featureid { get; set; }
        public Feature Feature { get; set; }
        public double Value { get; set; }
        public int? Unit_Measurementid { get; set; }
        public Unit_Measurement Unit_Measurement { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;
    }


    public class Unit_Measurement
    {
        public int id { get; set; }
        public int? parent_id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int? parent_sum { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;

    }



    public class ProductType_FeatureType
    {
        public int id { get; set; }
        public int Product_Typeid { get; set; }
        public Product_Type Product_Type { get; set; }

        public int Feature_Typeid { get; set; }
        public Feature_Type Feature_Type { get; set; }
        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;
    }


    public class Feature_UnitMeasurement
    {
        public int id { get; set; }

        public int Featureid { get; set; }
        public Feature Feature { get; set; }

        public int Unit_Measurementid { get; set; }
        public Unit_Measurement Unit_Measurement { get; set; }

        public string status { get; set; }
        public string chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.Now;
    }

    public class ProductToConsume
    {
        public int ProductTypeId { get; set; }
        public string ProductSerial { get; set; }
        public double QValue { get; set; }
        public int ProductId { get; set; }
        public bool IsCurrent { get; set; }
        public int LocationId { get; set; }
        public int GLID { get; set; }


    }
}





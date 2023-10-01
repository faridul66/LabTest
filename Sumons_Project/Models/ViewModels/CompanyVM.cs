using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTestRegister.Models.ViewModels
{
    public class CompanyVM
    {
        public int Id { get; set; }
        public string company_name { get; set; }
        public string company_code { get; set; }
        public string address { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTestRegister.Models.ViewModels
{
    public class TestSpecificationVM
    {
        public int Id { get; set; }
        public int MassPerUnit { get; set; }
        public decimal Thikness { get; set; }
        public decimal Static_CBR { get; set; }
        public decimal WideWidthTensile { get; set; }
        public string Elongation { get; set; }
    }
}
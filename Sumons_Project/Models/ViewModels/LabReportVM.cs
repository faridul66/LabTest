using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTestRegister.Models.ViewModels
{
    public class LabReportVM
    {
        public string TestReportNo { get; set; }
        public DateTime TestDate { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DateTime SampleReceivedDate { get; set; }
        public DateTime TestPeriod { get; set; }
        public string SampleReference { get; set; }
        public string SampleNo { get; set; }
        public string SampleDescription { get; set; }
        public string FibreDetails { get; set; }
        public string TestName { get; set; }
        public decimal Spec1 { get; set; }
        public decimal Spec2 { get; set; }
        public decimal Spec3 { get; set; }
        public decimal Spec4 { get; set; }
        public decimal Spec5 { get; set; }
        public decimal Spec6 { get; set; }
        public decimal Spec7 { get; set; }
    }
}
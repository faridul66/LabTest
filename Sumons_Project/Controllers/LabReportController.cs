

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using LabTestRegister.Models;
using LabTestRegister.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTestRegister.Controllers
{
    public class LabReportController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: LabReport
        public ActionResult LabReport()
        {
            return View();
        }
        public ActionResult GetAllDropdownData()
        {
            var response = new CommonVM();
            try
            {
                string sp = "select TestReportNo from LabTestParentInfo";
                var ReportList = context.Database.SqlQuery<LabTestParentInfoVM>(sp).ToList();
                var AllData = new
                {
                    ReportList = ReportList,
                };
                var result = Json(JsonConvert.SerializeObject(AllData));
                return result;
            }
            catch (Exception e)
            {
                response.StatusCode = "-1";
                response.StatusMessage = e.ToString();
                var result1 = Json(JsonConvert.SerializeObject(response));
                return result1;
            }

        }
        //public ActionResult LabTestReport()
        ////{
        ////    string ReportNo = Request.QueryString["ReportNo"];

        ////    string sp = "exec GetAllData_By_ReportNo '" + ReportNo + "'";
        ////    var ReportList = context.Database.SqlQuery<LabReportVM>(sp).ToList();

        ////    ReportDocument reportDocument = new ReportDocument();
        ////    reportDocument.Load(Server.MapPath("~/CrystalReport/LabTestReport.rpt"));
        ////    // Set any required parameters
        ////    reportDocument.SetDataSource(ReportList);

        ////    // Export the report to a stream
        ////    Stream reportStream = reportDocument.ExportToStream(ExportFormatType.PortableDocFormat);

        ////    // Return the report stream as a file result
        ////    return File(reportStream, "application/pdf");
        ////}
        public ActionResult LabTestReport()
        {
            string ReportNo = Request.QueryString["ReportNo"];
            string sp = "exec GetAllData_By_ReportNo '" + ReportNo + "'";
            var ReportList = context.Database.SqlQuery<LabReportVM>(sp).ToList();
            ViewBag.LabReportNo = ReportList[0].TestReportNo;
            ViewBag.TestDate = ReportList[0].TestDate.ToString("dd-MM-yyyy");
            ViewBag.CustomerName = ReportList[0].CustomerName;
            ViewBag.Adderss = ReportList[0].Address;
            ViewBag.SRDate = ReportList[0].SampleReceivedDate.ToString("dd-MM-yyyy");
            ViewBag.TestPeriod = ReportList[0].TestPeriod.ToString("dd-MM-yyyy");
            ViewBag.ReferenceId = ReportList[0].SampleReference;
            ViewBag.NoSample = ReportList[0].SampleNo;
            ViewBag.FDetails = ReportList[0].FibreDetails;
            return new Rotativa.ViewAsPdf("LabReportPdf", ReportList)
            {
                PageOrientation = Rotativa.Options.Orientation.Landscape,
                CustomSwitches = "--footer-left \"Reporting Date: " + DateTime.Now.ToString("dd-MM-yyyy") + "\" " + "--footer-right \"Page: [page] of [toPage]\"        --footer-font-size \"9\" --footer-spacing 5  --footer-font-name \"calibri light\""
            };
        }
    }

    
}
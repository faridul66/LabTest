using LabTestRegister.Models;
using LabTestRegister.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace LabTestRegister.Controllers
{
    public class LabTestEntryController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: LabTestEntry
        public ActionResult CreateLabTestEntry()
        {
            return View();
        }
        public ActionResult GetAllDropdownData()
        {
            var response = new CommonVM();
            try
            {
                var EntryNo = "BRTL-";
                int Increment = 1;
                var date = DateTime.Now.ToString("yyyy-MM-dd");
                DateTime filterdate = Convert.ToDateTime(date);
                string sp1 = "select TestReportNo from LabTestParentInfo where CreationDate='"+ filterdate + "'";
                var LabParentList = context.Database.SqlQuery<LabTestParentInfoVM>(sp1).ToList();
                if (LabParentList.Count == 0)
                {
                    EntryNo = EntryNo+DateTime.Now.ToString("ddMMyyyy") + "_" + Increment;
                }
                else
                {
                    EntryNo = EntryNo + DateTime.Now.ToString("ddMMyyyy") + "_" + (LabParentList.Count + 1);
                }
                string sp = "select company_name,company_code,address from Company";
                var CompanyList = context.Database.SqlQuery<CompanyVM>(sp).ToList();
                string sp3 = "select * from LabTestExperiment";
                var LabData = context.Database.SqlQuery<LabTestExperimentVM>(sp3).ToList();
                string sp2 = "select * from TestSpecification";
                var SpecificationList = context.Database.SqlQuery<TestSpecificationVM>(sp2).ToList();
                var AllData = new
                {
                    LabData = LabData,
                    SpecificationList= SpecificationList,
                    CompanyList= CompanyList,
                    EntryNo= EntryNo
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
        public ActionResult PostData(LabTestParentInfoVM saveData)
        {
            CommonVM response = new CommonVM();
            try
            {
                if (saveData != null)
                {
                    var EmpId = User.Identity.GetUserId();
                    var usr = context.Users.Find(EmpId);
                    response = SaveItemInfo(saveData, usr.UserName);
                    response.StatusCode = "1";
                    response.StatusMessage = "Saved Successfully";
                    var result = Json(JsonConvert.SerializeObject(response));
                    return result;
                }
            }
            catch (Exception e)
            {
                response.StatusCode = "-1";
                response.StatusMessage = e.ToString();

            }
            var result1 = Json(JsonConvert.SerializeObject(response));
            return result1;
        }
        public CommonVM SaveItemInfo(LabTestParentInfoVM Data, string EmpId)
        {
            CommonVM VM_SP_Results = new CommonVM();
            List<LabTestChildInfoVM> datalist = Data.ItemDetail;
            try
            {
                var DataXml = new XElement("ArrayOfItemListXml", datalist.Select(x => new XElement("ItemListXml",
                               new XElement("Id", x.Id),
                               new XElement("TestName", x.TestName),
                               new XElement("Spec1", x.Spec1),
                               new XElement("Spec2", x.Spec2),
                               new XElement("Spec3", x.Spec3),
                               new XElement("Spec4", x.Spec4),
                               new XElement("Spec5", x.Spec5),
                               new XElement("Spec6", x.Spec6),
                               new XElement("Spec7", x.Spec7)
                               )));

                Data.ItemXml = DataXml.ToString();
                string sp = "exec Insert_Update_LabTestInfo '" + Data.Id + "','" + Data.TestReportNo + "','" + Data.CustomerName + "'," +
                    "'" + Data.TestDate + "','" + Data.Address + "','" + Data.SampleReceivedDate + "','" + Data.TestPeriod + "','" + Data.SampleReference +
                    "','" + Data.SampleNo + "','" + Data.SampleDescription + "','" + Data.FibreDetails + "','" + EmpId + "','" + Data.ItemXml + "'";
                var response1 = context.Database.SqlQuery<CommonVM>(sp).FirstOrDefault();
                return response1;
            }
            catch(Exception e)
            {
                VM_SP_Results.StatusCode = "-1";
                VM_SP_Results.StatusMessage = e.ToString();
            }
            return VM_SP_Results;
        }
    }
}
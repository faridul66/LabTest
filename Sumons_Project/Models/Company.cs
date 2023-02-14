using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Company_Code { get; set; }
        public string Company_Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string  status { get; set; }
        public string Chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;
    }

    public class Company_Location
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int Locationid { get; set; }
        public Location Location { get; set; }

        public string status { get; set; }
        public string Chged_by { get; set; }
        public DateTime chgd_date { get; set; } = DateTime.UtcNow;
    }

}
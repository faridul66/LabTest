using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BJProduction.Models
{
    public class CErrorModel
    {
    }
    public class DuplicateBaleError
    {
        public int Id { get; set; }
        public string BaleNumber { get; set; }
        public string Order { get; set; }
        public string Lot { get; set; }
    }

}
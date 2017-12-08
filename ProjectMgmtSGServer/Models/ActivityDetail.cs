using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMgmtSGServer.Models
{
    public class ActivityDetail:BaseClass
    {
        public string ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDesc { get; set; }
        public string ActivityStartDate { get; set; }
        public string ActivityEndDate { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
    }
}
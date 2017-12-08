using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMgmtSGServer.Models
{
    public class ProjectResourceAssignmentDetail:BaseClass
    {

        public string ResourceAssignedId { get; set; }
        public string ProjectCode { get; set; }
        public string ResourceId { get; set; }
        public string AllocationPercentage { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string IsAllocation { get; set; }
    }
}
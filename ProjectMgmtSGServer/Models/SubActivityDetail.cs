using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMgmtSGServer.Models
{
    public class SubActivityDetail: BaseClass
    {
        public string SubActivityId { get; set; }
        public string SubActivityName { get; set; }
        public string SubActivityDesc { get; set; }
        public string SubActivityStartDate { get; set; }
        public string SubActivityEndDate { get; set; }
        public string SelectedMainActivity { get; set; }
    }
}
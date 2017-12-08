using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjectMgmtSGServer.Models
{
    public class ProjectDetail:BaseClass
    {
        [BsonElement("projectCode")]
        public string ProjectCode { get; set; }

        [BsonElement("projectName")]
        public string ProjectName { get; set; }

        [BsonElement("projectDesc")]
        public string ProjectDesc { get; set; }

        [BsonElement("projectStartDate")]
        public string ProjectStartDate { get; set; }

        [BsonElement("projectEndDate")]
        public string ProjectEndDate { get; set; }
    }
}
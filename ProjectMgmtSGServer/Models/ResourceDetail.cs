using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjectMgmtSGServer.Models
{
    public class ResourceDetail:BaseClass
    {

        [BsonElement("resourceId")]
        public string ResourceId { get; set; }

        [BsonElement("ResourceName")]
        public string ResourceName { get; set; }

        [BsonElement("ResourceSupervisor")]
        public string ResourceSupervisor { get; set; }

        [BsonElement("ResourceDOJ")]
        public string ResourceDOJ { get; set; }
    }
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMgmtSGServer.Models
{
    public class BaseClass
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

    }
}
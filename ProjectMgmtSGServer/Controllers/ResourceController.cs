using Newtonsoft.Json;
using ProjectMgmtSGServer.Common;
using ProjectMgmtSGServer.DAL;
using ProjectMgmtSGServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectMgmtSGServer.Controllers
{
    public class ResourceController : BaseApiController
    {
        
        [Route("api/PostResourceNew")]
        public HttpResponseMessage Post([FromBody]ResourceDetail value)
        {
            return ToJson(Instantiator.Instance.resourceBLInstance.Post(value));
        }

        [Route("api/GetAllResources")]
        public HttpResponseMessage GetAll()
        {
            return ToJson(Instantiator.Instance.resourceBLInstance.GetAll());      
        }

        [Route("api/GetResource")]
        public HttpResponseMessage Get(string Id)
        {
            return ToJson(Instantiator.Instance.resourceBLInstance.Get(Id));
        }

        [Route("api/UpdateResource")]
        public HttpResponseMessage Update([FromBody]ResourceDetail value)
        {
            return ToJson(Instantiator.Instance.resourceBLInstance.Update(value));
        }

        [Route("api/DeleteResource")]
        public HttpResponseMessage Delete(string id)
        {
            return ToJson(Instantiator.Instance.resourceBLInstance.Delete(id));
        }
    }
}

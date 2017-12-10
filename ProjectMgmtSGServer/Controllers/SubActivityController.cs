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
    public class SubActivityController : BaseApiController
    {
        
        [Route("api/PostSubActivityNew")]
        public HttpResponseMessage Post([FromBody]SubActivityDetail value)
        {
            return ToJson(Instantiator.Instance.subActivityBLInstance.Post(value));
        }

        [Route("api/GetAllSubActivities")]
        public HttpResponseMessage GetAll()
        {
            return ToJson(Instantiator.Instance.subActivityBLInstance.GetAll());      
        }

        [Route("api/GetSubActivity")]
        public HttpResponseMessage Get(string Id)
        {
            return ToJson(Instantiator.Instance.subActivityBLInstance.Get(Id));
        }

        [Route("api/UpdateSubActivity")]
        [HttpPut]
        public HttpResponseMessage Update([FromBody]SubActivityDetail value)
        {
            return ToJson(Instantiator.Instance.subActivityBLInstance.Update(value));
        }

        
        [Route("api/DeleteSubActivity")]
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            return ToJson(Instantiator.Instance.subActivityBLInstance.Delete(id));
        }
    }
}

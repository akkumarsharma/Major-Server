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
    public class ActivityController : BaseApiController
    {
        
        [Route("api/PostActivityNew")]
        public HttpResponseMessage Post([FromBody]ActivityDetail value)
        {
            return ToJson(Instantiator.Instance.activityBLInstance.Post(value));
        }

        [Route("api/GetAllActivities")]
        public HttpResponseMessage GetAll()
        {
            return ToJson(Instantiator.Instance.activityBLInstance.GetAll());      
        }

        [Route("api/GetActivity")]
        public HttpResponseMessage Get(string Id)
        {
            return ToJson(Instantiator.Instance.activityBLInstance.Get(Id));
        }

        [Route("api/UpdateActivity")]
        public HttpResponseMessage Update([FromBody]ActivityDetail value)
        {
            return ToJson(Instantiator.Instance.activityBLInstance.Update(value));
        }

        [Route("api/DeleteActivity")]
        public HttpResponseMessage Delete(string id)
        {
            return ToJson(Instantiator.Instance.activityBLInstance.Delete(id));
        }
    }
}

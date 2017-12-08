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
    public class ProjectController : BaseApiController
    {
        
        [Route("api/PostProjectNew")]
        public HttpResponseMessage Post([FromBody]ProjectDetail value)
        {
            return ToJson(Instantiator.Instance.projectBLInstance.Post(value));
        }

        [Route("api/GetAllProjects")]
        public HttpResponseMessage GetAll()
        {
            return ToJson(Instantiator.Instance.projectBLInstance.GetAll());      
        }

        [Route("api/GetProject")]
        public HttpResponseMessage Get(string Id)
        {
            return ToJson(Instantiator.Instance.projectBLInstance.Get(Id));
        }

        [Route("api/UpdateProject")]
        public HttpResponseMessage Update([FromBody]ProjectDetail value)
        {
            return ToJson(Instantiator.Instance.projectBLInstance.Update(value));
        }

        [Route("api/DeleteProject")]
        public HttpResponseMessage Delete(string id)
        {
            return ToJson(Instantiator.Instance.projectBLInstance.Delete(id));
        }
    }
}

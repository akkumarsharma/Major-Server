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
    public class ProjectResourceAssignmentController : BaseApiController
    {
        
        [Route("api/PostProjectResourceAssigned")]
        public HttpResponseMessage Post([FromBody]ProjectResourceAssignmentDetail value)
        {
            return ToJson(Instantiator.Instance.projectResourceAssignmentBLInstance.Post(value));
        }

        [Route("api/GetAllProjectResourceAssigned")]
        public HttpResponseMessage GetAll()
        {
            return ToJson(Instantiator.Instance.projectResourceAssignmentBLInstance.GetAll());      
        }

        [Route("api/GetProjectResourceAssigned")]
        public HttpResponseMessage Get(string Id)
        {
            return ToJson(Instantiator.Instance.projectResourceAssignmentBLInstance.Get(Id));
        }

        [Route("api/UpdateProjectResourceAssigned")]
        public HttpResponseMessage Update([FromBody]ProjectResourceAssignmentDetail value)
        {
            return ToJson(Instantiator.Instance.projectResourceAssignmentBLInstance.Update(value));
        }

        [Route("api/DeleteProjectResourceAssigned")]
        public HttpResponseMessage Delete(string id)
        {
            return ToJson(Instantiator.Instance.projectResourceAssignmentBLInstance.Delete(id));
        }
    }
}

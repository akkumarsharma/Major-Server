using MongoDB.Driver;
using ProjectMgmtSGServer.Common;
using ProjectMgmtSGServer.DAL;
using ProjectMgmtSGServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProjectMgmtSGServer.BusinessLayer
{
    public class ResourceBL
    {
        private static readonly object padlock = new object();
        private  Repository<ResourceDetail> _resourceDetailRepository= null;

        private Repository<ResourceDetail> ResourceBLObj
        {
            get
            {
                lock (padlock)
                {
                    if (_resourceDetailRepository == null)
                    {
                        _resourceDetailRepository = new Repository<ResourceDetail>(TableName.resourceDetail);
                    }
                    return _resourceDetailRepository;
                }
            }
        }

        public bool Post([FromBody]ResourceDetail value)
        {
            try
            {
                List<ResourceDetail> list = ResourceBLObj.GetAll();
                var newResourceId = 1;
                if (list.Count()!=0 && !string.IsNullOrEmpty(list.Select(a => int.Parse(a.ResourceId)).Max().ToString()))
                {
                     newResourceId = list.Select(a => int.Parse(a.ResourceId)).Max() + 1;
                }
                value.ResourceId = Convert.ToString(newResourceId);
                ResourceBLObj.Post(value);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update([FromBody]ResourceDetail value)
        {
            try
            {
                var updatedResourceName = Builders<ResourceDetail>.Update.Set(r => r.ResourceName, value.ResourceName);
                var updatedResourceSupervisor = Builders<ResourceDetail>.Update.Set(r => r.ResourceSupervisor, value.ResourceSupervisor);
                var updatedResourceDOJ = Builders<ResourceDetail>.Update.Set(r => r.ResourceDOJ, value.ResourceDOJ);
                var combinedUpdateDefinition = Builders<ResourceDetail>.Update.Combine(updatedResourceName, updatedResourceSupervisor, updatedResourceDOJ);
                ResourceBLObj.Update(combinedUpdateDefinition,value.Id);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public List<ResourceDetail> GetAll()
        {
            List<ResourceDetail> _list = null;
            try
            {
                _list= ResourceBLObj.GetAll();
                return _list;
            }
            catch (Exception ex)
            {
                return _list;
            }
        }

        public ResourceDetail Get(string id)
        {
            ResourceDetail resource = null;
            try
            {
                resource = ResourceBLObj.Get(id);
                return resource;
            }
            catch (Exception ex)
            {
                return resource;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var Id = ResourceBLObj.GetAll().Find(a => a.ResourceId == id).Id;
                ResourceBLObj.Delete(Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
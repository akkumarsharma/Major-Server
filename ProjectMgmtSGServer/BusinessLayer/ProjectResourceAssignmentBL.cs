using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using ProjectMgmtSGServer.Common;
using ProjectMgmtSGServer.DAL;
using ProjectMgmtSGServer.Models;
using System.Web.Http;

namespace ProjectMgmtSGServer.BusinessLayer
{
    public class ProjectResourceAssignmentBL
    {
        private static readonly object padlock = new object();
        private Repository<ProjectResourceAssignmentDetail> _projectResourceAssignmentRepository = null;

        private Repository<ProjectResourceAssignmentDetail> ProjectResourceAssignmentBLObj
        {
            get
            {
                lock (padlock)
                {
                    if (_projectResourceAssignmentRepository == null)
                    {
                        _projectResourceAssignmentRepository = new Repository<ProjectResourceAssignmentDetail>(TableName.projectResourceAssignmentDetail);
                    }
                    return _projectResourceAssignmentRepository;
                }
            }
        }

        public bool Post([FromBody]ProjectResourceAssignmentDetail value)
        {
            try
            {
                List<ProjectResourceAssignmentDetail> list = ProjectResourceAssignmentBLObj.GetAll();
                var newResourceAssignedId = 1;
                if (list.Count() != 0 && !string.IsNullOrEmpty(list.Select(a => int.Parse(a.ResourceAssignedId)).Max().ToString()))
                {
                    newResourceAssignedId = list.Select(a => int.Parse(a.ResourceAssignedId)).Max() + 1;
                }
                value.ResourceAssignedId = Convert.ToString(newResourceAssignedId);
                ProjectResourceAssignmentBLObj.Post(value);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update([FromBody]ProjectResourceAssignmentDetail value)
        {
            try
            {
                var updatedProjectCode = Builders<ProjectResourceAssignmentDetail>.Update.Set(r => r.ProjectCode, value.ProjectCode);
                var updatedResourceId = Builders<ProjectResourceAssignmentDetail>.Update.Set(r => r.ResourceId, value.ResourceId);
                var updatedAllocationPercentage = Builders<ProjectResourceAssignmentDetail>.Update.Set(r => r.AllocationPercentage, value.AllocationPercentage);
                var updatedStartDate = Builders<ProjectResourceAssignmentDetail>.Update.Set(r => r.StartDate, value.StartDate);
                var updatedEndDate = Builders<ProjectResourceAssignmentDetail>.Update.Set(r => r.EndDate, value.EndDate);
                var updatedIsAllocation = Builders<ProjectResourceAssignmentDetail>.Update.Set(r => r.IsAllocation, value.IsAllocation);
                var combinedUpdateDefinition = Builders<ProjectResourceAssignmentDetail>.Update.Combine(updatedProjectCode, updatedResourceId, updatedAllocationPercentage, updatedStartDate, updatedEndDate, updatedIsAllocation);
                var list=ProjectResourceAssignmentBLObj.GetAll();
                var Id=list.Find(a => a.ProjectCode == value.ProjectCode && a.ResourceId == value.ResourceId).Id;
                ProjectResourceAssignmentBLObj.Update(combinedUpdateDefinition, Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ProjectResourceAssignmentDetail> GetAll()
        {
            List<ProjectResourceAssignmentDetail> _list = null;
            try
            {
                _list = ProjectResourceAssignmentBLObj.GetAll();
                return _list;
            }
            catch (Exception ex)
            {
                return _list;
            }
        }

        public ProjectResourceAssignmentDetail Get(string id)
        {
            ProjectResourceAssignmentDetail activity = null;
            try
            {
                activity = ProjectResourceAssignmentBLObj.Get(id);
                return activity;
            }
            catch (Exception ex)
            {
                return activity;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                ProjectResourceAssignmentBLObj.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
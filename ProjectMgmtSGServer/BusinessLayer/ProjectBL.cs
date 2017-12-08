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
    public class ProjectBL
    {
        private static readonly object padlock = new object();
        private  Repository<ProjectDetail> _projectDetailRepository= null;
        private Object thisLock = new Object();

        private Repository<ProjectDetail> ProjectBLObj
        {
            get
            {
                lock (padlock)
                {
                    if (_projectDetailRepository == null)
                    {
                        _projectDetailRepository = new Repository<ProjectDetail>(TableName.projectDetail);
                    }
                    return _projectDetailRepository;
                }
            }
        }

        public string Post([FromBody]ProjectDetail value)
        {
            try
            {
                lock (thisLock)
                {
                    List<ProjectDetail> list = ProjectBLObj.GetAll();
                    var newProjectId = 1;
                    if (list.Count() != 0 && !string.IsNullOrEmpty(list.Select(a => int.Parse(a.ProjectCode)).Max().ToString()))
                    {
                        newProjectId = list.Select(a => int.Parse(a.ProjectCode)).Max() + 1;
                    }
                    value.ProjectCode = Convert.ToString(newProjectId);
                    ProjectBLObj.Post(value);
                    return value.ProjectCode;
                }
            }

            catch (Exception ex)
            {
                return string.Empty ;
            }
        }

        public bool Update([FromBody]ProjectDetail value)
        {
            try
            {
                var updatedProjectName = Builders<ProjectDetail>.Update.Set(r => r.ProjectName, value.ProjectName);
                var updatedProjectDesc = Builders<ProjectDetail>.Update.Set(r => r.ProjectDesc, value.ProjectDesc);
                var updatedProjectStartDate = Builders<ProjectDetail>.Update.Set(r => r.ProjectStartDate, value.ProjectStartDate);
                var updatedProjectEndDate = Builders<ProjectDetail>.Update.Set(r => r.ProjectEndDate, value.ProjectEndDate);
                var combinedUpdateDefinition = Builders<ProjectDetail>.Update.Combine(updatedProjectName, updatedProjectDesc, updatedProjectStartDate, updatedProjectEndDate);
                ProjectBLObj.Update(combinedUpdateDefinition,value.Id);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public List<ProjectDetail> GetAll()
        {       
                List<ProjectDetail> _list = null;
                try
                {
                    _list = ProjectBLObj.GetAll();
                    return _list;
                }
                catch (Exception ex)
                {
                    return _list;
                }                         
        }

        public ProjectDetail Get(string id)
        {
            ProjectDetail project = null;
            try
            {
                project = ProjectBLObj.Get(id);
                return project;
            }
            catch (Exception ex)
            {
                return project;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                ProjectBLObj.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
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
    public class ActivityBL
    {
        private static readonly object padlock = new object();
        private  Repository<ActivityDetail> _activityDetailRepository= null;

        private Repository<ActivityDetail> ActivityBLObj
        {
            get
            {
                lock (padlock)
                {
                    if (_activityDetailRepository == null)
                    {
                        _activityDetailRepository = new Repository<ActivityDetail>(TableName.activityDetail);
                    }
                    return _activityDetailRepository;
                }
            }
        }

        public string Post([FromBody]ActivityDetail value)
        {
            try
            {
                List<ActivityDetail> list = ActivityBLObj.GetAll();
                var newActivityId = 1;
                if (list.Count() != 0 && !string.IsNullOrEmpty(list.Select(a => int.Parse(a.ActivityId)).Max().ToString()))
                {
                    newActivityId = list.Select(a => int.Parse(a.ActivityId)).Max() + 1;
                }
                value.ActivityId = Convert.ToString(newActivityId);
                ActivityBLObj.Post(value);
                return value.ActivityId;
            }

            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public bool Update([FromBody]ActivityDetail value)
        {
            try
            {
                var updatedActivitytName = Builders<ActivityDetail>.Update.Set(r => r.ActivityName, value.ActivityName);
                var updatedActivityDesc = Builders<ActivityDetail>.Update.Set(r => r.ActivityDesc, value.ActivityDesc);
                var updatedActivityStartDate = Builders<ActivityDetail>.Update.Set(r => r.ActivityStartDate, value.ActivityStartDate);
                var updatedActivityEndDate = Builders<ActivityDetail>.Update.Set(r => r.ActivityEndDate, value.ActivityEndDate);
                var updatedSelectedProject = Builders<ActivityDetail>.Update.Set(r => r.ProjectCode, value.ProjectCode);
                var combinedUpdateDefinition = Builders<ActivityDetail>.Update.Combine(updatedActivitytName, updatedActivityDesc, updatedActivityStartDate, updatedActivityEndDate, updatedSelectedProject);
                ActivityBLObj.Update(combinedUpdateDefinition,value.Id);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public List<ActivityDetail> GetAll()
        {
            List<ActivityDetail> _list = null;
            try
            {
                _list= ActivityBLObj.GetAll();
                return _list;
            }
            catch (Exception ex)
            {
                return _list;
            }
        }

        public ActivityDetail Get(string id)
        {
            ActivityDetail activity = null;
            try
            {
                activity = ActivityBLObj.Get(id);
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
                var Id = ActivityBLObj.GetAll().Find(a => a.ActivityId == id).Id;
                ActivityBLObj.Delete(Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
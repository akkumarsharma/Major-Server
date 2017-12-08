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
    public class SubActivityBL
    {
        private static readonly object padlock = new object();
        private  Repository<SubActivityDetail> _subActivityDetailRepository= null;

        private Repository<SubActivityDetail> SubActivityBLObj
        {
            get
            {
                lock (padlock)
                {
                    if (_subActivityDetailRepository == null)
                    {
                        _subActivityDetailRepository = new Repository<SubActivityDetail>(TableName.subActivityDetail);
                    }
                    return _subActivityDetailRepository;
                }
            }
        }

        public bool Post([FromBody]SubActivityDetail value)
        {
            try
            {
                List<SubActivityDetail> list = SubActivityBLObj.GetAll();
                var newSubActivityId = 1;
                if (list.Count() != 0 && !string.IsNullOrEmpty(list.Select(a => int.Parse(a.SubActivityId)).Max().ToString()))
                {
                    newSubActivityId = list.Select(a => int.Parse(a.SubActivityId)).Max() + 1;
                }
                value.SubActivityId = Convert.ToString(newSubActivityId);
                SubActivityBLObj.Post(value);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update([FromBody]SubActivityDetail value)
        {
            try
            {
                var updatedSubActivityId = Builders<SubActivityDetail>.Update.Set(r => r.SubActivityId, value.SubActivityId);
                var updatedSubActivityName = Builders<SubActivityDetail>.Update.Set(r => r.SubActivityName, value.SubActivityName);
                var updatedSubActivityDesc = Builders<SubActivityDetail>.Update.Set(r => r.SubActivityDesc, value.SubActivityDesc);
                var updatedSubActivityStartDate = Builders<SubActivityDetail>.Update.Set(r => r.SubActivityStartDate, value.SubActivityStartDate);
                var updatedSubActivityEndDate = Builders<SubActivityDetail>.Update.Set(r => r.SubActivityEndDate, value.SubActivityEndDate);
                var updatedSelectedMainActivity = Builders<SubActivityDetail>.Update.Set(r => r.SelectedMainActivity, value.SelectedMainActivity);
                var combinedUpdateDefinition = Builders<SubActivityDetail>.Update.Combine(updatedSubActivityId, updatedSubActivityName, updatedSubActivityDesc, updatedSubActivityStartDate, updatedSubActivityEndDate, updatedSelectedMainActivity);
                SubActivityBLObj.Update(combinedUpdateDefinition,value.Id);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public List<SubActivityDetail> GetAll()
        {
            List<SubActivityDetail> _list = null;
            try
            {
                _list= SubActivityBLObj.GetAll();
                return _list;
            }
            catch (Exception ex)
            {
                return _list;
            }
        }

        public SubActivityDetail Get(string id)
        {
            SubActivityDetail activity = null;
            try
            {
                activity = SubActivityBLObj.Get(id);
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
                SubActivityBLObj.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
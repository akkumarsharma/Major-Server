using MongoDB.Driver;
using ProjectMgmtSGServer.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjectMgmtSGServer.Common
{
    public sealed class Instantiator
    {
        private static readonly object padlock = new object();

        private static Instantiator instance = null;
        public static Instantiator Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Instantiator();
                    }
                    return instance;
                }
            }
        }

        public Instantiator()
        {
             resourceBL = new ResourceBL();
             projectBL = new ProjectBL();
             activityBL = new ActivityBL();
             subActivityBL = new SubActivityBL();
             projectResourceAssignmentBL = new ProjectResourceAssignmentBL();
            _mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
        }

        private readonly ResourceBL resourceBL;

        public ResourceBL resourceBLInstance
        {
            get
            {
                return resourceBL;
            }
        }

        private readonly MongoClient _mongoClient;

        public MongoClient mongoClientInstance
        {
            get
            {
                return _mongoClient;
            }
        }

        private readonly ProjectBL projectBL;

        public ProjectBL projectBLInstance
        {
            get
            {
                return projectBL;
            }
        }

        private readonly ActivityBL activityBL;

        public ActivityBL activityBLInstance
        {
            get
            {
                return activityBL;
            }
        }

        private readonly ProjectResourceAssignmentBL projectResourceAssignmentBL;

        public ProjectResourceAssignmentBL projectResourceAssignmentBLInstance
        {
            get
            {
                return projectResourceAssignmentBL;
            }
        }

        private readonly SubActivityBL subActivityBL;

        public SubActivityBL subActivityBLInstance
        {
            get
            {
                return subActivityBL;
            }
        }
    }
}
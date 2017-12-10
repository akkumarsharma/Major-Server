using System;
using System.Linq;
using MongoDB.Driver;
using ProjectMgmtSGServer.Models;
using System.Configuration;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Reflection;
using ProjectMgmtSGServer.Common;
using System.Linq.Expressions;

namespace ProjectMgmtSGServer.DAL
{
    public class Repository<T>: IRepository<T> where T : BaseClass
    {
        private IMongoCollection<T> _collection;
        private Instantiator _instantiator;
        public Repository(string tblName)
        {
            _instantiator = Instantiator.Instance;
             var db = _instantiator.mongoClientInstance.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            _collection = db.GetCollection<T>(tblName);
        }

        public List<T> GetAll()
        {
            return _collection.AsQueryable<T>().ToList();
        }

        public T Get(string id)
        {
            var Id = new ObjectId(id);
            return _collection.AsQueryable<T>().SingleOrDefault(a => a.Id == Id);
        }

        public void Post(T model)
        {
            try
            {
                _collection.InsertOne(model);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(UpdateDefinition<T> combinedUpdateDefinition, ObjectId id)
        {
            try
            {
                UpdateResult updateResult = _collection.UpdateOne<T>(a => a.Id == id, combinedUpdateDefinition, new UpdateOptions() { IsUpsert = true });
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(ObjectId id)
        {
            try
            {
                _collection.DeleteOne(Builders<T>.Filter.Eq("_id",id));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
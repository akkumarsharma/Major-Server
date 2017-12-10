using MongoDB.Bson;
using MongoDB.Driver;
using ProjectMgmtSGServer.Models;
using System.Collections.Generic;

namespace ProjectMgmtSGServer.DAL
{
    public interface IRepository<T> where T : BaseClass
    {
        List<T> GetAll();
        T Get(string id);
        void Post(T model);
        void Update(UpdateDefinition<T> combinedUpdateDefinition, ObjectId id);
        void Delete(ObjectId id);
    }
}
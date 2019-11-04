using AmericaVirtualApi.Contracts;
using AmericaVirtualApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Services
{
    public class LogService : ILogService
    {
        private readonly IMongoCollection<Log> _log;

        public LogService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _log = database.GetCollection<Log>(settings.LogCollectionName);
        }

        public List<Log> GetAll()
        {
            return _log.Find(log => true).ToList();
        }

        public List<Log> GetByUserId(string userId)
        {
            return _log.Find(log => log.UserId == userId).ToList();
        }

        public Log Create(Log log)
        {
            _log.InsertOne(log);
            return log;
        }
    }
}

using MongoDB.Driver;
using StateDashbord.Application.IRepository;
using StateDashbord.Domain.Entities;
using StateDashbord.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Infrastructure.Repository
{
    public class JsonLogRepository : IJsonLogRepository
    {
        private readonly IMongoCollection<JsonRequestLog> _collection;

        public JsonLogRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<JsonRequestLog>("JsonLogs");
        }

        public async Task<Result<int>> SaveJsonAsync(string jsonData)
        {
            var log = new JsonRequestLog
            {
                JsonData = jsonData
            };

            await _collection.InsertOneAsync(log);
            return Result<int>.SuccessResult(1, $"Data Save Successfully", 1);
        }
    }
}

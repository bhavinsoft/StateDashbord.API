using MongoDB.Bson;
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
    public class MongoUserRepository : IMongoUserRepository
    {
        private readonly IMongoCollection<JsonRequestLog> _collection;

        public MongoUserRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<JsonRequestLog>("JsonLogs");
        }
        public async Task<Result<int>> InsertJsonmongoAsync(string jsonData)
        {
            try
            {
                var document = BsonDocument.Parse(jsonData);

                var log = new JsonRequestLog
                {
                    Data = document
                };

                await _collection.InsertOneAsync(log);
                return Result<int>.SuccessResult(1, $"Data Save Successfully", 1);
            }
            catch (Exception ex)
            {

                return Result<int>.FailureResult($"An error occurred: Data Not Save", 0);
            }
           
        }
    }
}

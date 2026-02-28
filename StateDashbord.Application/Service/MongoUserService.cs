using StateDashbord.Application.IRepository;
using StateDashbord.Application.IService;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.Service
{
    public class MongoUserService : IMongoUserService
    {
        private readonly IMongoUserRepository _mongoUserRepository;
        public MongoUserService( IMongoUserRepository mongoUserRepository) {
        _mongoUserRepository = mongoUserRepository;
        }
        public async Task<Result<int>> InsertJsonmongoAsync(string jsonData)
        {
            try
            {
                var result = await _mongoUserRepository.InsertJsonmongoAsync(jsonData);
                if (result.sucess)
                {
                    return Result<int>.SuccessResult(result.data, $"Data Save Successfully", 1);
                }
                else
                {
                    return Result<int>.FailureResult($"An error occurred: Data Not Save", 0);
                }
            }
            catch (Exception ex)
            {

                return Result<int>.FailureResult($"An error occurred: Data Not Save", 0);
            }
            
        }
    }
}

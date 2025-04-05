using StateDashbord.Application.IRepository;
using StateDashbord.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Infrastructure.Repository
{
    public class GenericServices<T> : IGenericServices<T> where T : class
    {
        private readonly DapperContext _dapperConnection;

        public GenericServices(DapperContext dapperConnection)
        {
            _dapperConnection = dapperConnection ?? throw new ArgumentNullException(nameof(dapperConnection));
        }

        public async Task<long> AddOrUpdateAsync(Dictionary<string, object> dictionary, string spQuery)
        {
            var data = (await _dapperConnection.GetListResultAsync<long>(spQuery, CommandType.StoredProcedure, dictionary)).FirstOrDefault();
            return data;
        }

        public async Task<long> AddOrUpdateListAsync(List<Dictionary<string, object>> dictionary, string spQuery)
        {
            var data = (await _dapperConnection.GetMultipleListResultAsync<long>(spQuery, CommandType.StoredProcedure, dictionary)).FirstOrDefault();
            return data;
        }

        public async Task<List<T>> AddOrUpdateWithDataAsync(Dictionary<string, object> dictionary, string spQuery)
        {
            return (await _dapperConnection.GetListResultAsync<T>(spQuery, CommandType.StoredProcedure, dictionary)).ToList();
        }

        public async Task<T> AddOrUpdateWithFirstOrDefaultDataAsync(Dictionary<string, object> dictionary, string spQuery)
        {
            return (await _dapperConnection.GetListResultAsync<T>(spQuery, CommandType.StoredProcedure, dictionary)).FirstOrDefault();
        }

        //public async Task<JsonResponseModel> DeleteAsync(Dictionary<string, object> dictionary, string spQuery)
        //{
        //    JsonResponseModel objReturn = new JsonResponseModel();
        //    try
        //    {
        //        await _dapperConnection.GetListResultAsync<T>(spQuery, CommandType.StoredProcedure, dictionary);
        //        objReturn.strMessage = "Record deleted successfully";
        //        objReturn.isError = false;
        //        objReturn.type = PopupMessageType.success.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogger.Error($"Error in {spQuery}", ex.ToString(), "Generic Class", "Delete");
        //        objReturn.strMessage = "Record not deleted, try again";
        //        objReturn.isError = true;
        //        objReturn.type = PopupMessageType.error.ToString();
        //        throw;
        //    }
        //    return objReturn;
        //}

        public async Task<List<T>> GetCustomAsync(string spQuery, Dictionary<string, object> dictionary)
        {
            return (await _dapperConnection.GetListResultAsync<T>(spQuery, CommandType.StoredProcedure, dictionary)).ToList();
        }

        public async Task<List<T>> GetAsync(string spQuery, Dictionary<string, object> dictionary)
        {
            try
            {
                return (await _dapperConnection.GetListResultAsync<T>(spQuery, CommandType.StoredProcedure, dictionary)).ToList();
            }
            catch (Exception ex)
            {
                // ErrorLogger.Error($"Error in {spQuery}", ex.ToString(), "Generic Class", "Get");
                throw;
            }
        }

        public async Task<T> GetFirstOrDefaultAsync(string spQuery, Dictionary<string, object> dictionary)
        {
            try
            {
                return (await _dapperConnection.GetListResultAsync<T>(spQuery, CommandType.StoredProcedure, dictionary)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //ErrorLogger.Error($"Error in {spQuery}", ex.ToString(), "Generic Class", "GetFirstOrDefault");
                throw;
            }
        }

        public async Task<List<T>> GetAsync(string spQuery)
        {
            try
            {
                return (await _dapperConnection.GetListResultAsync<T>(spQuery, CommandType.StoredProcedure)).ToList();
            }
            catch (Exception ex)
            {
                //ErrorLogger.Error($"Error in {spQuery}", ex.ToString(), "Generic Class", "Get");
                throw;
            }
        }

        public async Task<List<IEnumerable<dynamic>>> GetMultipleResultSetsAsync(string spQuery, Dictionary<string, object> parameters)
        {
            try
            {
                return await _dapperConnection.GetDynamicMultipleResultSetsAsync(spQuery, parameters);
            }
            catch (Exception ex)
            {
                // ErrorLogger.Error($"Error in {spQuery}", ex.ToString(), "Generic Class", "GetMultipleResultSetsAsync");
                throw;
            }
        }

        public async Task<T> GetFirstOrDefaultAsync(string spQuery)
        {
            try
            {
                return (await _dapperConnection.GetListResultAsync<T>(spQuery, CommandType.StoredProcedure)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //   ErrorLogger.Error($"Error in {spQuery}", ex.ToString(), "Generic Class", "GetFirstOrDefault");
                throw;
            }
        }

        public async Task<int> Add(Dictionary<string, object> dictionary, string spQuery)
        {
            return (await _dapperConnection.ExecuteAndReturnIdAsync(spQuery, CommandType.StoredProcedure, dictionary));
        }

        //public async Task<List<T>> GetAsync(string spQuery, ref DynamicParameters dynamicParameters)
        //{
        //    try
        //    {
        //        return (await _dapperConnection.ReadonlyGetListResultAsync<T>(spQuery, CommandType.StoredProcedure, ref dynamicParameters)).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //   //     ErrorLogger.Error($"Error in {spQuery}", ex.ToString(), "Generic Class", "Get");
        //        throw;
        //    }
        //}


    }
}

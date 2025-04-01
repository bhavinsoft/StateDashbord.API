using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IRepository
{
    public interface IGenericServices  <T> where T : class
    {
        Task<long> AddOrUpdateAsync(Dictionary<string, object> dictionary, string spQuery);
        Task<long> AddOrUpdateListAsync(List<Dictionary<string, object>> dictionary, string spQuery);
        Task<List<T>> AddOrUpdateWithDataAsync(Dictionary<string, object> dictionary, string spQuery);
        Task<T> AddOrUpdateWithFirstOrDefaultDataAsync(Dictionary<string, object> dictionary, string spQuery);

        //Task<JsonResponseModel> DeleteAsync(Dictionary<string, object> dictionary, string spQuery);

        Task<List<T>> GetCustomAsync(string spQuery, Dictionary<string, object> dictionary);

        Task<List<T>> GetAsync(string spQuery, Dictionary<string, object> dictionary = null);
        Task<T> GetFirstOrDefaultAsync(string spQuery, Dictionary<string, object> dictionary = null);

        //Task<List<T>> GetAsync(string spQuery, ref DynamicParameters dynamicParameters);
        Task<List<IEnumerable<dynamic>>> GetMultipleResultSetsAsync(string spQuery, Dictionary<string, object> parameters);
    }
}

using Microsoft.Extensions.Logging;
using StateDashbord.Application.IRepository;
using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Infrastructure.Repository
{
    public class UserMasterRepo : IUserMasterRepo
    {
        private readonly IGenericServices<usermaster> _usermserdata;

        private readonly ILogger<UserMasterRepo> _logger;

        public UserMasterRepo(IGenericServices<usermaster> usermserdata
            ,ILogger<UserMasterRepo> logger)
        {
            _usermserdata = usermserdata;
            _logger = logger;
        }

        public async Task<Result<usermaster>> GetUserdatabyusernanepassword(string username, string password)
        {
            try
            {
           
                Dictionary<string, object> PS_Details = new Dictionary<string, object>();
                PS_Details.Add("username", username);
                PS_Details.Add("password", password);

                var userdata =await _usermserdata.AddOrUpdateWithFirstOrDefaultDataAsync(PS_Details, "getuserlogin");

                if (userdata != null)
                {
                    return Result<usermaster>.SuccessResult(userdata, "fechdata succesfull", 1);
                }
                else
                {
                    return Result<usermaster>.FailureResult($"user data not found", 0);

                }

            }
            catch (Exception ex)
            {
                //  Console.WriteLine($"An error occurred: {ex.Message}");
                _logger.LogError($"GetUserdatabyusernanepassword {ex.Message} ");
                return Result<usermaster>.FailureResult($"An error occurred: {ex.Message}", 0);

            }
        }
    }
}

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
    public class DistrictMasterRepo : IDistrictMasterRepo
    {
        private readonly IGenericServices<district_master> _districtmaster;

        private readonly ILogger<UserMasterRepo> _logger;

        public DistrictMasterRepo(IGenericServices<district_master> districtmaster
            , ILogger<UserMasterRepo> logger)
        {

            _districtmaster = districtmaster;
            _logger = logger;
        }

        public async Task<Result<List<district_master>>> getDistrictMaster()
        {
            try
            {
                Dictionary<string, object> districtMaster = new Dictionary<string, object>();
               
                var fridat = await _districtmaster.GetAsync("Getdistrict_master", districtMaster);
                return Result<List<district_master>>.SuccessResult(fridat, "fechdata succesfull", 1);
            }
            catch (Exception ex)
            {

                return Result<List<district_master>>.FailureResult($"An error occurred: {ex.Message}", 0);
            }
        }
    }
}

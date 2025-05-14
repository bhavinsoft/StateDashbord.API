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
    public class PolicestationMasterRepo : IPolicestationMasterRepo
    {
        private readonly IGenericServices<policestation_master> _policestationmaster;

        private readonly ILogger<UserMasterRepo> _logger;

        public PolicestationMasterRepo(IGenericServices<policestation_master> policestationmaster
            , ILogger<UserMasterRepo> logger)
        {
            _policestationmaster = policestationmaster;
            _logger = logger;
        }

        public async Task<Result<List<policestation_master>>> getPolicestationMaster(int id)
        {
            try
            {
                Dictionary<string, object> districtMaster = new Dictionary<string, object>();
                districtMaster.Add("id", id);
                var fridat = await _policestationmaster.GetAsync("Getpolicestation_masterbydis", districtMaster);
                return Result<List<policestation_master>>.SuccessResult(fridat, "fechdata succesfull", 1);
            }
            catch (Exception ex)
            {

                return Result<List<policestation_master>>.FailureResult($"An error occurred: {ex.Message}", 0);
            }
        }
    }
}

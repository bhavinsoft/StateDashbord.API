using Microsoft.Extensions.Logging;
using StateDashbord.Application.IRepository;
using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Infrastructure.Repository
{
    public class CeremonyMasterRepo : ICeremonyMasterRepo
    {
        private readonly IGenericServices<ceremony_master> _ceremonymaster;
        private readonly IGenericServices<ceremony_masterView> _ceremonymasterview;

        private readonly ILogger<UserMasterRepo> _logger;

        public CeremonyMasterRepo(IGenericServices<ceremony_master> ceremonymaster
           , IGenericServices<ceremony_masterView> ceremonymasterview
            , ILogger<UserMasterRepo> logger)
        {
            _ceremonymaster = ceremonymaster;
            _ceremonymasterview = ceremonymasterview;
            _logger = logger;
        }

        public async Task<Result<List<ceremony_masterView>>> getCeremonyMasterList(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            try
            {
                Dictionary<string, object> ceremonyMasterdis = new Dictionary<string, object>();

                ceremonyMasterdis.Add("userid", userid);
                ceremonyMasterdis.Add("userposition", userposition);
                ceremonyMasterdis.Add("rollid", rollid);
                ceremonyMasterdis.Add("from_date", from_date?.ToString("yyyy-MM-dd"));
                ceremonyMasterdis.Add("to_date", to_date?.ToString("yyyy-MM-dd"));
                var resultlist = await _ceremonymasterview.GetAsync("getceremonymasterlist", ceremonyMasterdis);
                return Result<List<ceremony_masterView>>.SuccessResult(resultlist, "fechdata succesfull", 1);
            }
            catch (Exception ex)
            {

                return Result<List<ceremony_masterView>>.FailureResult($"An error occurred: {ex.Message}", 0);
            }
        }

        public async Task<Result<int>> PostCeremonyMaster(ceremony_master ceremonyMaster)
        {
            Dictionary <string, object> ceremony_master = new Dictionary<string, object>();
            ceremony_master.Add("id", ceremonyMaster.recid);
            ceremony_master.Add("district_id", ceremonyMaster.district_id);
            ceremony_master.Add("policestation_id", ceremonyMaster.policestation_id);
            ceremony_master.Add("ceremony_details", ceremonyMaster.ceremony_details);
            ceremony_master.Add("ceremony_venue", ceremonyMaster.ceremony_venue);
            ceremony_master.Add("ceremony_date", ceremonyMaster.ceremony_date);
            ceremony_master.Add("remarks", ceremonyMaster.remarks);
            var friid =await _ceremonymaster.Add(ceremony_master, "InsertCeremonyMaster");

            if (friid > 0)
            {
                return Result<int>.SuccessResult(friid, $"Data Save Successfully", 1);
            }
            else
            {
                return Result<int>.FailureResult($"An error occurred: Data Not Save", 0);
            }
            
        }
    }
}

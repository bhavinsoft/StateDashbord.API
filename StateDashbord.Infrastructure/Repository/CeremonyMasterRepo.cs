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

        private readonly ILogger<UserMasterRepo> _logger;

        public CeremonyMasterRepo(IGenericServices<ceremony_master> ceremonymaster
            ,ILogger<UserMasterRepo> logger)
        {
            _ceremonymaster = ceremonymaster;
            _logger = logger;
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

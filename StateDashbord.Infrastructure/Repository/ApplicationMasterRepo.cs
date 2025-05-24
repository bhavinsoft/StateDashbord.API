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
    public class ApplicationMasterRepo : IApplicationMasterRepo
    {
        private readonly IGenericServices<application_master> _applicationmaster;
        private readonly IGenericServices<application_masterView> _applicationmasterview;

        private readonly ILogger<UserMasterRepo> _logger;

        public ApplicationMasterRepo(IGenericServices<application_master> applicationmaster
            , IGenericServices<application_masterView> applicationmasterview
            , ILogger<UserMasterRepo> logger)
        {
            _applicationmaster = applicationmaster;
            _applicationmasterview = applicationmasterview;
            _logger = logger;
        }

        public async Task<Result<List<application_masterView>>> getApplicationMasterList(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            try
            {
                Dictionary<string, object> applicationMasterdis = new Dictionary<string, object>();

                applicationMasterdis.Add("userid", userid);
                applicationMasterdis.Add("userposition", userposition);
                applicationMasterdis.Add("rollid", rollid);
                applicationMasterdis.Add("from_date", from_date?.ToString("yyyy-MM-dd"));
                applicationMasterdis.Add("to_date", to_date?.ToString("yyyy-MM-dd"));
                var resultlist = await _applicationmasterview.GetAsync("getapplicationmasterlist", applicationMasterdis);
                return Result<List<application_masterView>>.SuccessResult(resultlist, "fechdata succesfull", 1);
            }
            catch (Exception ex)
            {

                return Result<List<application_masterView>>.FailureResult($"An error occurred: {ex.Message}", 0);
            }
        }

        public async Task<Result<int>> PostApplicationMaster(application_master applicationMaster)
        {
            Dictionary<string, object> application_master = new Dictionary<string, object>();
            application_master.Add("id",applicationMaster.recid);
            application_master.Add("district_id", applicationMaster.district_id);
            application_master.Add("policestation_id", applicationMaster.policestation_id);
            application_master.Add("application_Details", applicationMaster.application_Details);
            application_master.Add("applicant_name", applicationMaster.applicant_name);
            application_master.Add("applicant_address", applicationMaster.applicant_address);
            application_master.Add("applicant_mobile", applicationMaster.applicant_mobile);
            application_master.Add("applicant_organization", applicationMaster.applicant_organization);
            application_master.Add("application_submitted_office", applicationMaster.application_submitted_office);
            application_master.Add("applicants_number", applicationMaster.applicants_number);
            application_master.Add("application_due_date", applicationMaster.application_due_date);
            application_master.Add("remarks", applicationMaster.remarks);
            var friid = await _applicationmaster.Add(application_master, "InsertApplicationMaster");
            if (friid > 0)
            {
                return Result<int>.SuccessResult(friid, $"Data Save Successfully", 1);

            }
            else {
                return Result<int>.FailureResult($"An error occurred: Data Not Save", 0);

            }
        }
    }
}

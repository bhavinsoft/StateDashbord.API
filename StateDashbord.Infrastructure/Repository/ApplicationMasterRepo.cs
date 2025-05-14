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

        private readonly ILogger<UserMasterRepo> _logger;

        public ApplicationMasterRepo(IGenericServices<application_master> applicationmaster
            , ILogger<UserMasterRepo> logger)
        {
            _applicationmaster = applicationmaster;
            _logger = logger;
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

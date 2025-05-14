using StateDashbord.Application.IRepository;
using StateDashbord.Application.IService;
using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateDashbord.Application.Service
{
    public class ApplicationMasterService : IApplicationMasterService
    {
        private readonly IApplicationMasterRepo _applicationMasterRepo;

        public ApplicationMasterService(IApplicationMasterRepo applicationMasterRepo)
        {
            _applicationMasterRepo = applicationMasterRepo;

        }

        public async Task<Result<int>> PostApplicationMaster(application_masterDto applicationMaster)
        {
            application_master application_Master = new application_master();
            application_Master.recid = applicationMaster.recid;
            application_Master.district_id = applicationMaster.district_id;
            application_Master.policestation_id = applicationMaster.policestation_id;
            application_Master.application_Details = applicationMaster.application_Details;
            application_Master.applicant_name = applicationMaster.applicant_name;
            application_Master.applicant_address = applicationMaster.applicant_address;
            application_Master.applicant_mobile = applicationMaster.applicant_mobile;
            application_Master.applicant_organization = applicationMaster.applicant_organization;
            application_Master.application_submitted_office = applicationMaster.application_submitted_office;
            application_Master.applicants_number = applicationMaster.applicants_number;
            application_Master.application_due_date = applicationMaster.application_due_date;
            application_Master.remarks = applicationMaster.remarks;
            var result = await _applicationMasterRepo.PostApplicationMaster(application_Master);
            if (result.sucess)
            {
                return Result<int>.SuccessResult(result.data, $"Data Save Successfully", 1);
            }
            else
            {
                return Result<int>.FailureResult($"An error occurred: Data Not Save", 0);
            }
        }
    }
}

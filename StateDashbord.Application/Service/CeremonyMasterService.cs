using StateDashbord.Application.IRepository;
using StateDashbord.Application.IService;
using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateDashbord.Application.Service
{
    public class CeremonyMasterService : ICeremonyMasterService
    {
        private readonly ICeremonyMasterRepo _ceremonyMasterRepo;    
        
        public CeremonyMasterService(ICeremonyMasterRepo ceremonyMasterRepo )
        {
            _ceremonyMasterRepo = ceremonyMasterRepo;
        }

        public async Task<Result<List<ceremony_masterViewDto>>> getCeremonyMasterList(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var result = await _ceremonyMasterRepo.getCeremonyMasterList(userid, userposition, rollid, from_date, to_date);

            var ceremonyDtoList = result.data.Select(x => new ceremony_masterViewDto
            {
                recid = x.recid,
                district_id = x.district_id,
                district_name = x.district_name,
                policestation_id = x.policestation_id,
                policestation_name = x.policestation_name,
                ceremony_details = x.ceremony_details,
                ceremony_venue = x.ceremony_venue,
                ceremony_date = x.ceremony_date,
                createdate = x.createdate,
                remarks = x.remarks,

            }).ToList();

            return Result<List<ceremony_masterViewDto>>.SuccessResult(ceremonyDtoList, "fechdata succesfull", 1);
        }

        public async Task<Result<int>> PostCeremonyMaster(ceremony_masterDto ceremonyMaster)
        {
            ceremony_master ceremony_Master = new ceremony_master();
            ceremony_Master.recid = ceremonyMaster.recid;
            ceremony_Master.district_id = ceremonyMaster.district_id;
            ceremony_Master.policestation_id = ceremonyMaster.policestation_id;
            ceremony_Master.ceremony_details = ceremonyMaster.ceremony_details;
            ceremony_Master.ceremony_venue = ceremonyMaster.ceremony_venue;
            ceremony_Master.ceremony_date = ceremonyMaster.ceremony_date;
            ceremony_Master.remarks = ceremonyMaster.remarks;
            var result = await _ceremonyMasterRepo.PostCeremonyMaster(ceremony_Master);
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

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
    public class PolicestationMasterService : IPolicestationMasterService
    {
        private readonly IPolicestationMasterRepo _policestationMasterRepo;    
       
        public PolicestationMasterService(IPolicestationMasterRepo policestationMasterRepo)
        {
           _policestationMasterRepo = policestationMasterRepo;
        }

        public async Task<Result<List<policestation_masterDto>>> getPolicestationMaster(int id)
        {
            var result = await _policestationMasterRepo.getPolicestationMaster(id);

            var PolicestationList = result.data.Select(x => new policestation_masterDto
            {
                recid = x.recid,
                districtid =x.districtid,
                policestation_name=x.policestation_name,
                policestation_code=x.policestation_code,
                createdate =x.createdate
            }).ToList();

            return Result<List<policestation_masterDto>>.SuccessResult(PolicestationList, "fechdata succesfull", 1);
        }
    }
}

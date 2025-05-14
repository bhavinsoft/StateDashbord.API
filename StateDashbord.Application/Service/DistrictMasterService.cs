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
    public class DistrictMasterService : IDistrictMasterService
    {
        private readonly IDistrictMasterRepo _districtMasterRepo;  
     
        public DistrictMasterService(IDistrictMasterRepo districtMasterRepo)
        {
            _districtMasterRepo = districtMasterRepo;

        }

        public async Task<Result<List<district_masterDto>>> getDistrictMaster()
        {
            var result = await _districtMasterRepo.getDistrictMaster();

            var DistrictMasterList = result.data.Select(x => new district_masterDto
            {
                recid=x.recid,
                district_name=x.district_name,
                district_code=x.district_code,
                createdate=x.createdate
            }).ToList();

            return Result<List<district_masterDto>>.SuccessResult(DistrictMasterList, "fechdata succesfull", 1);
        }
    }
}

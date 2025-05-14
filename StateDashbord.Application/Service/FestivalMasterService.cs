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
    public class FestivalMasterService : IFestivalMasterService
    {
        private readonly IFestivalMasterRepo _festivalMasterRepo; 
      
        public FestivalMasterService(IFestivalMasterRepo festivalMasterRepo)
        {
            _festivalMasterRepo = festivalMasterRepo;
        }

        public async Task<Result<int>> PostFestivalMaster(festival_masterDto festivalMaster)
        {
            festival_master festival_Master = new festival_master();
            festival_Master.recid = festivalMaster.recid;
            festival_Master.district_id = festivalMaster.district_id;
            festival_Master.policestation_id = festivalMaster.policestation_id;
            festival_Master.festival_details = festivalMaster.festival_details;
            festival_Master.festival_date = festivalMaster.festival_date;
            festival_Master.remarks = festivalMaster.remarks;
            var result =await _festivalMasterRepo.PostFestivalMaster(festival_Master);
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

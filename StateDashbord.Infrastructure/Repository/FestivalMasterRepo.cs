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
    public class FestivalMasterRepo : IFestivalMasterRepo
    {
        private readonly IGenericServices<festival_master> _festivalmaster;
        private readonly IGenericServices<festival_masterView> _festivalmasterview;

        private readonly ILogger<UserMasterRepo> _logger;

        public FestivalMasterRepo(IGenericServices<festival_master> festivalmaster
            , IGenericServices<festival_masterView> festivalmasterview
            , ILogger<UserMasterRepo> logger)
        {
         _festivalmaster = festivalmaster;
            _festivalmasterview = festivalmasterview;
            _logger = logger;
        }

        public async Task<Result<List<festival_masterView>>> getFestivalMasterList(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            try
            {
                Dictionary<string, object> festivalMasterdis = new Dictionary<string, object>();

                festivalMasterdis.Add("userid", userid);
                festivalMasterdis.Add("userposition", userposition);
                festivalMasterdis.Add("rollid", rollid);
                festivalMasterdis.Add("from_date", from_date?.ToString("yyyy-MM-dd"));
                festivalMasterdis.Add("to_date", to_date?.ToString("yyyy-MM-dd"));
                var resultlist = await _festivalmasterview.GetAsync("getfestivalmasterlist", festivalMasterdis);
                return Result<List<festival_masterView>>.SuccessResult(resultlist, "fechdata succesfull", 1);
            }
            catch (Exception ex)
            {

                return Result<List<festival_masterView>>.FailureResult($"An error occurred: {ex.Message}", 0);
            }
        }

        public  async Task<Result<int>> PostFestivalMaster(festival_master festivalMaster)
        {
             Dictionary<string, object> festival_master = new Dictionary<string, object>();
            festival_master.Add("id", festivalMaster.recid);
            festival_master.Add("district_id", festivalMaster.district_id);
            festival_master.Add("policestation_id", festivalMaster.policestation_id);
            festival_master.Add("festival_details", festivalMaster.festival_details);
            festival_master.Add("festival_date", festivalMaster.festival_date);
            festival_master.Add("remarks", festivalMaster.remarks);
            var friid = await _festivalmaster.Add(festival_master, "InsertFestivalMaster");
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

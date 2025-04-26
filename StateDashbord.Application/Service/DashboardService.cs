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
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepo _dashboardRepo;
        public DashboardService(IDashboardRepo dashboardRepo)
        {
            _dashboardRepo = dashboardRepo;
        }

        public async Task<Result<List<DashbordCount>>> getDashboardcountServicedata(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
          
            var dashboardcount = await _dashboardRepo.getDashboardcountdata(userid, userposition, rollid,from_date,to_date);


            return Result<List<DashbordCount>>.SuccessResult(dashboardcount.data, "fechdata succesfull", 1);


        }

        public async Task<Result<List<DashbordCount>>> getDashboardcountServicedataotherinfo(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var dashboardcountother = await _dashboardRepo.getDashboardcountdataotherinfo(userid, userposition, rollid, from_date, to_date);


            return Result<List<DashbordCount>>.SuccessResult(dashboardcountother.data, "fechdata succesfull", 1);

        }
    }
}

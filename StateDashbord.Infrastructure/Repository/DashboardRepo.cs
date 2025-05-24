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
    public class DashboardRepo : IDashboardRepo
    {
        private readonly IGenericServices<DashbordCount> _dashbordcoutdata;

        public DashboardRepo(IGenericServices<DashbordCount> dashbordcoutdata)
        {
            _dashbordcoutdata = dashbordcoutdata;
        }

        public async Task<Result<List<DashbordCount>>> getDashboardcountdata(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            try
            {
                Dictionary<string, object> dashboardcountdis = new Dictionary<string, object>();
                dashboardcountdis.Add("userid", userid);
                dashboardcountdis.Add("userposition", userposition);
                dashboardcountdis.Add("rollid", rollid);
                dashboardcountdis.Add("from_date", from_date?.ToString("yyyy-MM-dd"));
                dashboardcountdis.Add("to_date", to_date?.ToString("yyyy-MM-dd"));
                var dashborddata = await _dashbordcoutdata.GetAsync("dashbosrdcount", dashboardcountdis);
                return Result<List<DashbordCount>>.SuccessResult(dashborddata, "fechdata succesfull", 1);

            }
            catch (Exception ex)
            {

                return Result<List<DashbordCount>>.FailureResult($"An error occurred: {ex.Message}", 0);

            }

        }

        public async Task<Result<List<DashbordCount>>> getDashboardcountdataacf(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            try
            {
                Dictionary<string, object> dashboardcountdis = new Dictionary<string, object>();
                dashboardcountdis.Add("userid", userid);
                dashboardcountdis.Add("userposition", userposition);
                dashboardcountdis.Add("rollid", rollid);
                dashboardcountdis.Add("from_date", from_date?.ToString("yyyy-MM-dd"));
                dashboardcountdis.Add("to_date", to_date?.ToString("yyyy-MM-dd"));
                var dashborddata = await _dashbordcoutdata.GetAsync("dashbosrdcount_acf", dashboardcountdis);
                return Result<List<DashbordCount>>.SuccessResult(dashborddata, "fechdata succesfull", 1);

            }
            catch (Exception ex)
            {

                return Result<List<DashbordCount>>.FailureResult($"An error occurred: {ex.Message}", 0);

            }
        }

        public async Task<Result<List<DashbordCount>>> getDashboardcountdataotherinfo(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            try
            {
                Dictionary<string, object> dashboardcountdis = new Dictionary<string, object>();
                dashboardcountdis.Add("userid", userid);
                dashboardcountdis.Add("userposition", userposition);
                dashboardcountdis.Add("rollid", rollid);
                dashboardcountdis.Add("from_date", from_date?.ToString("yyyy-MM-dd"));
                dashboardcountdis.Add("to_date", to_date?.ToString("yyyy-MM-dd"));
                var dashborddata = await _dashbordcoutdata.GetAsync("dashbosrdcount_otherinfo", dashboardcountdis);
                return Result<List<DashbordCount>>.SuccessResult(dashborddata, "fechdata succesfull", 1);

            }
            catch (Exception ex)
            {

                return Result<List<DashbordCount>>.FailureResult($"An error occurred: {ex.Message}", 0);

            }
        }

        public async Task<Result<List<DashbordCount>>> getDashboardcountdataprogram(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            try
            {
                Dictionary<string, object> dashboardcountdis = new Dictionary<string, object>();
                dashboardcountdis.Add("userid", userid);
                dashboardcountdis.Add("userposition", userposition);
                dashboardcountdis.Add("rollid", rollid);
                dashboardcountdis.Add("from_date", from_date?.ToString("yyyy-MM-dd"));
                dashboardcountdis.Add("to_date", to_date?.ToString("yyyy-MM-dd"));
                var dashborddata = await _dashbordcoutdata.GetAsync("dashbosrdcount_program", dashboardcountdis);
                return Result<List<DashbordCount>>.SuccessResult(dashborddata, "fechdata succesfull", 1);

            }
            catch (Exception ex)
            {

                return Result<List<DashbordCount>>.FailureResult($"An error occurred: {ex.Message}", 0);

            }
        }
    }
    
}


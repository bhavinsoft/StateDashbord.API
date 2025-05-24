using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StateDashbord.Application.IService;
using StateDashbord.Application.Service;
using StateDashbord.Domain.Entities;

namespace StateDashbord.API.Controllers
{
  
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("GetDashboardCount")]
        public async Task<ActionResult<Result<List<DashbordCount>>>> GetDashboardCount(int userid, int userposition, int rollid,DateOnly? from_date ,DateOnly? to_date)
        {

            var dashbordcountdata = await _dashboardService.getDashboardcountServicedata(userid, userposition, rollid, from_date, to_date);

            if (dashbordcountdata?.data == null)
            {
                return NotFound(dashbordcountdata);
            }
            return Ok(dashbordcountdata);
        }

        [HttpGet("GetDashboardCountotherinfo")]
        public async Task<ActionResult<Result<List<DashbordCount>>>> GetDashboardCountotherinfo(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {

            var dashbordcountdataother = await _dashboardService.getDashboardcountServicedataotherinfo(userid, userposition, rollid, from_date, to_date);

            if (dashbordcountdataother?.data == null)
            {
                return NotFound(dashbordcountdataother);
            }
            return Ok(dashbordcountdataother);
        }

        [HttpGet("GetDashboardCountacf")]
        public async Task<ActionResult<Result<List<DashbordCount>>>> GetDashboardCountacf(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {

            var dashbordcountdataacf = await _dashboardService.getDashboardcountdataacf(userid, userposition, rollid, from_date, to_date);

            if (dashbordcountdataacf?.data == null)
            {
                return NotFound(dashbordcountdataacf);
            }
            return Ok(dashbordcountdataacf);
        }

        [HttpGet("GetDashboardCountprogram")]
        public async Task<ActionResult<Result<List<DashbordCount>>>> GetDashboardCountprogram(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {

            var dashbordcountdataprogram = await _dashboardService.getDashboardcountdataprogram(userid, userposition, rollid, from_date, to_date);

            if (dashbordcountdataprogram?.data == null)
            {
                return NotFound(dashbordcountdataprogram);
            }
            return Ok(dashbordcountdataprogram);
        }
    }
}

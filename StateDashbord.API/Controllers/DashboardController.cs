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


    }
}

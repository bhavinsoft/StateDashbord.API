using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StateDashbord.Application.IService;
using StateDashbord.Application.Model;
using StateDashbord.Application.Service;
using StateDashbord.Domain.Entities;

namespace StateDashbord.API.Controllers
{
  
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DistrictMasterController : ControllerBase
    {
        private readonly IDistrictMasterService _districtMasterService;
        public DistrictMasterController(IDistrictMasterService districtMasterService)
        {
            _districtMasterService = districtMasterService;
        }

        [HttpGet("GetDistrictMaster")]
        public async Task<ActionResult<Result<List<district_masterDto>>>> GetDistrictMaster()
        {
            var result = await _districtMasterService.getDistrictMaster();
            return Ok(result);
        }
    }
}

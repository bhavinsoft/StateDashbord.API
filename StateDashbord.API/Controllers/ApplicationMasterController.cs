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
    public class ApplicationMasterController : ControllerBase
    {
        private readonly IApplicationMasterService _applicationMasterService;
        public ApplicationMasterController(IApplicationMasterService applicationMasterService)
        {
            _applicationMasterService = applicationMasterService;
        }

        [HttpPost("PostApplicationMaster")]
        public async Task<ActionResult<Result<int>>> PostApplicationMaster([FromBody] application_masterDto  applicationMasterDto)
        {
            var result = await _applicationMasterService.PostApplicationMaster(applicationMasterDto);
            return Ok(result);
        }

        [HttpGet("GetApplicationMasterList")]
        public async Task<ActionResult<Result<List<application_masterViewDto>>>> GetApplicationMasterList(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var result = await _applicationMasterService.getApplicationMasterList(userid, userposition, rollid, from_date, to_date);
            return Ok(result);
        }
    }
}

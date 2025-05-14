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

    }
}

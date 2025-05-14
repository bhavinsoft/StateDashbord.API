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
    public class PolicestationMasterController : ControllerBase
    {
        private readonly IPolicestationMasterService  _policestationMasterService;
        public PolicestationMasterController(IPolicestationMasterService policestationMasterService)
        {
            _policestationMasterService = policestationMasterService;
        }

        [HttpGet("GetPolicestationMaster")]
        public async Task<ActionResult<Result<List<policestation_masterDto>>>> GetPolicestationMaster(int id)
        {
            var result = await _policestationMasterService.getPolicestationMaster(id);
            return Ok(result);
        }

    }
}

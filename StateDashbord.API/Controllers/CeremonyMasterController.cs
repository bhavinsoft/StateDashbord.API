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
    public class CeremonyMasterController : ControllerBase
    {
        private readonly ICeremonyMasterService _ceremonyMasterService;
        public CeremonyMasterController(ICeremonyMasterService ceremonyMasterService)
        {
            _ceremonyMasterService = ceremonyMasterService;
        }

        [HttpPost("PostCeremonyMaster")]
        public async Task<ActionResult<Result<int>>> PostCeremonyMaster([FromBody] ceremony_masterDto  ceremonyMasterDto)
        {
            var result = await _ceremonyMasterService.PostCeremonyMaster(ceremonyMasterDto);
            return Ok(result);
        }



    }
}

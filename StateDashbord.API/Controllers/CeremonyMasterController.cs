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
        [HttpGet("GetCeremonyMasterList")]
        public async Task<ActionResult<Result<List<ceremony_masterViewDto>>>> GetCeremonyMasterList(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var result = await _ceremonyMasterService.getCeremonyMasterList(userid, userposition, rollid, from_date, to_date);
            return Ok(result);
        }



    }
}

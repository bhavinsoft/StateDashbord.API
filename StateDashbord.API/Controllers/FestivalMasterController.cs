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
    public class FestivalMasterController : ControllerBase
    {
        private readonly IFestivalMasterService _festivalMasterService;
        public FestivalMasterController(IFestivalMasterService festivalMasterService)
        {
            _festivalMasterService = festivalMasterService;
        }

        [HttpPost("PostFestivalMaster")]
        public async Task<ActionResult<Result<int>>> PostFestivalMaster([FromBody] festival_masterDto festivalMasterDto)
        {
            var result = await _festivalMasterService.PostFestivalMaster(festivalMasterDto);
            return Ok(result);

        }
    }
}

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

        [HttpGet("GetFestivalMasterList")]
        public async Task<ActionResult<Result<List<festival_masterViewDto>>>> GetFestivalMasterList(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var result = await _festivalMasterService.getFestivalMasterList(userid, userposition, rollid, from_date, to_date);
            return Ok(result);
        }
    }
}

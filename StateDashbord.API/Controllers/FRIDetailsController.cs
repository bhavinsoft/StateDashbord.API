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
    public class FRIDetailsController : ControllerBase
    {
        private readonly IFriDetailsService _friDetailsService;

        public FRIDetailsController(IFriDetailsService friDetailsService)
        {
            _friDetailsService = friDetailsService;
        }

        [HttpGet("SysFRIData")]
        public async Task<IActionResult> SysFRIData(DateOnly? from_date, DateOnly? to_date)
        {
            FriRequest friRequest = new FriRequest();
            friRequest.from_date = from_date;
            friRequest.to_date = from_date; 

            var fridata = await _friDetailsService.sysFriDetails(friRequest);
            return Ok(fridata);
        }


        [HttpGet("GetFRIdataList")]
        public async Task<ActionResult<Result<List<FridataListDto>>>> GetFRIdataListByType(int id, int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var fridata = await _friDetailsService.getFriDataByType(id, userid, userposition, rollid, from_date, to_date);
            return Ok(fridata); 
        }

        [HttpGet("GetFRIdataListformap")]
        public async Task<ActionResult<Result<List<FridataListDto>>>> GetFRIdataListformap(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var fridata = await _friDetailsService.getFriDataByTypeformap( userid, userposition, rollid, from_date, to_date);
            return Ok(fridata);
        }

        [HttpGet("GetFRIdatabyid")]
        public async Task<ActionResult<Result<FRIDetailDto>>> GetFRIdatabyid(int id, int userid, int userposition, int rollid)
        {
            var fridata = await _friDetailsService.getFriDataByid(id, userid, userposition, rollid);
            return Ok(fridata);
        }
    }
}

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
    public class FRIDetailsController : ControllerBase
    {
        private readonly IFriDetailsService _friDetailsService;

        public FRIDetailsController(IFriDetailsService friDetailsService)
        {
            _friDetailsService = friDetailsService;
        }

        [HttpGet("SyaFRIData")]
        public async Task<IActionResult> SyaFRIData(string from_date,string to_date)
        {
            FriRequest friRequest = new FriRequest();
            friRequest.from_date = from_date;
            friRequest.to_date = from_date; 

            var movieList = await _friDetailsService.sysFriDetails(friRequest);
            return Ok(movieList);
        }
    }
}

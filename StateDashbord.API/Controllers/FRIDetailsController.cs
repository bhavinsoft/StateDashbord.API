using Microsoft.AspNetCore.Mvc;
using StateDashbord.Application.IService;
using StateDashbord.Application.Service;
using StateDashbord.Domain.Entities;

namespace StateDashbord.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FRIDetailsController : ControllerBase
    {
        private readonly IFriDetailsService _friDetailsService;

        public FRIDetailsController(IFriDetailsService friDetailsService)
        {
            _friDetailsService = friDetailsService;
        }

        [HttpGet("SyaFRIData")]
        public async Task<IActionResult> SyaFRIData()
        {
            FriRequest friRequest = new FriRequest();
            friRequest.from_date = "2020-01-01";

            friRequest.to_date = "2020-01-01"; 

            var movieList = await _friDetailsService.sysFriDetails(friRequest);
            return Ok(movieList);
        }
    }
}

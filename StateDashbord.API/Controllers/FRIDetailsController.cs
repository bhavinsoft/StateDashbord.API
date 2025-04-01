using Microsoft.AspNetCore.Mvc;
using StateDashbord.Application.IService;
using StateDashbord.Application.Service;
using StateDashbord.Domain.Entities;

namespace StateDashbord.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            var movieList = await _friDetailsService.sysFriDetails(friRequest);
            return Ok(movieList);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using StateDashbord.Application.IService;
using StateDashbord.Application.Model;
using StateDashbord.Application.Service;
using StateDashbord.Domain.Entities;

namespace StateDashbord.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        IUserService _userService;

        public AuthController( IUserService userService)
        {
          
            _userService = userService;
        }

        [HttpGet("Login")]
        public async Task<ActionResult<usermasterDto>> Login(string usernaem,string password)
        {
      
            var userdata = await _userService.GetUserdatabyusernanepassword(usernaem, password);
            if (userdata?.data == null)
            {
                return NotFound(userdata);
            }
            return Ok(userdata);
        }
    }
}

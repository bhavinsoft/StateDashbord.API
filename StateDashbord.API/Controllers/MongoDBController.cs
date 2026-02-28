using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateDashbord.Application.IService;
using StateDashbord.Application.Model;
using StateDashbord.Application.Service;
using StateDashbord.Domain.Entities;
using System.Text.Json;

namespace StateDashbord.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MongoDBController : ControllerBase
    {
        private readonly IMongoUserService _mongoUserService;
        public MongoDBController(IMongoUserService  mongoUserService) { 

            _mongoUserService = mongoUserService;
        }

        [AllowAnonymous]
        [HttpPost("PostMongoJsonData")]
        public async Task<ActionResult<Result<int>>> PostMongoJsonData([FromBody] object request)
        {
            var jsonString = JsonSerializer.Serialize(request);
            var result = await _mongoUserService.InsertJsonmongoAsync(jsonString);
            return Ok(result);
        }

    }
}

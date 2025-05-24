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
    public class ProgramMasterController : ControllerBase
    {
        private readonly IProgramMasterService _programMasterService;
        public ProgramMasterController(IProgramMasterService programMasterService)
        {
            _programMasterService = programMasterService;
        }

        [HttpPost("PostProgramMaster")]
        public async Task<ActionResult<Result<int>>> PostProgramMaster([FromBody] program_masterDto programMasterDto)
        {
            var result = await _programMasterService.PostProgramMaster(programMasterDto);
            return Ok(result);

        }
        [HttpGet("GetProgramMasterList")]
        public async Task<ActionResult<Result<List<program_masterViewDto>>>> GetProgramMasterList(int id,int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var result = await _programMasterService.getProgramMasterList(id,userid, userposition, rollid, from_date, to_date);
            return Ok(result);
        }
    }
}

using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IService
{
    public interface IProgramMasterService
    {
        Task<Result<int>> PostProgramMaster(program_masterDto programMaster);

        Task<Result<int>> PostAfterProgramMaster(after_program_masterDto afterprogrammasterDto);
        Task<Result<List<program_masterViewDto>>> getProgramMasterList(int id, int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date);
        Task<Result<program_masterViewDto>> getProgramMasterById(int id, int userid, int userposition, int rollid);
        Task<Result<after_program_masterViewDto>> getafterProgramMasterById(int id, int userid, int userposition, int rollid);

    }

}

using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IRepository
{
    public interface IProgramMasterRepo
    {
        Task<Result<int>> PostProgramMaster(Postprogram_master programMaster);
        Task<Result<int>> PostAfterProgramMaster(postafterprogrammaster postafterprogrammaster);
        Task<Result<List<program_masterView>>> getProgramMasterList(int id,int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date);
        Task<Result<program_masterView>> getProgramMasterById(int id, int userid, int userposition, int rollid);
        Task<Result<afterprogrammasterview>> getafterProgramMasterById(int id, int userid, int userposition, int rollid);

    }
}

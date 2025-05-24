using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IService
{
    public interface ICeremonyMasterService
    {
        Task<Result<int>> PostCeremonyMaster(ceremony_masterDto ceremonyMaster);

        Task<Result<List<ceremony_masterViewDto>>> getCeremonyMasterList(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date);

    }

}

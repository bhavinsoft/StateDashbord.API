using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IRepository
{
    public interface ICeremonyMasterRepo
    {
        Task<Result<int>> PostCeremonyMaster(ceremony_master ceremonyMaster);
        Task<Result<List<ceremony_masterView>>> getCeremonyMasterList(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date);

    }
}

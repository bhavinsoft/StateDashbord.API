using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IRepository
{
    public interface IFestivalMasterRepo
    {
        Task<Result<int>> PostFestivalMaster(festival_master festivalMaster);
    }
}

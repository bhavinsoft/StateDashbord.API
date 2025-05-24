using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IService
{
    public interface IApplicationMasterService
    {
        Task<Result<int>> PostApplicationMaster(application_masterDto applicationMaster);
        Task<Result<List<application_masterViewDto>>> getApplicationMasterList(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date);

    }

}

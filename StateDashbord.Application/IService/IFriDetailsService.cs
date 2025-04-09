using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IService
{
    public interface IFriDetailsService
    {
        Task<Result<string>> sysFriDetails(FriRequest friRequest);
        Task<Result<List<FridataListDto>>> getFriDataByType(int id, int userid, int userposition, int rollid);
    }
}

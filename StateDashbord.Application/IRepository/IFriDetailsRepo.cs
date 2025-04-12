using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IRepository
{
    public interface IFriDetailsRepo
    {
       Task saveFriData(FRIDetailDto fridto);

        Task<Result<List<FridataList>>> getFriDataByType(int id, int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date);
        Task<Result<fridetails>> getFriDataByid(int id, int userid, int userposition, int rollid);
        //Task<int> saveFriData(int  x);
    }
}

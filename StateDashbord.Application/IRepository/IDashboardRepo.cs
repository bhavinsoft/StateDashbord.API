using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IRepository
{
    public interface IDashboardRepo
    {
       Task<Result<List<DashbordCount>>> getDashboardcountdata(int userid,int userposition,int rollid, DateOnly? from_date, DateOnly? to_date);
       
    }
}

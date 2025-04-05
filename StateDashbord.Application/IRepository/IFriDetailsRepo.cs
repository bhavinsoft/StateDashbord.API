using StateDashbord.Application.Model;
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
        //Task<int> saveFriData(int  x);
    }
}

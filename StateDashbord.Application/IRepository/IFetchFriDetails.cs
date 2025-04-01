using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IRepository
{
    public interface IFetchFriDetails
    {
        Task<FRIDetailDto> FetchFriFromApi(FriRequest friRequest);
    }
}

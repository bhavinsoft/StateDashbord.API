using StateDashbord.Application.IRepository;
using StateDashbord.Application.IService;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.Service
{
    public class FriDetailsService : IFriDetailsService
    {
        public readonly IFetchFriDetails _fetchFriDetails;
        public readonly IFriDetailsRepo _FriDetails;

        public FriDetailsService(IFetchFriDetails fetchFriDetails, IFriDetailsRepo FriDetails)
        {
            _fetchFriDetails = fetchFriDetails;
            _FriDetails = _FriDetails;


        }
        public Task<int> sysFriDetails(FriRequest friRequest)
        {
            var firdata = _fetchFriDetails.FetchFriFromApi(friRequest);
            throw new NotImplementedException();
        }
    }
}

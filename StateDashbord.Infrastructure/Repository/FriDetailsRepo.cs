using StateDashbord.Application.IRepository;
using StateDashbord.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Infrastructure.Repository
{
    public class FriDetailsRepo : IFriDetailsRepo
    {
        private readonly IGenericServices<FRIDetailDto> _friservicedata;

        public FriDetailsRepo(IGenericServices<FRIDetailDto> friservicedata)
        {
            _friservicedata = friservicedata;
        }

        public Task<int> saveFriData(FRIDetailDto fRIDetailDto)
        {
            Dictionary<string, object> PS_Details = new Dictionary<string, object>();

            PS_Details.Add("Ps_Cd", fRIDetailDto.PS_Details_SCRB.Ps_Cd);
            PS_Details.Add("Ps_Name", fRIDetailDto.PS_Details_SCRB.Ps_Name);
            PS_Details.Add("Fir_Reg_Num", fRIDetailDto.PS_Details_SCRB.Fir_Reg_Num);
            PS_Details.Add("State_Name", fRIDetailDto.PS_Details_SCRB.State_Name);
            PS_Details.Add("City_District_Name", fRIDetailDto.PS_Details_SCRB.City_District_Name);
            PS_Details.Add("City_District_Cd", fRIDetailDto.PS_Details_SCRB.City_District_Cd);
            PS_Details.Add("Address", fRIDetailDto.PS_Details_SCRB.Address);
            PS_Details.Add("Latitude", fRIDetailDto.PS_Details_SCRB.Latitude);
            PS_Details.Add("Longitude", fRIDetailDto.PS_Details_SCRB.Longitude);
            PS_Details.Add("Crimehead_Desc_Guj", fRIDetailDto.PS_Details_SCRB.Crimehead_Desc_Guj);
            PS_Details.Add("Fir_Gist_Regional", fRIDetailDto.PS_Details_SCRB.Fir_Gist_Regional);


            foreach (var act in fRIDetailDto.Acts)
            {
                Dictionary<string, object> act_Details = new Dictionary<string, object>();

                act_Details.Add("Act_Id", act.Act_Id);
                act_Details.Add("Section_Code", act.Section_Code);
                act_Details.Add("Act_Desc", act.Act_Desc);
                act_Details.Add("Section_Desc", act.Act_Desc);
            }


            throw new NotImplementedException();
        }

    }
}

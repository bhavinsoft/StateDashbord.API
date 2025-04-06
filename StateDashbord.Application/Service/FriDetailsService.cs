using StateDashbord.Application.IRepository;
using StateDashbord.Application.IService;
using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            _FriDetails = FriDetails;


        }
        public async Task<Result<string>> sysFriDetails(FriRequest friRequest)
        {
            try
            {
               // List<FRIDetailDto> fRIDetailDtolist = new List<FRIDetailDto>();
                //var KK = "[{\"PS_Details_SCRB\":{\"ps_cd\":\"5678\",\"ps_name\":\"Pardi\",\"fir_reg_num\":\"11200038200001\",\"reg_dt\":\"2020-01-01\",\"state_name\":\"Gujarat\",\"city_district_name\":\"Valsad\",\"city_district_cd\":\"19\",\"address\":\"Pardi P.Stn., On N.H.No.8,  Pardi Ta.Pardi , \",\"latitude\":\"72.950000\",\"longitude\":\"20.520000\",\"crimehead_desc_guj\":\"નશાબંધી અધિનિયમ\",\"fir_gist_regional\":\"પ્રોહી.એકટ કલમ 66(1)(B),85(1)  મુજબ ઉપર બતાવેલ તા.ટા તથા જગ્યાએ આ કામના પકડાયેલ તહો અનીલ દબધન પ્રધાન ઉ.વ.૨૧ રહે.ધનુભર સોસાયટી રૂમ નં.૩૦૨ સ્ટેશન રોડ સુરત મુળ રહેવાસી ગામ ભરમપુર તા.ગંજામ પોસ્ટ કોકળા જી.બેરૂમાબાડી ઉરીસ્સા નાનો વગર પાસ પરમીટે દારૂનો નશો કરી, નશાની હાલતમાં બેસી આવી પકડાઇ જઇ  ગુન્હો કર્યા વિગેરે બાબત\"},\"acts\":[{\"act_id\":\"4498\",\"section_code\":\"66(1)(b),85(1)\",\"act_desc\":\"નંશાબંધી અધિનિયમ, 1949\",\"section_desc\":\"Penalty for illegal cultivation and collection of hemp and other matters\"}],\"Complainant_Details_SCRB\":{\"comp_pres_address\":\"\",\"comp_pres_address_regional\":\"\",\"comp_name\":\"પો.કો. નીતીન બાબુલાલ બ.ન.૭૯૧ \",\"comp_name_regional\":\"પો.કો. નીતીન બાબુલાલ બ.ન.૭૯૧ \",\"mobileno\":\"\"},\"Occurrence_of_Offence\":{\"to_dt\":\"2020-01-01\",\"from_time\":\"18:40:00\",\"from_dt\":\"2019-12-31\",\"to_time\":\"00:05:00\"},\"Investigating_Officer\":{\"io_rank\":\"H.C.\",\"io_name\":\"Jagajivanbhai Dineshbhai Patel \",\"io_name_regional\":\"જગજીવનભાઇ દિનેશકુમાર  પટેલ \"},\"accused_list\":[{\"accused_name\":\"અનીલ  દબધન  પ્રધાન  \",\"accused_name_regional\":\"અનીલ  દબધન  પ્રધાન  \",\"accused_age\":\"21\",\"accused_pres_addr\":\"Surat City,Gujarat,\",\"accused_pres_addr_regional\":\"ધનુભર સોસાયટી રૂમ નં.૩૦૨ સ્ટેશન રોડ સુરત મુળ રહેવાસી ગામ ભરમપુર તા.ગંજામ પોસ્ટ કોકળા જી.બેરૂમાબાડી ઉરીસ્સા   ,ધનુભર સોસાયટી રૂમ નં.૩૦૨ સ્ટેશન રોડ સુરત મુળ રહેવાસી ગામ ભરમપુર તા.ગંજામ પોસ્ટ કોકળા જી.બેરૂમાબાડી ઉરીસ્સા   ,સુરત શહેર,ગુજરાત,\",\"accused_national_gender_cd\":\"M\",\"accused_occupation\":\"\"}],\"Visiting_Details_SCRB\":{\"visiting_offcr_name\":\"\",\"visiting_offcr_dsgn\":\"\",\"visiting_date\":\"\",\"visiting_time\":\"\"}}]";

                //var options = new JsonSerializerOptions
                //{
                //    PropertyNameCaseInsensitive = true
                //};

              //  fRIDetailDtolist = JsonSerializer.Deserialize<List<FRIDetailDto>>(KK,options);

             //   await _FriDetails.saveFriData(fRIDetailDtolist[0]);

                var firdata = await _fetchFriDetails.FetchFriFromApi(friRequest);

                if (firdata.sucess)
                {
                    foreach (var item in firdata.data)
                    { 
                        await _FriDetails.saveFriData(item);
                    }
                    return Result<string>.SuccessResult("sucess data", "fechdata succesfull", 1);
                }
                else
                {
                    return Result<string>.SuccessResult("sucess data 0", "fechdata succesfull", 1); 
                }
                
            }
            catch (Exception EX)
            {

                return Result<string>.FailureResult(EX.ToString(), 0);
            }
         //   var KK = "[{\"PS_Details_SCRB\":{\"ps_cd\":\"5678\",\"ps_name\":\"Pardi\",\"fir_reg_num\":\"11200038200001\",\"reg_dt\":\"2020-01-01\",\"state_name\":\"Gujarat\",\"city_district_name\":\"Valsad\",\"city_district_cd\":\"19\",\"address\":\"Pardi P.Stn., On N.H.No.8,  Pardi Ta.Pardi , \",\"latitude\":\"72.950000\",\"longitude\":\"20.520000\",\"crimehead_desc_guj\":\"નશાબંધી અધિનિયમ\",\"fir_gist_regional\":\"પ્રોહી.એકટ કલમ 66(1)(B),85(1)  મુજબ ઉપર બતાવેલ તા.ટા તથા જગ્યાએ આ કામના પકડાયેલ તહો અનીલ દબધન પ્રધાન ઉ.વ.૨૧ રહે.ધનુભર સોસાયટી રૂમ નં.૩૦૨ સ્ટેશન રોડ સુરત મુળ રહેવાસી ગામ ભરમપુર તા.ગંજામ પોસ્ટ કોકળા જી.બેરૂમાબાડી ઉરીસ્સા નાનો વગર પાસ પરમીટે દારૂનો નશો કરી, નશાની હાલતમાં બેસી આવી પકડાઇ જઇ  ગુન્હો કર્યા વિગેરે બાબત\"},\"acts\":[{\"act_id\":\"4498\",\"section_code\":\"66(1)(b),85(1)\",\"act_desc\":\"નંશાબંધી અધિનિયમ, 1949\",\"section_desc\":\"Penalty for illegal cultivation and collection of hemp and other matters\"}],\"Complainant_Details_SCRB\":{\"comp_pres_address\":\"\",\"comp_pres_address_regional\":\"\",\"comp_name\":\"પો.કો. નીતીન બાબુલાલ બ.ન.૭૯૧ \",\"comp_name_regional\":\"પો.કો. નીતીન બાબુલાલ બ.ન.૭૯૧ \",\"mobileno\":\"\"},\"Occurrence_of_Offence\":{\"to_dt\":\"2020-01-01\",\"from_time\":\"18:40:00\",\"from_dt\":\"2019-12-31\",\"to_time\":\"00:05:00\"},\"Investigating_Officer\":{\"io_rank\":\"H.C.\",\"io_name\":\"Jagajivanbhai Dineshbhai Patel \",\"io_name_regional\":\"જગજીવનભાઇ દિનેશકુમાર  પટેલ \"},\"accused_list\":[{\"accused_name\":\"અનીલ  દબધન  પ્રધાન  \",\"accused_name_regional\":\"અનીલ  દબધન  પ્રધાન  \",\"accused_age\":\"21\",\"accused_pres_addr\":\"Surat City,Gujarat,\",\"accused_pres_addr_regional\":\"ધનુભર સોસાયટી રૂમ નં.૩૦૨ સ્ટેશન રોડ સુરત મુળ રહેવાસી ગામ ભરમપુર તા.ગંજામ પોસ્ટ કોકળા જી.બેરૂમાબાડી ઉરીસ્સા   ,ધનુભર સોસાયટી રૂમ નં.૩૦૨ સ્ટેશન રોડ સુરત મુળ રહેવાસી ગામ ભરમપુર તા.ગંજામ પોસ્ટ કોકળા જી.બેરૂમાબાડી ઉરીસ્સા   ,સુરત શહેર,ગુજરાત,\",\"accused_national_gender_cd\":\"M\",\"accused_occupation\":\"\"}],\"Visiting_Details_SCRB\":{\"visiting_offcr_name\":\"\",\"visiting_offcr_dsgn\":\"\",\"visiting_date\":\"\",\"visiting_time\":\"\"}}]";
          //  var movieList = JsonSerializer.Deserialize<FRIDetailDto>(KK);

          
        }
    }
}

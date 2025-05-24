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

        public async Task<Result<FRIDetailDto>> getFriDataByid(int id, int userid, int userposition, int rollid)
        {
          
                var fridata = await _FriDetails.getFriDataByid(id, userid, userposition, rollid);
                var fRIDetailDto = new FRIDetailDto
                {
                    PS_Details_SCRB = new FRIDetailmasterDto
                    {
                        recid  = fridata.data.fridetailsmaster?.recid,
                        ps_cd = fridata.data.fridetailsmaster?.ps_cd,
                        ps_name =  fridata.data.fridetailsmaster?.ps_name,
                        fir_reg_num =fridata.data.fridetailsmaster?.fir_reg_num,
                        reg_dt =fridata.data.fridetailsmaster?.reg_dt,
                        state_name =fridata.data.fridetailsmaster?.state_name,
                        city_district_name  =fridata.data.fridetailsmaster?.city_district_name,
                        city_district_cd =fridata.data.fridetailsmaster?.city_district_cd,
                        address =fridata.data.fridetailsmaster?.address,
                        latitude =fridata.data.fridetailsmaster?.latitude,
                        longitude =fridata.data.fridetailsmaster?.longitude,
                        crimehead_desc_guj =fridata.data.fridetailsmaster?.crimehead_desc_guj,
                        crimehead_id =fridata.data.fridetailsmaster?.crimehead_id,
                        fir_gist_regional =fridata.data.fridetailsmaster?.fir_gist_regional
                    },
                    Occurrence_of_Offence = new OccurrenceDetailsDto
                    { 
                        to_dt= fridata.data.occurrence_Of_Offence?.to_dt,
                        from_time = fridata.data.occurrence_Of_Offence?.from_time,
                        from_dt = fridata.data.occurrence_Of_Offence?.from_dt,
                        to_time = fridata.data.occurrence_Of_Offence?.to_time,
                    },
                    acts = fridata.data.acts?.Select(x => new ActDetailsDto
                    {
                        act_id = x.act_id,
                        section_code = x.section_code,
                        act_desc = x.act_desc,
                        section_desc = x.section_desc
                    }).ToList(),
                    Complainant_Details_SCRB = new ComplainantDetailsDto
                    {
                        comp_name = fridata.data.complainan_detail_sscrb?.comp_name,
                        comp_name_regional = fridata.data.complainan_detail_sscrb?.comp_name_regional,
                        comp_pres_address = fridata.data.complainan_detail_sscrb?.comp_pres_address,
                        comp_pres_address_regional = fridata.data.complainan_detail_sscrb?.comp_pres_address_regional,
                        mobileno = fridata.data.complainan_detail_sscrb?.mobileno,

                    },
                    Investigating_Officer = new InvestigatingOfficerDto
                    {
                        io_rank = fridata.data.investigating_Officer?.io_rank,
                        io_name = fridata.data.investigating_Officer?.io_name,
                        io_name_regional = fridata.data.investigating_Officer?.io_name_regional,


                    },
                    Visiting_Details_SCRB =new VisitingDetailsDto
                    {
                        visiting_offcr_name = fridata.data.visiting_details_scrb?.visiting_offcr_name,
                        visiting_offcr_dsgn = fridata.data.visiting_details_scrb?.visiting_offcr_dsgn,
                        visiting_date = fridata.data.visiting_details_scrb?.visiting_date,
                        visiting_time = fridata.data.visiting_details_scrb?.visiting_time

                    },
                    accused_list = fridata.data.accused_Lists?.Select( x=>  new AccusedDetailsDto
                    {
                        accused_name =x.accused_name,
                        accused_name_regional =x.accused_name_regional,
                        accused_age=x.accused_age,
                        accused_pres_addr=x.accused_pres_addr,
                        accused_pres_addr_regional =x.accused_pres_addr_regional,
                        accused_national_gender_cd = x.accused_national_gender_cd,
                        accused_occupation = x.accused_occupation

                    }).ToList(),
                    additional_information =new additional_informationDto
                    {
                        if_criminal_history = fridata.data.additional_information?.if_criminal_history,
                        if_criminal_history_text = fridata.data.additional_information?.if_criminal_history == true ? "હા" : fridata.data.additional_information?.if_criminal_history == false ? "ના" : "-",
                        if_media_sensational = fridata.data.additional_information?.if_media_sensational,
                        if_media_sensational_text = fridata.data.additional_information?.if_media_sensational == true ? "હા" : fridata.data.additional_information?.if_media_sensational == false ? "ના" : "-",
                        if_complaint_against_PG = fridata.data.additional_information?.if_complaint_against_PG,
                        if_complaint_against_PG_text = fridata.data.additional_information?.if_complaint_against_PG == true ? "હા" : fridata.data.additional_information?.if_complaint_against_PG == false ? "ના" : "-",
                        if_affect_law = fridata.data.additional_information?.if_affect_law,
                        if_affect_law_text = fridata.data.additional_information?.if_affect_law == true ? "હા" : fridata.data.additional_information?.if_affect_law == false ? "ના" : "-",
                        if_arresting_accused_affect_law = fridata.data.additional_information?.if_arresting_accused_affect_law,
                        if_arresting_accused_affect_law_text = fridata.data.additional_information?.if_arresting_accused_affect_law == true ? "હા" : fridata.data.additional_information?.if_arresting_accused_affect_law == false ? "ના" : "-",
                        if_accused_arrested = fridata.data.additional_information?.if_accused_arrested,
                        if_accused_arrested_text = fridata.data.additional_information?.if_accused_arrested == true ? "હા" : fridata.data.additional_information?.if_accused_arrested == false ? "ના" : "-",
                        accused_arrested_reason = fridata.data.additional_information?.accused_arrested_reason,
                        if_media_link= fridata.data.additional_information?.if_media_link,
                        if_media_link_text = fridata.data.additional_information?.if_media_link == true ? "હા" : fridata.data.additional_information?.if_media_link == false ? "ના" : "-",
                        media_link = fridata.data.additional_information?.media_link,
                        if_social_media_link = fridata.data.additional_information?.if_social_media_link,
                        if_social_media_link_text = fridata.data.additional_information?.if_social_media_link == true ? "હા" : fridata.data.additional_information?.if_social_media_link == false ? "ના" : "-",
                        social_media_link = fridata.data.additional_information?.social_media_link,
                        
                        if_e_evidence_used = fridata.data.additional_information?.if_e_evidence_used,
                        if_e_evidence_used_text = fridata.data.additional_information?.if_e_evidence_used == true ? "હા" : fridata.data.additional_information?.if_e_evidence_used == false ? "ના" : "-",

                    },
                    additional_accused_list = fridata.data.additional_accused_list?.Select(x => new additional_accused_listDto
                    {
                        additional_accused_name =x.additional_accused_name,
                        additional_accused_address =x.additional_accused_address,
                        additional_accused_mobileNo =x.additional_accused_mobileNo

                    }).ToList(),
                    additional_officer_visit = fridata.data.additional_officer_visit?.Select(x => new additional_officer_visitDto
                    {
                       additional_officer_name =x.additional_officer_name,
                        additional_officer_designation =x.additional_officer_designation,
                        additional_officer_mobileno =x.additional_officer_mobileno,
                        visit_date =x.visit_date,
                        visit_time =x.visit_time

                    }).ToList()


                };


            return Result<FRIDetailDto>.SuccessResult(fRIDetailDto, "fechdata succesfull", 1);

        }

        public async Task<Result<List<FridataListDto>>> getFriDataByType(int id, int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var result = await _FriDetails.getFriDataByType(id, userid, userposition, rollid,from_date,to_date);

            var frilistDtoList = result.data.Select(x => new FridataListDto
             {
                recid = x.recid,
                ps_cd = x.ps_cd,
                ps_name = x.ps_name,
                fir_reg_num = x.fir_reg_num,
                reg_dt = x.reg_dt,
                city_district_name =x.city_district_name,
                crimehead_desc_guj =x.crimehead_desc_guj,
                address=x.address,
                fir_gist_regional = x.fir_gist_regional,
                latitude = x.latitude,
                longitude = x.longitude
            }).ToList();

            return Result<List<FridataListDto>>.SuccessResult(frilistDtoList, "fechdata succesfull", 1);
        }

        public async Task<Result<List<FridataListDto>>> getFriDataByTypeformap(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var result = await _FriDetails.getFriDataByTypeformap( userid, userposition, rollid, from_date, to_date);

            var frilistDtoList = result.data.Select(x => new FridataListDto
            {
                recid = x.recid,
                ps_cd = x.ps_cd,
                ps_name = x.ps_name,
                fir_reg_num = x.fir_reg_num,
                reg_dt = x.reg_dt,
                city_district_name = x.city_district_name,
                crimehead_desc_guj = x.crimehead_desc_guj,
                latitude = x.latitude,
                longitude = x.longitude
            }).ToList();

            return Result<List<FridataListDto>>.SuccessResult(frilistDtoList, "fechdata succesfull", 1);
        }

        public async Task<Result<int>> Postadditionalinformation(additionalinformationDto additionalinformationDto)
        {
            Postadditional_information postadditionalinformation = new Postadditional_information();
            postadditionalinformation.additional_Information = new additional_information
            {
                recid = additionalinformationDto.recid,
                if_criminal_history = additionalinformationDto.if_criminal_history,
                if_media_sensational = additionalinformationDto.if_media_sensational,
                if_complaint_against_PG = additionalinformationDto.if_complaint_against_PG,
                if_affect_law = additionalinformationDto.if_affect_law,
                if_arresting_accused_affect_law = additionalinformationDto.if_arresting_accused_affect_law,
                if_accused_arrested = additionalinformationDto.if_accused_arrested,
                accused_arrested_reason = additionalinformationDto.accused_arrested_reason,
                if_media_link = additionalinformationDto.if_media_link,
                media_link = additionalinformationDto.media_link,
                if_social_media_link = additionalinformationDto.if_social_media_link,
                social_media_link = additionalinformationDto.social_media_link,
                if_e_evidence_used = additionalinformationDto.if_e_evidence_used,
                friid = additionalinformationDto.friid,

            };
            if (additionalinformationDto.additional_accused_list != null)
            {
                postadditionalinformation.additional_Accused_Lists = additionalinformationDto.additional_accused_list?.Select(x => new additional_accused_list
                {
                    recid = x.recid,
                    additional_accused_name = x.additional_accused_name,
                    additional_accused_address = x.additional_accused_address,
                    additional_accused_mobileNo = x.additional_accused_mobileNo,
                    reason = x.reason,
                    remarks = x.remarks,
                    friid = x.friid
                }).ToList();
            }
            if (additionalinformationDto.additional_officer_visit != null)
            {
                postadditionalinformation.additional_Officer_Visits = additionalinformationDto.additional_officer_visit?.Select(x => new additional_officer_visit
                {
                    recid = x.recid,
                    additional_officer_name = x.additional_officer_name,
                    additional_officer_designation = x.additional_officer_designation,
                    additional_officer_mobileno = x.additional_officer_mobileno,
                    visit_date = x.visit_date,
                    visit_time = x.visit_time,
                    friid = x.friid
                }).ToList();
            }
            var mydata = await _FriDetails.Postadditionalinformation(postadditionalinformation);

            if(mydata.sucess)
            {
                return Result<int>.SuccessResult(mydata.data, "Data Inserted Successfully", 1);
            }
            else
            {
                return Result<int>.FailureResult(mydata.message, 0);
            }
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

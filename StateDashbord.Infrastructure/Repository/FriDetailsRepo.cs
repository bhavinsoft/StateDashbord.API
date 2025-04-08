using StateDashbord.Application.IRepository;
using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Infrastructure.Repository
{
    public class FriDetailsRepo : IFriDetailsRepo
    {
        private readonly IGenericServices<FRIDetailDto> _friservicedata;
        private readonly IGenericServices<FridataList> _fridatalist;

        public FriDetailsRepo(IGenericServices<FRIDetailDto> friservicedata, IGenericServices<FridataList> fridatalist)
        {
            _friservicedata = friservicedata;
            _fridatalist = fridatalist;
        }

        public async Task<Result<List<FridataList>>> getFriDataByType(int id, int userid, int userposition, int rollid)
        {
            try
            {
                Dictionary<string, object> fridatdis = new Dictionary<string, object>();
                fridatdis.Add("id", id);
                fridatdis.Add("userid", userid);
                fridatdis.Add("userposition", userposition);
                fridatdis.Add("rollid", rollid);
                var fridat =await _fridatalist.GetAsync("getFridatabylype", fridatdis);
                return Result<List<FridataList>>.SuccessResult(fridat, "fechdata succesfull", 1);
            }
            catch (Exception ex)
            {

               return Result<List<FridataList>>.FailureResult($"An error occurred: {ex.Message}", 0);
            }
           
        }

        public async Task saveFriData(FRIDetailDto fRIDetailDto)
        {
            Dictionary<string, object> PS_Details = new Dictionary<string, object>();

            PS_Details.Add("ps_cd", fRIDetailDto.PS_Details_SCRB.ps_cd);
            PS_Details.Add("ps_name", fRIDetailDto.PS_Details_SCRB.ps_name);
            PS_Details.Add("fir_reg_num", fRIDetailDto.PS_Details_SCRB.fir_reg_num);
            PS_Details.Add("reg_dt", fRIDetailDto.PS_Details_SCRB.reg_dt);
            PS_Details.Add("state_name", fRIDetailDto.PS_Details_SCRB.state_name);
            PS_Details.Add("city_district_name", fRIDetailDto.PS_Details_SCRB.city_district_name);
            PS_Details.Add("city_district_cd", fRIDetailDto.PS_Details_SCRB.city_district_cd);
            PS_Details.Add("address", fRIDetailDto.PS_Details_SCRB.address);
            PS_Details.Add("latitude", fRIDetailDto.PS_Details_SCRB.latitude);
            PS_Details.Add("longitude", fRIDetailDto.PS_Details_SCRB.longitude);
            PS_Details.Add("crimehead_desc_guj", fRIDetailDto.PS_Details_SCRB.crimehead_desc_guj);
            PS_Details.Add("fir_gist_regional", fRIDetailDto.PS_Details_SCRB.fir_gist_regional);


            var friid = await _friservicedata.Add(PS_Details, "InsertFridetails");


            if (friid != 0)
            {
                foreach (var act in fRIDetailDto.acts)
                {
                    Dictionary<string, object> act_Details = new Dictionary<string, object>();

                    act_Details.Add("act_id", act.act_id);
                    act_Details.Add("section_code", act.section_code);
                    act_Details.Add("act_desc", act.act_desc);
                    act_Details.Add("section_desc", act.section_desc);
                    act_Details.Add("friid", friid);
                    await _friservicedata.Add(act_Details, "InsertActDetails");
                }

                Dictionary<string, object> Complainant_Details = new Dictionary<string, object>();

                Complainant_Details.Add("comp_pres_address", fRIDetailDto.Complainant_Details_SCRB.comp_pres_address);
                Complainant_Details.Add("comp_pres_address_regional", fRIDetailDto.Complainant_Details_SCRB.comp_pres_address_regional);
                Complainant_Details.Add("comp_name", fRIDetailDto.Complainant_Details_SCRB.comp_name);
                Complainant_Details.Add("comp_name_regional", fRIDetailDto.Complainant_Details_SCRB.comp_name_regional);
                Complainant_Details.Add("mobileno", fRIDetailDto.Complainant_Details_SCRB.mobileno);
                Complainant_Details.Add("friid", friid);



                await _friservicedata.Add(Complainant_Details, "InsertComplainantDetails");

                Dictionary<string, object> Occurrence_of_Offence = new Dictionary<string, object>();
                Occurrence_of_Offence.Add("to_dt", fRIDetailDto.Occurrence_of_Offence.to_dt);
                Occurrence_of_Offence.Add("from_time", fRIDetailDto.Occurrence_of_Offence.from_time);
                Occurrence_of_Offence.Add("from_dt", fRIDetailDto.Occurrence_of_Offence.from_dt);
                Occurrence_of_Offence.Add("to_time", fRIDetailDto.Occurrence_of_Offence.to_time);
                Occurrence_of_Offence.Add("friid", friid);
                await _friservicedata.Add(Occurrence_of_Offence, "InsertOccurrenceOfOffence");

                Dictionary<string, object> Investigating_Officer = new Dictionary<string, object>();
                Investigating_Officer.Add("io_rank", fRIDetailDto.Investigating_Officer.io_rank);
                Investigating_Officer.Add("io_name", fRIDetailDto.Investigating_Officer.io_name);
                Investigating_Officer.Add("io_name_regional", fRIDetailDto.Investigating_Officer.io_name_regional);
                Investigating_Officer.Add("friid", friid);
                await _friservicedata.Add(Investigating_Officer, "InsertInvestigatingOfficer");

                foreach (var accused in fRIDetailDto.accused_list)
                {
                    Dictionary<string, object> accused_list = new Dictionary<string, object>();
                    accused_list.Add("accused_name", accused.accused_name);
                    accused_list.Add("accused_name_regional", accused.accused_name_regional);
                    accused_list.Add("accused_age", accused.accused_age);
                    accused_list.Add("accused_pres_addr", accused.accused_pres_addr);
                    accused_list.Add("accused_pres_addr_regional", accused.accused_pres_addr_regional);
                    accused_list.Add("accused_national_gender_cd", accused.accused_national_gender_cd);
                    accused_list.Add("accused_occupation", accused.accused_occupation);
                    accused_list.Add("friid", friid);
                    await _friservicedata.Add(accused_list, "InsertAccused");


                }

                Dictionary<string, object> Visiting_Details = new Dictionary<string, object>();
                Visiting_Details.Add("visiting_offcr_name", fRIDetailDto.Visiting_Details_SCRB.visiting_offcr_name);
                Visiting_Details.Add("visiting_offcr_dsgn", fRIDetailDto.Visiting_Details_SCRB.visiting_offcr_dsgn);
                Visiting_Details.Add("visiting_date", fRIDetailDto.Visiting_Details_SCRB.visiting_date);
                Visiting_Details.Add("visiting_time", fRIDetailDto.Visiting_Details_SCRB.visiting_time);
                Visiting_Details.Add("friid", friid);

                await _friservicedata.Add(Visiting_Details, "InsertVisitingDetails");
            }
        }
    }
}

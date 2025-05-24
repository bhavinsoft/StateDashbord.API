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
        private readonly IGenericServices<fridetailsmaster> _fridetailsmaster;
        private readonly IGenericServices<actdetails> _actdetails;
        private readonly IGenericServices<accused_list> _accused_list;
        private readonly IGenericServices<complainant_details_scrb> _complainantdetailsscrb;
        private readonly IGenericServices<occurrence_of_offence> _occurrenceofoffence;
        private readonly IGenericServices<investigating_officer> _investigatingofficer;
        private readonly IGenericServices<visiting_details_scrb> _visitingdetailsscrb;
        private readonly IGenericServices<additional_information> _additionalinformation;
        private readonly IGenericServices<additional_accused_list> _additionalaccusedlist;
        private readonly IGenericServices<additional_officer_visit> _additionalofficervisit;

        public FriDetailsRepo(IGenericServices<FRIDetailDto> friservicedata, 
            IGenericServices<FridataList> fridatalist, 
            IGenericServices<fridetailsmaster> fridetailsmaster,
            IGenericServices<actdetails> actdetails
           ,IGenericServices<accused_list> accused_list
           ,IGenericServices<complainant_details_scrb> complainantdetailsscrb
           ,IGenericServices<occurrence_of_offence> occurrenceofoffence
           ,IGenericServices<investigating_officer > investigatingofficer
            , IGenericServices<visiting_details_scrb> visitingdetailsscrb
            , IGenericServices<additional_information> additionalinformation
           , IGenericServices<additional_accused_list> additionalaccusedlist
            , IGenericServices<additional_officer_visit> additionalofficervisit
            )
        {
            _friservicedata = friservicedata;
            _fridatalist = fridatalist;
            _fridetailsmaster = fridetailsmaster;    
            _actdetails = actdetails;
            _accused_list= accused_list;
            _complainantdetailsscrb =complainantdetailsscrb;
            _occurrenceofoffence = occurrenceofoffence;
            _investigatingofficer = investigatingofficer;
            _visitingdetailsscrb = visitingdetailsscrb;
            _additionalinformation = additionalinformation;
            _additionalaccusedlist = additionalaccusedlist;
            _additionalofficervisit = additionalofficervisit;
        }

        public async Task<Result<fridetails>> getFriDataByid(int id, int userid, int userposition, int rollid)
        {
            fridetails objfridetails = new fridetails();

            try
            {

                Dictionary<string, object> fridata = new Dictionary<string, object>();
                fridata.Add("id", id);

                objfridetails.fridetailsmaster = await  _fridetailsmaster.GetFirstOrDefaultAsync("getfridatabyid", fridata);

                if (objfridetails.fridetailsmaster!= null)
                {

                    objfridetails.acts = await  _actdetails.GetAsync("getactdetailsbyfriid", fridata);
                    objfridetails.accused_Lists = await  _accused_list.GetAsync("getaccused_listbyfriid", fridata);
                    objfridetails.complainan_detail_sscrb = await _complainantdetailsscrb.GetFirstOrDefaultAsync("getcomplainant_details_scrbbyfriid", fridata);
                    objfridetails.occurrence_Of_Offence = await _occurrenceofoffence.GetFirstOrDefaultAsync("getoccurrence_of_offencebyfriid", fridata);
                    objfridetails.investigating_Officer = await _investigatingofficer.GetFirstOrDefaultAsync("getInvestigating_Officerbyfriid", fridata);
                    objfridetails.visiting_details_scrb = await _visitingdetailsscrb.GetFirstOrDefaultAsync("getvisiting_details_scrbbyfriid", fridata);
                    objfridetails.additional_information = await _additionalinformation.GetFirstOrDefaultAsync("getadditional_informationbyfriid", fridata);
                    objfridetails.additional_accused_list = await _additionalaccusedlist.GetAsync("getadditional_accused_listbyfriid", fridata);
                    objfridetails.additional_officer_visit = await _additionalofficervisit.GetAsync("getadditional_officer_visitbyfriid", fridata);


                    return Result<fridetails>.SuccessResult(objfridetails, "fechdata succesfull", 1);

                }
                else
                {

                    return Result<fridetails>.FailureResult($"data not found", 0);

                }

              
            }
            catch (Exception ex)
            {
                return Result<fridetails>.FailureResult($"An error occurred: {ex.Message}", 0);

            }

        }

        public async Task<Result<List<FridataList>>> getFriDataByType(int id, int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            try
            {
                Dictionary<string, object> fridatdis = new Dictionary<string, object>();
                fridatdis.Add("id", id);
                fridatdis.Add("userid", userid);
                fridatdis.Add("userposition", userposition);
                fridatdis.Add("rollid", rollid);
                fridatdis.Add("from_date", from_date?.ToString("yyyy-MM-dd"));
                fridatdis.Add("to_date", to_date?.ToString("yyyy-MM-dd"));
                var fridat =await _fridatalist.GetAsync("getFridatabytype", fridatdis);
                return Result<List<FridataList>>.SuccessResult(fridat, "fechdata succesfull", 1);
            }
            catch (Exception ex)
            {

               return Result<List<FridataList>>.FailureResult($"An error occurred: {ex.Message}", 0);
            }
           
        }

        public async Task<Result<List<FridataList>>> getFriDataByTypeformap(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            try
            {
                Dictionary<string, object> fridatdis = new Dictionary<string, object>();
               ;
                fridatdis.Add("userid", userid);
                fridatdis.Add("userposition", userposition);
                fridatdis.Add("rollid", rollid);
                fridatdis.Add("from_date", from_date?.ToString("yyyy-MM-dd"));
                fridatdis.Add("to_date", to_date?.ToString("yyyy-MM-dd"));
                var fridat = await _fridatalist.GetAsync("getFridatabytypeformap", fridatdis);
                return Result<List<FridataList>>.SuccessResult(fridat, "fechdata succesfull", 1);
            }
            catch (Exception ex)
            {

                return Result<List<FridataList>>.FailureResult($"An error occurred: {ex.Message}", 0);
            }
        }

        public async Task<Result<int>> Postadditionalinformation(Postadditional_information additionalinformationDto)
        {

            Dictionary<string, object> additional_information = new Dictionary<string, object>();
            additional_information.Add("if_criminal_history", additionalinformationDto.additional_Information.if_criminal_history);
            additional_information.Add("if_media_sensational", additionalinformationDto.additional_Information.if_media_sensational);
            additional_information.Add("if_complaint_against_PG", additionalinformationDto.additional_Information.if_complaint_against_PG);
            additional_information.Add("if_affect_law", additionalinformationDto.additional_Information.if_affect_law);
            additional_information.Add("if_arresting_accused_affect_law", additionalinformationDto.additional_Information.if_arresting_accused_affect_law);
            additional_information.Add("if_accused_arrested", additionalinformationDto.additional_Information.if_accused_arrested);
            additional_information.Add("accused_arrested_reason", additionalinformationDto.additional_Information.accused_arrested_reason);
            additional_information.Add("if_media_link", additionalinformationDto.additional_Information.if_media_link);
            additional_information.Add("media_link", additionalinformationDto.additional_Information.media_link);
            additional_information.Add("if_social_media_link", additionalinformationDto.additional_Information.if_social_media_link);
            additional_information.Add("social_media_link", additionalinformationDto.additional_Information.social_media_link);
            additional_information.Add("if_e_evidence_used", additionalinformationDto.additional_Information.if_e_evidence_used);
            additional_information.Add("friid", additionalinformationDto.additional_Information.friid);
            additional_information.Add("Id", additionalinformationDto.additional_Information.recid);

            var friid = await _additionalinformation.Add(additional_information, "Insertadditional_information");
            if (friid > 0)
            {
                if (additionalinformationDto.additional_Accused_Lists != null)
                {
                    foreach (var additional_Accused in additionalinformationDto.additional_Accused_Lists)
                    {
                        Dictionary<string, object> additional_accused_list = new Dictionary<string, object>();
                        additional_accused_list.Add("additional_accused_name", additional_Accused.additional_accused_name);
                        additional_accused_list.Add("additional_accused_address", additional_Accused.additional_accused_address);
                        additional_accused_list.Add("additional_accused_mobileNo", additional_Accused.additional_accused_mobileNo);
                        additional_accused_list.Add("reason", additional_Accused.reason);
                        additional_accused_list.Add("remarks", additional_Accused.remarks);
                        additional_accused_list.Add("friid", additional_Accused.friid);
                        await _additionalaccusedlist.Add(additional_accused_list, "Insertadditionalaccused");
                    }
                }
                if (additionalinformationDto.additional_Officer_Visits != null)
                {
                    foreach (var additional_Accused in additionalinformationDto.additional_Officer_Visits)
                    {
                        Dictionary<string, object> additional_Officer_Visits = new Dictionary<string, object>();
                        additional_Officer_Visits.Add("additional_officer_name", additional_Accused.additional_officer_name);
                        additional_Officer_Visits.Add("additional_officer_designation", additional_Accused.additional_officer_designation);
                        additional_Officer_Visits.Add("additional_officer_mobileno", additional_Accused.additional_officer_mobileno);
                        additional_Officer_Visits.Add("visit_date", additional_Accused.visit_date);
                        additional_Officer_Visits.Add("visit_time", additional_Accused.visit_time);
                        additional_Officer_Visits.Add("friid", additional_Accused.friid);
                        await _additionalofficervisit.Add(additional_Officer_Visits, "Insertadditionalofficervisit");
                    }
                }
            }
            else
            {
                return Result<int>.FailureResult($"An error occurred: Data Not Save", 0); 
            }


            return Result<int>.SuccessResult(friid, $"Data Save Successfully", 1);
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
            PS_Details.Add("crimehead_id", fRIDetailDto.PS_Details_SCRB.crimehead_id);
            PS_Details.Add("fir_gist_regional", fRIDetailDto.PS_Details_SCRB.fir_gist_regional);


            var friid = await _friservicedata.Add(PS_Details, "InsertFridetails");


            if (friid > 0)
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

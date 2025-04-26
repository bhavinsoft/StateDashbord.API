using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StateDashbord.Application.Model
{
    public class FRIDetailDto
    {
        public FRIDetailmasterDto? PS_Details_SCRB { get; set; }
        public List<ActDetailsDto>? acts { get; set; }
        public ComplainantDetailsDto? Complainant_Details_SCRB { get; set; }
        public OccurrenceDetailsDto? Occurrence_of_Offence { get; set; }
        public InvestigatingOfficerDto? Investigating_Officer { get; set; }
        public List<AccusedDetailsDto>? accused_list { get; set; }
        public VisitingDetailsDto? Visiting_Details_SCRB { get; set; }
        public additional_informationDto? additional_information { get; set; }
        public List<additional_accused_listDto>? additional_accused_list { get; set; }
        public List<additional_officer_visitDto>? additional_officer_visit { get; set; }
    }


    public class FRIDetailmasterDto
    {
        public string? recid { get; set; }
        public string? ps_cd { get; set; }
        public string? ps_name { get; set; }
        public string? fir_reg_num { get; set; }
        public string? reg_dt { get; set; }
        public string? state_name { get; set; }
        public string? city_district_name { get; set; }
        public string? city_district_cd { get; set; }
        public string? address { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }
        public string? crimehead_desc_guj { get; set; }
        public int? crimehead_id { get; set; }
        public string? fir_gist_regional { get; set; }
    }

    public class ActDetailsDto
    {
        public string? act_id { get; set; }
        public string? section_code { get; set; }
        public string? act_desc { get; set; }
        public string? section_desc { get; set; }
    }

    public class ComplainantDetailsDto
    {
        public string? comp_pres_address { get; set; }
        public string? comp_pres_address_regional { get; set; }
        public string? comp_name { get; set; }
        public string? comp_name_regional { get; set; }
        public string? mobileno { get; set; }
    }

    public class OccurrenceDetailsDto
    {
        public string? to_dt { get; set; }
        public string? from_time { get; set; }
        public string? from_dt { get; set; }
        public string? to_time { get; set; }
    }

    public class InvestigatingOfficerDto
    {
        public string? io_rank { get; set; }
        public string? io_name { get; set; }
        public string? io_name_regional { get; set; }
    }

    public class AccusedDetailsDto
    {
        public string? accused_name { get; set; }
        public string? accused_name_regional { get; set; }
        public string? accused_age { get; set; }
        public string? accused_pres_addr { get; set; }
        public string? accused_pres_addr_regional { get; set; }
        public string? accused_national_gender_cd { get; set; }
        public string? accused_occupation { get; set; }
    }

    public class VisitingDetailsDto
    {
        public string? visiting_offcr_name { get; set; }
        public string? visiting_offcr_dsgn { get; set; }
        public string? visiting_date { get; set; }
        public string? visiting_time { get; set; }
    }

    public class additional_informationDto
    {
        public int recid { get; set; }
        public bool? if_criminal_history { get; set; }
        public string?  if_criminal_history_text { get; set; }
        public bool? if_media_sensational { get; set; }
        public string? if_media_sensational_text { get; set; }
        public bool? if_complaint_against_PG { get; set; }
        public string? if_complaint_against_PG_text { get; set; }
        public bool? if_affect_law { get; set; }
        public string? if_affect_law_text { get; set; }
        public bool? if_arresting_accused_affect_law { get; set; }
        public string? if_arresting_accused_affect_law_text { get; set; }
        public bool? if_accused_arrested { get; set; }
        public string ? if_accused_arrested_text { get; set; }
        public string? accused_arrested_reason { get; set; }
        public bool? if_media_link { get; set; }
        public string? if_media_link_text { get; set; }
        public string? media_link { get; set; }
        public bool? if_social_media_link { get; set; }
        public string? if_social_media_link_text { get; set; }
        public string? social_media_link { get; set; }
        public bool? if_e_evidence_used { get; set; }
        public string? if_e_evidence_used_text { get; set; }
        public int? friid { get; set; }
        
    }

    public class additional_accused_listDto
    {
        public int recid { get; set; }
        public string? additional_accused_name { get; set; }
        public string? additional_accused_address { get; set; }
        public string? additional_accused_mobileNo { get; set; }
        public int? friid { get; set; }

    }

    public class additional_officer_visitDto
    {
        public int recid { get; set; }
        public string? additional_officer_name { get; set; }
        public string? additional_officer_designation { get; set; }
        public string? additional_officer_mobileno { get; set; }
        public DateTime? visit_date { get; set; }
        public string? visit_time { get; set; }
        public int? friid { get; set; }

    }
}
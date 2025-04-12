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
}

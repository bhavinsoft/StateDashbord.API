using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.Model
{
    public class FRIDetailDto
    {
        public PoliceStationDetails PS_Details_SCRB { get; set; }
        public List<ActDetails>? Acts { get; set; }
        public ComplainantDetails? Complainant_Details_SCRB { get; set; }
        public OccurrenceDetails? Occurrence_of_Offence { get; set; }
        public InvestigatingOfficer? Investigating_Officer { get; set; }
        public List<AccusedDetails>? Accused_List { get; set; }
        public VisitingDetails? Visiting_Details_SCRB { get; set; }
    }
    public class PoliceStationDetails
    {
        public string? Ps_Cd { get; set; }
        public string? Ps_Name { get; set; }
        public string? Fir_Reg_Num { get; set; }
        public DateTime? Reg_Dt { get; set; }
        public string? State_Name { get; set; }
        public string? City_District_Name { get; set; }
        public string? City_District_Cd { get; set; }
        public string? Address { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Crimehead_Desc_Guj { get; set; }
        public string? Fir_Gist_Regional { get; set; }
    }

    public class ActDetails
    {
        public string? Act_Id { get; set; }
        public string? Section_Code { get; set; }
        public string? Act_Desc { get; set; }
        public string? Section_Desc { get; set; }
    }

    public class ComplainantDetails
    {
        public string? Comp_Pres_Address { get; set; }
        public string? Comp_Pres_Address_Regional { get; set; }
        public string? Comp_Name { get; set; }
        public string? Comp_Name_Regional { get; set; }
        public string? MobileNo { get; set; }
    }

    public class OccurrenceDetails
    {
        public DateTime? To_Dt { get; set; }
        public TimeSpan? From_Time { get; set; }
        public DateTime? From_Dt { get; set; }
        public TimeSpan? To_Time { get; set; }
    }

    public class InvestigatingOfficer
    {
        public string? Io_Rank { get; set; }
        public string? Io_Name { get; set; }
        public string? Io_Name_Regional { get; set; }
    }

    public class AccusedDetails
    {
        public string? Accused_Name { get; set; }
        public string? Accused_Name_Regional { get; set; }
        public string? Accused_Age { get; set; }
        public string? Accused_Pres_Addr { get; set; }
        public string? Accused_Pres_Addr_Regional { get; set; }
        public string? Accused_National_Gender_Cd { get; set; }
        public string? Accused_Occupation { get; set; }
    }

    public class VisitingDetails
    {
        public string? Visiting_Offcr_Name { get; set; }
        public string? Visiting_Offcr_Dsgn { get; set; }
        public DateTime? Visiting_Date { get; set; }
        public TimeSpan? Visiting_Time { get; set; }
    }
}

using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.Model
{
    public class after_program_masterDto
    {
        public int recid { get; set; }
        public int progid { get; set; }
        public bool? ifprogramapproved { get; set; }
        public string? programapprovedinfo { get; set; }
        public int? peoplecount { get; set; }
        public bool? ifprobleminprogram { get; set; }
        public string? probleminprograminfo { get; set; }
        public bool? peoplecomeprogramprogram { get; set; }
        public string? peoplecomeprogramprograminfo { get; set; }
        public bool? ifanyprecautionstaken { get; set; }
        public string? precautionstakeninfo { get; set; }
        public bool? ifcomplaintbeenfiled { get; set; }
        public string? complaintbeenfileinfo { get; set; }
        public bool? ifthereanysuspension { get; set; }
        public bool? ifanysuspectsyettobecaught { get; set; }
        public List<dtl_program_suspensionDto>? dtlprogramsuspension { get; set; }
        public List<dtl_program_notcaught_suspensionDto>? dtlprogramnotcaughtsuspension { get; set; }

    }

    public class after_program_masterViewDto : after_program_masterDto {

        public string? ifprogramapproved_text { get; set; }
        public string? ifprobleminprogram_text { get; set; }
        public string? peoplecomeprogramprogram_text { get; set; }
        public string? ifanyprecautionstaken_text { get; set; }
        public string? ifcomplaintbeenfiled_text { get; set; }
        public string? ifthereanysuspension_text { get; set; }
        public string? ifanysuspectsyettobecaught_text { get; set; }
    }


    public class dtl_program_suspensionDto
    {
        
        public string? p_name { get; set; }
        public string? p_number { get; set; }
        public string? p_adress { get; set; }

    }

    public class dtl_program_notcaught_suspensionDto
    {
        
        public string? p_name { get; set; }
        public string? p_number { get; set; }
        public string? p_adress { get; set; }

    }


   


}
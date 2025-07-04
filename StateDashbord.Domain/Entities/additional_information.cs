﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class additional_information
    {
        public int recid { get; set; }
        public bool? if_criminal_history { get; set; }
        public bool? if_media_sensational { get; set; }
        public bool? if_complaint_against_PG { get; set; }
        public bool? if_affect_law { get; set; }
        public bool? if_arresting_accused_affect_law { get; set; }
        public bool? if_accused_arrested { get; set; }
        public string? accused_arrested_reason { get; set; }

        public bool? if_media_link { get; set; }
        public string? media_link { get; set; }
        public bool? if_social_media_link { get; set; }
        public string? social_media_link { get; set; }
        public bool? if_e_evidence_used { get; set; }
        public int? friid { get; set; }

    }

    public class additionalinformation
    {
        public additional_information additional_information { get; set; }
        public List<additional_accused_list>? additional_accused_list { get; set; }
        public List<additional_officer_visit>? additional_officer_visit { get; set; }
    }
    public class Postadditional_information
    {
        public additional_information additional_Information { get; set; }
        public List<additional_accused_list>? additional_Accused_Lists { get; set; }
        public List<additional_officer_visit>? additional_Officer_Visits { get; set; }
    }
}
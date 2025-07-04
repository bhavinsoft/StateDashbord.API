﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.Model
{
    public class program_masterDto
    {
        public int recid { get; set; }
        public int? districtid { get; set; }
        public int? policestationid { get; set; }
        public int? categoryid { get; set; }
        public string? programdetails { get; set; }

        public string? organizers_name { get; set; }
        public string? organizers_designation { get; set; }
        public string? organizers_organizationname { get; set; }
        public string? organizers_mobile { get; set; }
        public string? organizers_address { get; set; }

        public bool? if_program_approved { get; set; }
        public string? approver_name { get; set; }
        public string? approver_designation { get; set; }
        public string? approver_datetime { get; set; }

        public string? program_subject { get; set; }
        public string? program_place { get; set; }
        public string? program_routeinfo { get; set; }
        public string? programsensitiveroute_pointsinto { get; set; }
        public bool? if_affectlaw_sensitiveroute { get; set; }

        public int? program_number { get; set; }
        public bool? if_arrestperson { get; set; }
      

        public DateTime? program_date { get; set; }
        public string? remarks { get; set; }
        public DateTime? createdate { get; set; }
        public List<dtl_program_arrestpersonDto>? dtl_Program_ArrestpersonDto { get; set; }

    }


    public class dtl_program_arrestpersonDto
    {
       
        public string? arrestperson_name { get; set; }
        public string? arrestperson_designation { get; set; }
        public string? arrestperson_organizationname { get; set; }
        public string? arrestperson_mobile { get; set; }

    }
    public class program_masterViewDto : program_masterDto
    {

        public int? afterproid { get; set; }
        public string? district_name { get; set; }
        public string? policestation_name { get; set; }
        public string? categoryname { get; set; }
        public string? if_program_approved_text { get; set; }
        public string? if_affectlaw_sensitiveroute_text { get; set; }
        public string? if_arrestperson_text { get; set; }

    }
}

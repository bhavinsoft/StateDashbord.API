using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class after_program_master
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

    }

   
    public class dtl_program_suspension{
        public int recid { get; set; }
        public int dtlproid { get; set; }
        public string? p_name { get; set; }
        public string? p_number { get; set; }
        public string? p_adress { get; set; }
 
    }

    public class dtl_program_notcaught_suspension
    {
        public int recid { get; set; }
        public int dtlproid { get; set; }
        public string? p_name { get; set; }
        public string? p_number { get; set; }
        public string? p_adress { get; set; }

    }

    public class afterprogrammasterview : after_program_master
    {
      
        public List<dtl_program_suspension>? dtlprogramsuspension { get; set; }
        public List<dtl_program_notcaught_suspension>? dtlprogramnotcaughtsuspension { get; set; }
    }

    public class postafterprogrammaster
    {
        public after_program_master afterprogrammaster { get; set; }
        public List<dtl_program_suspension>? dtlprogramsuspension { get; set; }
        public List<dtl_program_notcaught_suspension>? dtlprogramnotcaughtsuspension { get; set; }
    }


}
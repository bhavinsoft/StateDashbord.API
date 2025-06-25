using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class dtl_program_arrestperson
    {
        public int recid { get; set; }
        public int programid { get; set; }
        public string? arrestperson_name { get; set; }
        public string? arrestperson_designation { get; set; }
        public string? arrestperson_organizationname { get; set; }
        public string? arrestperson_mobile { get; set; }
        
    }
}

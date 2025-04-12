using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class accused_list
    {
        public string? accused_name { get; set; }
        public string? accused_name_regional { get; set; }
        public string? accused_age { get; set; }
        public string? accused_pres_addr { get; set; }
        public string? accused_pres_addr_regional { get; set; }
        public string? accused_national_gender_cd { get; set; }
        public string? accused_occupation { get; set; }


    }
}

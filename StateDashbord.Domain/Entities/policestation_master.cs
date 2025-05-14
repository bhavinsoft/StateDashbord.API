using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class policestation_master
    {
        public int recid { get; set; }
        public int? districtid { get; set; }
        public string? policestation_name { get; set; }
        public string? policestation_code { get; set; }
        public DateOnly? createdate { get; set; }
       
    
    }
}

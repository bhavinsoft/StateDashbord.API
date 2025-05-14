using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.Model
{
    public class policestation_masterDto
    {
        public int recid { get; set; }
        public int? districtid { get; set; }
        public string? policestation_name { get; set; }
        public string? policestation_code { get; set; }
        public DateOnly? createdate { get; set; }


    }
}

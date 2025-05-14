using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.Model
{
    public class festival_masterDto
    {
        public int recid { get; set; }
        public int? district_id { get; set; }
        public int? policestation_id { get; set; }
        public string festival_details { get; set; }
        public DateTime? festival_date { get; set; }
        public string? remarks { get; set; }
        public DateTime? createdate { get; set; }

    }
}

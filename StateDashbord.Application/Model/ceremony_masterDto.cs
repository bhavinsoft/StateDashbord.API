using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.Model
{
    public class ceremony_masterDto
    {
        public int recid { get; set; }
        public int? district_id { get; set; }
        public int? policestation_id { get; set; }
        public string? ceremony_details { get; set; }
        public string? ceremony_venue { get; set; }
        public DateTime? ceremony_date { get; set; }
        public string? remarks { get; set; }
        public DateTime? createdate { get; set; }

    }
}

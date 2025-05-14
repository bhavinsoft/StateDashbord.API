using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class ceremony_master
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

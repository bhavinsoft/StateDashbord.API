using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class festival_master
    {
        public int recid { get; set; }
        public int? district_id { get; set; }
        public int? policestation_id { get; set; }
        public string festival_details { get; set; }
        public DateTime? festival_date { get; set; }
        public string? remarks { get; set; }
        public DateTime? createdate { get; set; }

    
    }

    public class festival_masterView : festival_master
    {
        public string? district_name { get; set; }
        public string? policestation_name { get; set; }
      
    }
    
}

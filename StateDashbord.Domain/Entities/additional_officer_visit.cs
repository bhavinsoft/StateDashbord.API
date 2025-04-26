using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class additional_officer_visit
    {
        public int recid { get; set; }
        public string? additional_officer_name { get; set; }
        public string? additional_officer_designation { get; set; }
        public string? additional_officer_mobileno { get; set; }
        public DateTime? visit_date { get; set; }
        public string? visit_time { get; set; }
        public int? friid { get; set; }
       
    }
}

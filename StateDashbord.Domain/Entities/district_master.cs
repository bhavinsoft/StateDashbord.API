using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class district_master
    {
        public int recid { get; set; }
        public string? district_name { get; set; }
        public string? district_code { get; set; }
        public string? createdate { get; set; }
       
    }
}

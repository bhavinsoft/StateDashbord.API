using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class additional_accused_list
    {
        public int recid { get; set; }
        public string? additional_accused_name { get; set; }
        public string? additional_accused_address { get; set; }
        public string? additional_accused_mobileNo { get; set; }
        public int? friid { get; set; }
       
    }
}

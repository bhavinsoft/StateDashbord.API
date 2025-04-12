using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class investigating_officer
    {
        public int recid { get; set; }
        public string? io_rank { get; set; }
        public string? io_name { get; set; }
        public string? io_name_regional { get; set; }
        public int? friid { get; set; }


    }
}

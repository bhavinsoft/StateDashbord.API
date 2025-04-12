using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class occurrence_of_offence
    {
        public int recid { get; set; }
        public string? to_dt { get; set; }
        public string? from_time { get; set; }
        public string? from_dt { get; set; }
        public string? to_time { get; set; }
        public int? friid { get; set; }

    }
}

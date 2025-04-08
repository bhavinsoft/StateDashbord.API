using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class DashbordCount
    {
        public int id { get; set; }
        public string? tittle { get; set; }
        public int? count { get; set; }
    
    }
}

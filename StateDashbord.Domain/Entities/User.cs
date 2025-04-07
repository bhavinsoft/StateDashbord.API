using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class User
    {
        public int recid { get; set; }
        public string? fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? emilid { get; set; }
        public string? mobileno { get; set; }
        public string? token { get; set; }
        public int? rollid { get; set; }

    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.Model
{
    public class usermaster
    {
        public int recid { get; set; }
        public string? fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? emilid { get; set; }
        public string? mobileno { get; set; }
        public int? rollid { get; set; }

    }
}

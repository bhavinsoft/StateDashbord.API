using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class FriRequest
    {
        public DateOnly? from_date { get; set; }
        public DateOnly? to_date { get; set; }
    }
}

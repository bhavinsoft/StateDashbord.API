using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class JsonRequestLog
    {
        
        public string Id { get; set; }

        public string JsonData { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}

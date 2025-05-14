using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class application_master
    {
        public int recid { get; set; }
        public int? district_id { get; set; }
        public int? policestation_id { get; set; }
        public string application_Details { get; set; }
        public string? applicant_name { get; set; }
        public string? applicant_address { get; set; }
        public string? applicant_mobile { get; set; }
        public string? applicant_organization { get; set; }   
        public string? application_submitted_office { get; set; }   
        public int? applicants_number { get; set; }   
        public DateTime? application_due_date { get; set; }   
        public string? remarks { get; set; }   
        public DateTime? createdate { get; set; }   
      
    
    }
}

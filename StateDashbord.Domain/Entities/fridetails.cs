using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class fridetails
    {
        public fridetailsmaster? fridetailsmaster { get; set; }
        public List<actdetails>? acts { get; set; }
        public complainant_details_scrb? complainan_detail_sscrb { get; set; }
        public occurrence_of_offence? occurrence_Of_Offence { get; set; }
        public investigating_officer? investigating_Officer { get; set; }
        public List<accused_list>? accused_Lists { get; set; }
        public visiting_details_scrb? visiting_details_scrb { get; set; }
        public additional_information? additional_information { get; set; }
        public List<additional_accused_list>? additional_accused_list { get; set; }
        public List<additional_officer_visit>? additional_officer_visit { get; set; }

    }

  

}

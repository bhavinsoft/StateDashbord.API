﻿using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Domain.Entities
{
    public class FridataListDto
    {
        public int recid { get; set; }
        public string? ps_cd { get; set; }
        public string? ps_name { get; set; }
        public string? fir_reg_num { get; set; }
        public string? reg_dt { get; set; }
        public string? city_district_name { get; set; }
        public string? crimehead_desc_guj { get; set; }

    }
}

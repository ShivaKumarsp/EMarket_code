using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.HubManager
{
    public class Hub_ConsignmentDTO
    {
        public long user_id { get; set; }
        public long language_id { get; set; }
        public long consignment_id { get; set; }
        public string procedure_name { get; set; } 
        public string ipAddress { get; set; }
        public string apitype { get; set; }


        public string hub_consignment_list { get; set; }
        public string hub_route_details { get; set; }
    }
}

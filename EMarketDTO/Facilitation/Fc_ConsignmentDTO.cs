using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Facilitation
{
    public class Fc_ConsignmentDTO
    {
        public long user_id { get; set; }
        public long language_id { get; set; }
        public long delivery_executive_id { get; set; }
        public long consignment_id { get; set; }
        public string procedure_name { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public long facilitation_id { get; set; }
        public string status { get; set; }
        public string order_by { get; set; }


        public string fc_consignment_list_from_vendor { get; set; }
        public string fc_consignment_list_from_hub { get; set; }
        public string fc_to_cs_consignment_list { get; set; }
        public string fc_to_hub_consignment_list { get; set; }
        public string executive_list { get; set; }
        public consignment_array12[] consignment_array { get; set; }
        public consignment_fc_hub1[] consignment_fc_hub { get; set; }
    }
}

public class consignment_array12
{
    public long consignment_id { get; set; }
    public long customer_id { get; set; }
    public string tracking_id { get; set; }
    public long first_hub_id { get; set; }
    public long last_hub_id { get; set; }
    public long first_facilitation_id { get; set; }
    public long last_facilitation_id { get; set; }
}

public class consignment_fc_hub1
{
    public long consignment_id { get; set; }
    public long first_hub_id { get; set; }
    public string tracking_id { get; set; }
}

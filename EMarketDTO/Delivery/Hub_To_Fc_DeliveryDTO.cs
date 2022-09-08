using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Delivery
{
   public  class Hub_To_Fc_DeliveryDTO
    {
        public long user_id { get; set; }
        public long language_id { get; set; }
        public long hub_id { get; set; }
        public long facilitation_center_id { get; set; }
        public long delivery_executive_id { get; set; }
        public long consignment_id { get; set; }
        public string procedure_name { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public long facilitation_id { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string reasion { get; set; }
        public Array request_delivery_list { get; set; }
        public Array pickup_delivery_list { get; set; }
        public Array drop_delivery_list { get; set; }
    }
}

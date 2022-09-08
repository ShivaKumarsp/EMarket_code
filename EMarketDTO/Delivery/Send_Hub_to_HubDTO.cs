using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Delivery
{
    public class Send_Hub_to_HubDTO
    {
        public string ipAddress { get; set; }
        public long user_id { get; set; }
        public long delivery_executive_id { get; set; }
        public long batch_id { get; set; }
        public long language_id { get; set; }
        public string procedure_name { get; set; }
        public string apitype { get; set; }
        public long delivery_accept_id { get; set; }
        public long order_item_id { get; set; }
        public long consignment_id { get; set; }
        public long order_id { get; set; }
        public decimal collected_amount { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string reasion { get; set; }


        public Array request_delivery_list { get; set; }
        public Array pickup_delivery_list { get; set; }
        public Array pickup_delivery_list_details { get; set; }
        public Array drop_delivery_list_details { get; set; }
        public Array drop_delivery_list { get; set; }
        public Array all_item_details { get; set; }
        public hub_to_hub_array1[] hub_to_hub_array { get; set; }

        public class hub_to_hub_array1
        {
            public long consignment_id { get; set; }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.HubManager
{
    public class Assign_Hub_to_HubDTO
    {
        public long user_id { get; set; }
        public long l_hub_id { get; set; }
        public long language_id { get; set; }
        public long last_hub_id { get; set; }
        public long receive_hub_id { get; set; }
        public long hub_route_id { get; set; }
        public long hub_id { get; set; }
        public long hub_type_id { get; set; }
        public long hub_city_id { get; set; }
        public long batch_id { get; set; }
        public long delivery_executive_id { get; set; }
        public long route_id { get; set; }
        public long consignment_id { get; set; }
        public string procedure_name { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public long facilitation_id { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public long hub_vehicle_id { get; set; }
        public long own_vehicle { get; set; }
        public long transport_mode_id { get; set; }
        public string vehicle_no { get; set; }
        public long vehicle_type_id { get; set; }
        public long mobile { get; set; }
        public string fleet_manager_name { get; set; }
        public string email { get; set; }
        public DateTime expected_dispatch_date { get; set; }
        public DateTime expected_reaching_date { get; set; }
        public TimeSpan expected_dispatch_time { get; set; }
        public TimeSpan expected_reaching_time { get; set; }


        public string hub_to_hub_list { get; set; }
        public string destination_hub_list { get; set; }
        public string executive_list_dd { get; set; }
        public string hub_vehicle_list_dd { get; set; }
        public string hub_transport_route { get; set; }
        public string batch_print_details { get; set; }
        public string assign_pickup_from_pt_to_hub { get; set; }
        public string hub_to_hub_print_list { get; set; }
        public string hub_area_list { get; set; }
        public string hub_name_list { get; set; }
        public string transport_mode_list { get; set; }
        public string transport_vehicle_type_list { get; set; }
        public hu_to_hub_array1[] hu_to_hub_array { get; set; }
        public pt_to_hub_array1[] pt_to_hub_array { get; set; }

        public class hu_to_hub_array1
        {
            public long consignment_id { get; set; }
            public string tracking_id { get; set; }
            public long last_facilitation_id { get; set; }
            public long last_hub_id { get; set; }
            public long hub_city { get; set; }
        }

        public class pt_to_hub_array1
        {
            public long consignment_id { get; set; }
            public long batch_id { get; set; }
        }

    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Admin
{
    public class Hub_RouteDTO
    {
        public long user_id { get; set; }
        public long pincode_id { get; set; }
        public long language_id { get; set; }
        public long country_id { get; set; }
        public long state_id { get; set; }
        public long city_id { get; set; }
        public long pincode { get; set; }
        public long hub_route_id { get; set; }
        public string ipAddress { get; set; }
        public string procedure_name { get; set; }
        public string apitype { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string area { get; set; }
        public long source_hub_id { get; set; }
        public long destination_hub_id { get; set; }
        public long transport_id { get; set; }
        public double distance { get; set; }
        public TimeSpan departure_time { get; set; }
        public double travel_time_hour { get; set; }
        public double travel_time_minute { get; set; }


        public string hub_list_1 { get; set; }
        public string hub_list_2 { get; set; }
        public string transportation_type_list { get; set; }
        public string hub_route_list { get; set; }
        public Array validation_list { get; set; }
    }
}

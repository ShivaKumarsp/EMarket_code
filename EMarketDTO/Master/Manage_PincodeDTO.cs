using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Master
{
   public class Manage_PincodeDTO
    {
        public long user_id { get; set; }
        public long pincode_id { get; set; }
        public long language_id { get; set; }
        public long hub_id { get; set; }
        public long country_id { get; set; }
        public long state_id { get; set; }
        public long city_id { get; set; }
        public long pincode { get; set; }
        public string ipAddress { get; set; }
        public string procedure_name { get; set; }
        public string apitype { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string area { get; set; }


        public string country_list { get; set; }
        public string state_list { get; set; }
        public string city_list { get; set; }
        public string all_pincode_list { get; set; }
        public Array validation_list { get; set; }
    }
}

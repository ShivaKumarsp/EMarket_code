using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Master
{
   public class MasterFacilitationDTO
    {
        public long user_id { get; set; }
        public long language_id { get; set; }
        public long country_id { get; set; }
        public long state_id { get; set; }
        public long city_id { get; set; }
        public long pincode_id { get; set; }
        public long pincode { get; set; }
        public long contact_no { get; set; }
        public long consignment_id { get; set; }
        public long hub_id { get; set; }
        public long facilitation_id { get; set; }
        public long map_fc_pincode_id { get; set; }
        public string procedure_name { get; set; }
        public string email { get; set; }
        public string facilitation_name { get; set; }
        public string address { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public long spin_id { get; set; }


        public string country_list { get; set; }
        public string state_list { get; set; }
        public string city_list { get; set; }
        public string pincode_list { get; set; }
        public string hub_list { get; set; }
        public string facilitation_list { get; set; }
        public string facilitation_hub_list { get; set; }
        public string facilitation_dd { get; set; }
        public string pincode_dd { get; set; }
        public string facilitation_pincode_list { get; set; }
        public  pincode_array1[] pincode_array { get; set; }

        public class pincode_array1
        {
            public long pincode_id { get; set; }
        }

    }
}


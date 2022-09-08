using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Master
{
   public class Master_Vehicle_TypeDTO
    {
        public long user_id { get; set; }
        public long pincode_id { get; set; }
       public long language_id { get; set; }
        public long hub_id { get; set; }
        public string ipAddress { get; set; }
        public string procedure_name { get; set; }
        public string apitype { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string order_by { get; set; }
        public long vehicle_type_id { get; set; }
        public string vehicle_type { get; set; }
        public string vehicle_type_details { get; set; }
        public decimal max_weight { get; set; }
        public decimal max_volumetric_length { get; set; }
        public decimal max_volumetric_breadth { get; set; }
        public decimal max_volumetric_height { get; set; }
        public string pickup_type { get; set; }
        public decimal pickup_volumetric_length { get; set; }
        public decimal pickup_volumetric_breadth { get; set; }
        public decimal pickup_volumetric_heigth { get; set; }
   
        public Array validation_list { get; set; }
        public string vehicle_type_list { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Facilitation
{
    public class Assign_ConsignmentDTO
    {
        public long user_id { get; set; }
        public long pincode_id { get; set; }
        public long delivery_executive_id { get; set; }
        public long language_id { get; set; }
        public long hub_id { get; set; }
        public string ipAddress { get; set; }
        public string procedure_name { get; set; }
        public string apitype { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string order_by { get; set; }
        public long facilitation_id { get; set; }


        public long store_id { get; set; }
        public string store_name { get; set; }
        public long consignment_id { get; set; }
        public double consignment_l { get; set; }
        public double consignment_b { get; set; }
        public double consignment_h { get; set; }
        public double weight { get; set; }
        public long first_hub_id { get; set; }
        public long last_hub_id { get; set; }
        public long hub_route_id { get; set; }
        public long order_item_id { get; set; }
        public long hand_over { get; set; }
        public bool is_check { get; set; }
        public string hub_route { get; set; }
        public long vendor_id { get; set; }
        public string tracking_id { get; set; }
        public double volumetric_weight { get; set; }
        public string pickup_location { get; set; }
        public string item_name { get; set; }
        public long pincode { get; set; }


        public Array consignment_list { get; set; }
        public string executive_list { get; set; }
        public string consignment_generared_list { get; set; }
        public string consignment_store_list { get; set; }
        public string store_list { get; set; }
        public consignment_array1[] consignment_array { get; set; }
        public get_data_list1[] get_data_list { get; set; }
    }
}


public class consignment_array1
{
    public long consignment_id { get; set; }
    public long store_id { get; set; }
    public long vendor_id { get; set; }
    public string tracking_id { get; set; }

}
public class get_data_list1
{
    public long store_id { get; set; }
}
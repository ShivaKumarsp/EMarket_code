using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Vendar
{
    public class ConsignmentDTO
    {
        public long user_id { get; set; }
        public long pincode_id { get; set; }
        public long language_id { get; set; }
        public long country_id { get; set; }
        public long state_id { get; set; }
        public long city_id { get; set; }
        public long pincode { get; set; }
        public string ipAddress { get; set; }
        public string procedure_name { get; set; }
        public string apitype { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public float consignment_l { get; set; }
        public long consignment_id { get; set; }
        public long order_id { get; set; }
        public float consignment_b { get; set; }
        public float consignment_h { get; set; }
        public float weight { get; set; }
        public long first_hub_id { get; set; }
        public long last_hub_id { get; set; }
        public string consignment_status { get; set; }
        public long hub_route_id { get; set; }
        public string hub_route { get; set; }
        public long order_item_id { get; set; }
        public string invoice_number { get; set; }
        public long item_id { get; set; }


        public Array validation_list { get; set; }
        public string hub_list_1 { get; set; }
        public string hub_list_2 { get; set; }
        public Array hub_list_cal { get; set; }
        public string consignment_list { get; set; }
        public string order_item_list { get; set; }
        public string consignment_print_data { get; set; }
        public string consignment_print_data_two { get; set; }
        public string edit_consignment_data { get; set; }
        public string handover_list { get; set; }
        public string all_handover_list { get; set; }
        public string hub_route_list { get; set; }
        public hubarray1[] hubarray { get; set; }
        public handover_array1[] handover_array { get; set; }
        //Mukta 20-8-2022
        public string invoice_list { get; set; }
        public string invoice_list_one { get; set; }
        public string invoice_list_two { get; set; }
        public string readytohandover_list { get; set; }


    }
}

public class handover_array1
{
    public long consignment_id { get; set; }
    public long first_hub_id { get; set; }
}

public class hubarray1
{
    public long first_hub_id { get; set; }
    public long last_hub_id { get; set; }
    public DateTime movement_date_time { get; set; }
}
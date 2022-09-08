using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Customer
{
    public class Landing_Item_DetailsDTO
    {
        public long user_id { get; set; }
        public string username { get; set; }
        public string token { get; set; }
        public long roleid { get; set; }
        public string rolename { get; set; }
        public long customer_id { get; set; }
        public long language_id { get; set; }
        public long item_id { get; set; }
        public long product_id { get; set; }
        public bool statusflg { get; set; }
     
        public string msg_flg { get; set; }
        public string message { get; set; }
        public string ipAddress { get; set; }
        public string procedure_name { get; set; }
        public string inputvalue { get; set; }
        public string apitype { get; set; }
        public long specification_id { get; set; }
        public string similar_item_list { get; set; }
        public string session_cart { get; set; }
        public Array item_list { get; set; }
        public Array cartlist { get; set; }
        public Array specification_list { get; set; }
        public Array specification_details_list { get; set; }
        public Array featurelist { get; set; }
        public Array all_variant_attr_list { get; set; }
        public Array all_product_speficication { get; set; }
        public Array all_product_variant_one { get; set; }
        public Array all_product_variant_two { get; set; }
        public Array single_variant_attr { get; set; }
        public Array rating_list { get; set; }
        public Array multiple_image_list { get; set; }
        public string hub_list { get; set; }
        public string hub_route_list { get; set; }
    }
}

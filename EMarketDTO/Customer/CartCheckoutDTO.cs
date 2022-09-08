using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Customer
{
    public class CartCheckoutDTO
    {
        public long user_id { get; set; }
        public long address_id { get; set; }
        public string username { get; set; }
        public string token { get; set; }
        public long roleid { get; set; }
        public string rolename { get; set; }
        public long customer_id { get; set; }
        public long cartcount { get; set; }
        public long language_id { get; set; }
        public long item_id { get; set; }
        public long product_id { get; set; }
        public long shippingaddress_id { get; set; }
        public string name { get; set; }
        public string msg_flg { get; set; }
        public string email { get; set; }
        public long mobile { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string city { get; set; }
        public string land_mark { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public string procedure_name { get; set; }
        public string inputvalue { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public long? pincode { get; set; }
        public long vpincode { get; set; }
        public string session_cart { get; set; }
        public long invoice_count { get; set; }
        public long invoice_count1 { get; set; }
        public bool default_address { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public long gender_id { get; set; }
        public string address { get; set; }
        public long state_id { get; set; }
        public long country_id { get; set; }

        public string checkpincode { get; set; }
        public Array validation_list { get; set; }
        public Array shipping_address_list { get; set; }
        public Array mycartlist { get; set; }
        public Array country_list { get; set; }
        public Array state_list { get; set; }
        public Array gender_list { get; set; }
        public Array invoice_list { get; set; }
        public Array user_invoice_list { get; set; }
    }
}

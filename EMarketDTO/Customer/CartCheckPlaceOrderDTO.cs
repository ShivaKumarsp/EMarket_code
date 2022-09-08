using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Customer
{
    public class CartCheckPlaceOrderDTO
    {
        public long user_id { get; set; }
        public string username { get; set; }
        public long roleid { get; set; }
        public string rolename { get; set; }
        public long order_id { get; set; }
        public string customer_name { get; set; }
        public string ret_itemname { get; set; }
        public long? ret_itemqty { get; set; }
        public string payment_order_id { get; set; }
        public string log_error { get; set; }
        public long customer_id { get; set; }
        public long language_id { get; set; }
        public long item_id { get; set; }
        public long product_id { get; set; }
        public long shippingaddress_id { get; set; }
        public string name { get; set; }
        public string token { get; set; }
        public bool status_flg { get; set; }
        public string status { get; set; }
        public string msg_flg { get; set; }
        public string return_message { get; set; }
        public string inputvalue { get; set; }
        public string email { get; set; }
        public long mobile { get; set; }
        public decimal payable_amount { get; set; }
        public decimal total_order_amount { get; set; }
        public decimal discount_amount { get; set; }
        public decimal tax_amount { get; set; }
        public decimal gross_amount { get; set; }
        public decimal delivery_charge { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string city { get; set; }
        public string land_mark { get; set; }
        public long pincode { get; set; }
        public bool default_address { get; set; }
        public string payment_orderid { get; set; }
        public string payment_transaction_id { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public string procedure_name { get; set; }
     

        public Array shipping_address_list { get; set; }
        public Array mycartlist { get; set; }
        public Array qtu_update_list { get; set; }
        public ordercartlist_1[] ordercartlist { get; set; }

        public class ordercartlist_1
        {
            public long productid { get; set; }
            public long itemid { get; set; }
            public long quantity { get; set; }
            public long totquantity { get; set; }
            public decimal selling_price { get; set; }
            public decimal mrp { get; set; }

        }

    }
}

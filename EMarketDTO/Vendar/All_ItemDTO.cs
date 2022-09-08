using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Vendar
{
    public class All_ItemDTO
    {
        public long user_id { get; set; }
        public string username { get; set; }
        public long roleid { get; set; }
        public long vendor_id { get; set; }
        public string rolename { get; set; }
        public long language_id { get; set; }
        public string message { get; set; }
        public long item_id { get; set; }
        public long specification_id { get; set; }
        public long attributename_id { get; set; }
        public long attributevalue_id { get; set; }
        public long itemspecification_id { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public long item_type_id { get; set; }
        public bool is_active { get; set; }
        public long currency_id { get; set; }
        public long product_id { get; set; }
        public DateTime expiry_date { get; set; }
        public DateTime manufacture_date { get; set; }
        public long country_origin_id { get; set; }
        public string manufacture_details { get; set; }
        public long warranty_uom_id { get; set; }
        public int warranty { get; set; }
        public decimal mrp { get; set; }
        public decimal listing_price { get; set; }
        public long min_quantity { get; set; }
        public bool out_of_stock { get; set; }
        public long store_id { get; set; }
        public long created_by { get; set; }
        public DateTime created_on { get; set; }
        public long updated_by { get; set; }
        public bool status { get; set; }
        public DateTime updated_on { get; set; }
        public long durability_umo { get; set; }
        public decimal durability { get; set; }
        public bool check_durability { get; set; }
        public string messageflg { get; set; }
        public string msg_flg { get; set; }
        public string item_image { get; set; }
        public string sku { get; set; }
        public string ret_item_name { get; set; }
        public long ret_item_id { get; set; }
        public long out_itemid { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }

        public Array all_item_list { get; set; }
        public Array currencylist { get; set; }
        public Array warrantytypelist { get; set; }
        public Array storelist { get; set; }
        public Array productlist { get; set; }
        public string product_details { get; set; }
        public Array countrylist { get; set; }
        public Array producttypelist { get; set; }
        public Array edit_item_list { get; set; }
        public Array attribute_value_list { get; set; }
        public Array item_specification_list { get; set; }
    }
}

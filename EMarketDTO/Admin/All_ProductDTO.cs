using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Admin
{
    public class All_ProductDTO
    {
        public long user_id { get; set; }
        public string username { get; set; }
        public long roleid { get; set; }
        public string rolename { get; set; }
        public long language_id { get; set; }
        public bool enable_custom_value { get; set; }
        public long product_id { get; set; }
        public long ret_product_id { get; set; }
        public long out_productid { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public long product_type_id { get; set; }
        public long category_id { get; set; }
        public long sub_category_id { get; set; }
        public long special_category_id { get; set; }
        public long additional_cat_id { get; set; }
        public bool self_manufacturer { get; set; }
        public long brand_id { get; set; }
        public string short_description { get; set; }
        public string image_path { get; set; }
        public bool is_perishable { get; set; }
        public bool is_active { get; set; }
        public bool is_verify { get; set; }
        public long verify_status_id { get; set; }
        public long uom_id { get; set; }
        public long uom_size { get; set; }
        public double product_size_l { get; set; }
        public double product_size_b { get; set; }
        public double product_size_h { get; set; }
        public long uom_weight { get; set; }
        public long uom_size_type_id { get; set; }
        public long uom_weight_type_id { get; set; }
        public double product_weight { get; set; }
        public string hsn_code { get; set; }
        public string ian_code { get; set; }
        public bool is_contains_bom { get; set; }
        public long created_by { get; set; }
        public decimal base_price { get; set; }
        public long specification_id { get; set; }
        public long product_specification_id { get; set; }
        public long attribute_name_id { get; set; }
        public string msg_flg { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public long attributename_id { get; set; }
        public long attributevalue_id { get; set; }
        public string ipAddress { get; set; }
        public string inputvalue { get; set; }
        public string procedure_name { get; set; }
        public string all_product_list { get; set; }
        public Array category_list { get; set; }
        public Array product_type_list { get; set; }
        public Array brand_list { get; set; }
        public Array uom_list { get; set; }
        public Array single_product_list { get; set; }
        public Array attribute_value_list { get; set; }
        public Array product_specification_list { get; set; }
        public Array specificationlist { get; set; }
        public Array masterproductspeclist { get; set; }
        public Array productattributelist { get; set; }
    }
}

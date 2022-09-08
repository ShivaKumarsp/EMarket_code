using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMarket.Entities.Vendar
{
    [Table("product_item", Schema = "public")]
    public class Vendor_Add_ItemDMO
    {
        [Key]
        public long item_id { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public long item_type_id { get; set; }
        public bool is_active { get; set; }
        public long currency_id { get; set; }
        public long product_id { get; set; }
        public long vendor_id { get; set; }
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
        public long? updated_by { get; set; }
        public DateTime? updated_on { get; set; }
        public long durability_umo { get; set; }
        public decimal durability { get; set; }
        public bool check_durability { get; set; }
        public long language_id { get; set; }
        public string sku { get; set; }
        public long? quantity { get; set; }
        public string group_code { get; set; }
        public string item_image { get; set; }
        public string verify_status { get; set; }
        public string remarks { get; set; }

    }
}

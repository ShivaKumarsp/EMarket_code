using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Admin
{
    [Table("master_product", Schema = "public")]
    public class Master_Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long product_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public long product_type_id { get; set; }
        public long category_id { get; set; }
    
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
        public double product_weight { get; set; }
        public string hsn_code { get; set; }
        public string ian_code { get; set; }
        public bool is_contains_bom { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_on { get; set; } 
        public long? updated_by { get; set; }
        public DateTime? updated_on { get; set; }
        public decimal base_price { get; set; }
        public long language_id { get; set; }
        public long sub_category_id { get; set; }

        public long additional_cat_id { get; set; }
    }
}

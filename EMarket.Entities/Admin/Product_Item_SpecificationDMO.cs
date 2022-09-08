using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Admin
{
    [Table("product_item_specification", Schema = "public")]
    public class Product_Item_SpecificationDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long item_specification_id { get; set; }
        public long item_id { get; set; }
        public long specification_id { get; set; }
        public long attribute_name_id { get; set; }
        public long attribute_value_id { get; set; }
        public bool is_active { get; set; }
        public DateTime? created_on { get; set; }
        public DateTime? updated_on { get; set; }
             public string attribute_value { get; set; }
        public bool enable_custom_value { get; set; }

    }
}

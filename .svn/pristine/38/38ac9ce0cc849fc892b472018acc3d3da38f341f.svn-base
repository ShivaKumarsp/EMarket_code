using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Admin
{
    [Table("product_specification", Schema = "public")]
    public class Product_SpecificationDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long product_specification_id { get; set; }
        public long product_id { get; set; }
        public long specification_id { get; set; }
        public long attribute_name_id { get; set; }
        public long attribute_value_id { get; set; }
        public string  property_name { get; set; }
        public string property_details { get; set; }
        public bool is_active { get; set; }
        public long language_id { get; set; }
    }
}

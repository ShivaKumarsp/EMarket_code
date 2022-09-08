using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Admin
{
    [Table("specification_for_vendor", Schema = "public")]
    public class Specification_for_VendorDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long product_specid { get; set; }
        public long product_id { get; set; }
        public long specification_id { get; set; }
        public long attribute_name_id { get; set; }
       public bool enable_custom_value { get; set; }
       public bool is_variant_attribute { get; set; }
        public bool is_visible { get; set; }
    }
}

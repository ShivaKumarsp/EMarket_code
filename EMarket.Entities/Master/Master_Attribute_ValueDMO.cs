using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Master
{
    [Table("master_attribute_value", Schema = "public")]
    public class Master_Attribute_ValueDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long attribute_value_id { get; set; }
        public long attribute_name_id { get; set; }
        public string attribute_value { get; set; }
        public string attribute_code { get; set; }
        public bool is_active { get; set; }
        public long language_id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Master
{
    [Table("master_specification", Schema = "public")]
    public class Master_SpecificationDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long specification_id { get; set; }
        public string specification_name { get; set; }
        public string specification_code { get; set; }
        public bool is_active { get; set; }
        public long language_id { get; set; }
    }
}

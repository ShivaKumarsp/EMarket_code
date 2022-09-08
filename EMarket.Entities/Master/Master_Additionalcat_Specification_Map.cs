using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Master
{
    [Table("master_additionalcat_specification_map", Schema = "public")]
    public class Master_Additionalcat_Specification_Map
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long cat_spe_map_id { get; set; }
        public long additional_cat_id { get; set; }
        public long specification_id { get; set; }
        public bool is_active { get; set; }
        public long created_by { get; set; }
        public DateTime created_on { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_on { get; set; }
    }
}

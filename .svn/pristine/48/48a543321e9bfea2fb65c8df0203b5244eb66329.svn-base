using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Facilitation
{
    [Table("batch_consignment", Schema = "public")]
   public class Batch_ConsignmentDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long bc_id { get; set; }
        public long batch_id { get; set; }
        public long consignment_id { get; set; }
    }
}

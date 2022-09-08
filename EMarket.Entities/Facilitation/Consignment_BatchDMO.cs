using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Facilitation
{
    [Table("consignment_batch", Schema = "public")]
   public class Consignment_BatchDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long batch_id { get; set; }
        public long send_by_role_id { get; set; }
        public long send_by_status_id { get; set; }
        public long receive_by_role_id { get; set; }
        public long receive_by_status_id { get; set; }
        public long created_by { get; set; }
        public DateTime created_on { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_on { get; set; }
    }
}

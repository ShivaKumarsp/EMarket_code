using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Facilitation
{
    [Table("master_batch", Schema = "public")]
    public class Master_BatchDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long batch_id { get; set; }
        public long send_by_id { get; set; }
        public long send_by_roleid { get; set; }
        public long send_by_status { get; set; }
        public long receive_by_id { get; set; }
        public long receive_by_roleid { get; set; }
        public long receive_by_status { get; set; }
        public DateTime? updated_on { get; set; }
       
    }
}

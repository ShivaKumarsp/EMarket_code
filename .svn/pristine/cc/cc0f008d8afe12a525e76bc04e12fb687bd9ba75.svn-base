using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Customer
{
    [Table("pod_check", Schema = "public")]
    public class POD_CheckDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long pod_id { get; set; }
        public long customer_id { get; set; }
        public DateTime pod_time { get; set; }
    }
}

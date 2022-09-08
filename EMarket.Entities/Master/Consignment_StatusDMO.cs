using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Master
{
    [Table("consignment_status", Schema = "public")]
    public class Consignment_StatusDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long consignment_status_id { get; set; }
        public string status { get; set; }
        public bool is_active { get; set; }
        public long? role_id { get; set; }
    }
}

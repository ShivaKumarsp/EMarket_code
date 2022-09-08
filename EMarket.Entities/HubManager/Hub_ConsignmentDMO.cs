using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.HubManager
{
    [Table("hub_consignment", Schema = "public")]
    public class Hub_ConsignmentDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long hub_consignment_id { get; set; }
        public long consignment_id { get; set; }
        public string tracking_id { get; set; }
        public long first_hub_id { get; set; }
        public long last_hub_id { get; set; }
        public long first_facilitation_id { get; set; }
        public long last_facilitation_id { get; set; }
        public string received_from { get; set; }
        public DateTime? received_on { get; set; }
        public long? received_by { get; set; }
    }
}

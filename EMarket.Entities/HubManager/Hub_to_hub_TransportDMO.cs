using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.HubManager
{
    [Table("hub_to_hub_transport", Schema = "public")]
    public class Hub_to_hub_TransportDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long hub_to_hub_txr_id { get; set; }
        public long source_hub_id { get; set; }

        public long destination_hub_id { get; set; }
    }
}

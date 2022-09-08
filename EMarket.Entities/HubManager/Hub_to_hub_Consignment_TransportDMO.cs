using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.HubManager
{
    [Table("hub_to_hub_consignment_transport", Schema = "public")]
    public class Hub_to_hub_Consignment_TransportDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long hub_con_transport_id { get; set; }
        public long source_hub_id { get; set; }
        public long destination_hub_id { get; set; }
        public long batch_id { get; set; }
        public long transport_mode_id { get; set; }
        public string vehicle_no { get; set; }
        public long vehicle_type_id { get; set; }
        public string fleet_manager_name { get; set; }
        public long mobile { get; set; }
        public string email { get; set; }
        public DateTime expected_dispatch_date { get; set; }
        public TimeSpan expected_dispatch_time { get; set; }
        public DateTime expected_reaching_date { get; set; }
        public TimeSpan expected_reaching_time { get; set; }
        public long created_by { get; set; }
        public DateTime created_on { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_on { get; set; }

    }
}

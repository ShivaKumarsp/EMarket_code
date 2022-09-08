using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Vendar
{
    [Table("consignment", Schema = "public")]
    public class Consignment_DMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long consignment_id { get; set; }
        public long order_id { get; set; }
        public long order_item_id { get; set; }
        public long item_id { get; set; }
        public double consignment_l { get; set; }
        public double consignment_b { get; set; }
        public double consignment_h { get; set; }
        public double weight { get; set; }
        public long first_hub_id { get; set; }
        public long last_hub_id { get; set; }
        public long first_facilitation_id { get; set; }
        public long last_facilitation_id { get; set; }
        public long hub_route_id { get; set; }
        public long store_id { get; set; }
        public long vendor_id { get; set; }
        public string hub_route { get; set; }
        public string tracking_id { get; set; }
        public DateTime updated_on { get; set; }
        public long updated_by { get; set; }
        public long is_print { get; set; }
        public bool is_ready_to_handover { get; set; }
        public long assign_to_delivery_boy { get; set; }
        public long hand_over { get; set; }
        public DateTime hand_over_on { get; set; }
        public string is_delivery_boy_accept { get; set; }
        public long delivery_to_facilitation { get; set; }
        public long facilitation_accept { get; set; }
        public long consignment_status_id { get; set; }

    }
}

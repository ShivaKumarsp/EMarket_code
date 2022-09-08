using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.HubManager
{
    [Table("hub_vehicle_details", Schema = "public")]
    public class Hub_Vehicle_DetailsDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long hub_vehicle_id { get; set; }
        public long hub_id { get; set; }
        public long vehicle_type_id { get; set; }
        public string vehicle_reg_number { get; set; }
        public string vehicle_details { get; set; }
        public long max_weight_kg { get; set; }
        public decimal max_volumetric_weight { get; set; }
        public long weight_type { get; set; }
        public decimal volumetric_weight { get; set; }
        public bool is_active { get; set; }
        public long belongs_to { get; set; }
        public long created_by { get; set; }
        public DateTime? created_on { get; set; }
        public long updated_by { get; set; }
        public DateTime? updated_on { get; set; }
    }
}

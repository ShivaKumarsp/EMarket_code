using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Facilitation
{
    [Table("vendor_to_facilitation", Schema = "public")]
    public class Vendor_To_FacilitationDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long vendor_facilitation_id { get; set; }
        public long consignment_id { get; set; }
        public string tracking_id { get; set; }
        public long batch_id { get; set; }
        public long vendor_id { get; set; }
        public long store_id { get; set; }
        public long first_hub_id { get; set; }
        public long last_hub_id { get; set; }
        public long first_facilitation_id { get; set; }
        public long last_facilitation_id { get; set; }
        public long delivery_executive_id { get; set; }
        public string delivery_executive_status { get; set; }
        public string facilitation_status { get; set; }
        public long assigned_by { get; set; }
        public DateTime? assigned_on { get; set; }
        public DateTime? delivered_on { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_on { get; set; }
        public long? received_by { get; set; }
        public DateTime? received_on { get; set; }
    }
}

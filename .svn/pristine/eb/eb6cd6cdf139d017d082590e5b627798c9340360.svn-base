using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Facilitation
{
    [Table("facilitation_to_customer", Schema = "public")]
    public class Facilitation_To_CustomerDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long facilitation_to_customer_id { get; set; }
        public long consignment_id { get; set; }
        public string tracking_id { get; set; }
        public long batch_id { get; set; }
        public long first_hub_id { get; set; }
        public long last_hub_id { get; set; }
        public long first_facilitation_id { get; set; }
        public long last_facilitation_id { get; set; }
        public long delivery_executive_id { get; set; }
        public string delivery_executive_status { get; set; }
        public long customer_id { get; set; }
        public long customer_otp { get; set; }
        public string customer_status { get; set; }
        public long assigned_by { get; set; }
        public DateTime? assigned_on { get; set; }
        public DateTime? delivered_on { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_on { get; set; }
        public string otp_status { get; set; }
    }
}

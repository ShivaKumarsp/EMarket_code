using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Master
{
    [Table("master_pincode", Schema = "public")]
    public class Master_PincodeDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long pincode_id { get; set; }
        public long pincode { get; set; }
        public long country_id { get; set; }
        public long state_id { get; set; }
        public long city_id { get; set; }
        public string area { get; set; }
        public DateTime created_on { get; set; }
        public DateTime? updated_on { get; set; }
        public bool is_active { get; set; }
    }
}

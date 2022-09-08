using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Facilitation
{
    [Table("facilitation_details", Schema = "public")]
    public class Facilitation_DetailsDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long facilitation_details_id { get; set; }
              public long user_id { get; set; }
        public string email { get; set; }
        public long mobile { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public long state_id { get; set; }
        public long country_id { get; set; }
        public long pincode { get; set; }
        public long hub_id { get; set; }
        public long facilitation_id { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Master
{
    [Table("master_facilitation", Schema = "public")]
    public class Master_FacilitationDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long facilitation_id { get; set; }
        public long hub_id { get; set; }
        public string facilitation_name { get; set; }
        public string email { get; set; }
        public long contact_no { get; set; }
        public string address { get; set; }
        public long pincode { get; set; }
        public long city_id { get; set; }
        public long state_id { get; set; }
        public long country_id { get; set; }
        public long created_by { get; set; }
        public DateTime? created_on { get; set; }
        public long updated_by { get; set; }
        public DateTime? updated_on { get; set; }
    }
}

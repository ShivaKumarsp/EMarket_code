using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.HubManager
{
    [Table("hub_manager_details", Schema = "public")]
    public class Hub_Manager_DetailsDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long hub_user_id { get; set; }
        public long user_id { get; set; }
        public long hub_id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public long gender_id { get; set; }
        public string email { get; set; }
        public long mobile { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public long state_id { get; set; }
        public long country_id { get; set; }
        public long pincode { get; set; }
        public DateTime? dob { get; set; }
        public long? alternative_mobile { get; set; }
        public string image_url { get; set; }
    }
}

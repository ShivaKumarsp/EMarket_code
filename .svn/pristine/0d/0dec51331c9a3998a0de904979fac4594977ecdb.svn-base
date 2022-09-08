using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Vendar
{
    [Table("master_store", Schema = "public")]
    public class Master_Store_DMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public long  store_id { get; set; }
       public string store_name { get; set; }
        public string store_title { get; set; }
        public string store_details { get; set; }
        public string store_image { get; set; }
        public long  vendor_id { get; set; }
        public string pickup_location { get; set; }
        public long? earning_link_id { get; set; }
        public string contact_name { get; set; }
        public string  contact_email { get; set; }
        public long? contact_primary_mobile { get; set; }
        public long? contact_alternate_mobile { get; set; }
        public string store_access_passcode { get; set; }
        public bool?  is_passcode_set { get; set; }
        public double?  store_rating { get; set; }
        public bool? is_active { get; set; }
        public long  created_by { get; set; }
        public DateTime created_on { get; set; }
        public long?  updated_by { get; set; }
        public DateTime?  updated_on { get; set; }
        public long  language_id { get; set; }
        public string  city { get; set; }
    }
}

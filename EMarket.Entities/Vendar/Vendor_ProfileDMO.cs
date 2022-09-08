using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMarket.Entities.Vendar
{
    [Table("vendor_details", Schema = "public")]
    public class Vendor_ProfileDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long vendor_id { get; set; }
        public long user_id { get; set; }
        public string vendor_name { get; set; }
        public string vendor_email { get; set; }
        public long? vendor_mobile { get; set; }
        public DateTime? vendor_dob { get; set; }
        public string vendor_panno { get; set; }
        public string vendor_address { get; set; }
        public string vendor_city { get; set; }
        public int? vendor_country_id { get; set; }
        public int? vendor_state_id { get; set; }
        public int? vendor_pincode { get; set; }
        public long? mg_id { get; set; }
        public string vendor_businessname { get; set; }
        public string business_address { get; set; }
        public int? business_state_id { get; set; }
        public int? business_country_id { get; set; }
        public int? business_pincode { get; set; }
        public bool? business_termscondiction { get; set; }
        public bool? vendor_gst_available { get; set; }
        public int? vendor_otp { get; set; }
        public long? business_type_id { get; set; }
        public string legal_name { get; set; }
        public string registration_no { get; set; }
        public string business_pan_no { get; set; }
        public DateTime created_on { get; set; }
        public long created_by { get; set; }
        public DateTime? updated_on { get; set; }
        public long? updated_by { get; set; }
        public bool approved_flg { get; set; }
        public long is_verify { get; set; }
    }
}

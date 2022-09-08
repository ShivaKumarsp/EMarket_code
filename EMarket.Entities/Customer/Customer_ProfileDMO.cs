using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMarket.Entities.Customer
{
    [Table("customer_details", Schema = "public")]
    public class Customer_ProfileDMO
    {
        [Key]
        public long customer_id { get; set; }
        public long user_id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string email { get; set; }
        public long? mobile { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public long? state_id { get; set; }
        public long? country_id { get; set; }
        public long? pincode { get; set; }
        public DateTime? dob { get; set; }
        public long? alternative_mobile { get; set; }
        public long? gender_id { get; set; }
        public string image_url { get; set; }

    }
}

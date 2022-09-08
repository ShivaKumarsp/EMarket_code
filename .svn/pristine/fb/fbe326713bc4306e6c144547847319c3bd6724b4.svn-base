using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Customer
{
    [Table("customer_shipping_address", Schema = "public")]
    public class Customer_Shipping_Address_DMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long shippingaddress_id { get; set; }
        public string name { get; set; }
        public long user_id { get; set; }
        public string email { get; set; }
        public long mobile { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string city { get; set; }
        public string land_mark { get; set; }
        public long pincode { get; set; }     
        public bool default_address { get; set; }
         public long country_id { get; set; }
         public long state_id { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Customer
{
    [Table("order_shipping_address", Schema = "public")]
    public class Order_Shipping_AddressDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long order_ship_id { get; set; }
        public long order_id { get; set; }
        public long user_id { get; set; }
        public long customer_id { get; set; }
        public string customer_name { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string city { get; set; }
        public long country_id { get; set; }
        public long state_id { get; set; }
        public long pincode { get; set; }
        public string land_mark { get; set; }
        public long mobile { get; set; }
        public string email_id { get; set; }
    }
}

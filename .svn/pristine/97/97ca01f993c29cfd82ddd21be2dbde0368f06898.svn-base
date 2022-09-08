using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Customer
{
    [Table("direct_checkout", Schema = "public")]
    public class Direct_CheckoutDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long checkout_id { get; set; }
        public long product_id { get; set; }
        public long item_id { get; set; }
        public long user_id { get; set; }
        public long customer_id { get; set; }
        public long quantity { get; set; }
        public string session_cart { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Customer
{
    [Table("cart_list", Schema = "public")]
    public class Cart_ListDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long cart_id { get; set; }
        public long product_id { get; set; }
        public long item_id { get; set; }
        public long customer_id { get; set; }
        public long userid { get; set; }
        public string session_cart { get; set; }
    }
}

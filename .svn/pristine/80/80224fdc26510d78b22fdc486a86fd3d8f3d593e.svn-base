using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Customer
{
    [Table("customer_order_item", Schema = "public")]
    public class Customer_Order_ItemDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long order_item_id { get; set; }
        public long order_id { get; set; }
        public long product_id { get; set; }
        public long item_id { get; set; }
        public long quantity { get; set; }
        public long status_id { get; set; }
        public DateTime activity_datetime { get; set; }
        public long coupon_id { get; set; }
        public decimal mrp { get; set; }
        public decimal selling_price { get; set; }
        public decimal invoice_price { get; set; }
        public string order_accept_status { get; set; }
        public string order_accept_comment { get; set; }
        public DateTime? accept_reject_on { get; set; }
    }
}

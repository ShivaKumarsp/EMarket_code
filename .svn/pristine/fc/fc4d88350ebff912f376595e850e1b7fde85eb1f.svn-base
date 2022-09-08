using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Customer
{
    [Table("payment_order_qty", Schema = "public")]
    public class Payment_Order_QtyDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long checkid { get;set;}
        public string payment_order_id { get;set;}
        public long item_id { get;set;}
        public long quantity { get;set;}
        public DateTime order_on { get;set;}
    }
}

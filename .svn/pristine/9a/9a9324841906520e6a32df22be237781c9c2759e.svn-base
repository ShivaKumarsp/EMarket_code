using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMarket.Entities.Customer
{
    [Table("order_item_txn", Schema = "public")]
    public class Order_Item_txnDMO

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long order_item_txn_id { get; set; }
        public long order_id { get; set; }
        public long order_txn_status_id { get; set; }
        public string status_details { get; set; }
        public bool is_activity_success { get; set; }
        public long created_by { get; set; }
        public DateTime created_on { get; set; }
        public long order_item_id { get; set; }
    }
}

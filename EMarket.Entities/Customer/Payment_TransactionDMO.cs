using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Customer
{
    [Table("payment_transaction", Schema = "public")]
    public class Payment_TransactionDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long payment_id { get; set; }
        public long customer_id { get; set; }
        public long user_id { get; set; }
        public long order_id { get; set; }
        public string payment_order_id { get; set; }
        public string payment_transaction_id { get; set; }
        public decimal amount { get; set; }
        public string mode_of_payment { get; set; }
        public string gateway_name { get; set; }
        public string payment_status { get; set; }
        public DateTime payment_date_time { get; set; }
    }
}

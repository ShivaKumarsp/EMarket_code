using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMarket.Entities.Customer
{
    [Table("payment_transaction_log", Schema = "public")]
    public class Payment_Transaction_logDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long payment_log_id { get; set; }
        public long payment_id { get; set; }
        public string payment_transaction_id { get; set; }
        public DateTime payment_txn_date_time { get; set; }
        public string payment_txn_status { get; set; }
        public string payment_txn_log_details { get; set; }
        public bool is_txn_success { get; set; }
    }
}

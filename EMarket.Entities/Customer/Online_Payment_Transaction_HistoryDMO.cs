using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMarket.Entities.Customer
{
    [Table("online_payment_transaction_history", Schema = "public")]
    public class Online_Payment_Transaction_HistoryDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long online_payment_history_id { get; set; }
        public long online_payment_id { get; set; }
        public string payment_transaction_id { get; set; }
        public DateTime payment_txn_date_time { get; set; }
        public string payment_txn_status { get; set; }
        public string payment_txn_log_details { get; set; }
        public bool is_txn_success { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Customer
{
    [Table("customer_order", Schema = "public")]
    public class Customer_OrderDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long order_id { get; set; }
        public long payment_method_id { get; set; }
        public bool set_paid { get; set; }
        public long status_id { get; set; }
        public long user_id { get; set; }
        public long customer_id { get; set; }
        public string email { get; set; }
        public long? phone_number { get; set; }
        public long billing_address_id { get; set; }
      
        public bool is_gst_available { get; set; }
        public string gst_number { get; set; }
        public decimal delivery_charge { get; set; }
        public decimal gross_amount { get; set; }
        public long discount_id { get; set; }
        public long tax_calculate_id { get; set; }
        public decimal total_order_amount { get; set; }
        public decimal discount_amount { get; set; }
        public decimal tax_amount { get; set; }
        public decimal payable_amount { get; set; }
        public string payment_status { get; set; }
        public string transaction_id { get; set; }
        public string payment_order_id { get; set; }
        public DateTime? order_date { get; set; }
        public DateTime? payment_received_on { get; set; }
   
    }
}

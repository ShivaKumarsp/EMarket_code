using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Vendar
{
    [Table("item_invoice", Schema = "public")]
    public class Item_InvoiceDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long invoice_id { get; set; }
        public long consignment_id { get; set; }
        public long order_item_id { get; set; }
        public long store_id { get; set; }
        public string invoice_number { get; set; }
        public DateTime invoice_date { get; set; }
        public string gst_number { get; set; }
        public string item_type { get; set; }


    }
}

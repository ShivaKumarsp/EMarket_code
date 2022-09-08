using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Vendar
{
    public class Vendor_reassignDTO
    {
        public long userid { get; set; }
        public long vendor_id { get; set; }
        public long product_id { get; set; }
        public long quantity { get; set; }
        public string apitype { get; set; }
        public string ipAddress { get; set; }
        public long order_item_id { get; set; }
        public long item_id { get; set; }
        public string order_accept_status { get; set; }
        public string order_accept_comment { get; set; }
        public string vendorreassignlist { get; set; }
        public string vendoritemlist { get; set; }
        public string procedure_name { get; set; }
        public string msg_flg { get; set; }

    }
}

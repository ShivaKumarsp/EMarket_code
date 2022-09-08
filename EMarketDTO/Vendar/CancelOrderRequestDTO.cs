using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Vendar
{
    public class CancelOrderRequestDTO
    {
        public long user_id { get; set; }
        public long language_id { get; set; }
        public long vendor_id { get; set; }
        public long cancel_item_id { get; set; }
        public long return_item_id { get; set; }
        public long order_item_id { get; set; }
        public long order_id { get; set; }
        public string cancel_request_status { get; set; }
        public string cancel_request_reasion { get; set; }
        public string return_request_status { get; set; }
        public string return_request_reasion { get; set; }
        public string ipAddress { get; set; }
        public string procedure_name { get; set; }
        public string cancel_request_list { get; set; }
        public string return_request_list { get; set; }
        public string apitype { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }
}

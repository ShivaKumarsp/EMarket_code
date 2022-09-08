using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Admin
{
   public class OrderWise_ReportDTO
    {
        public long user_id { get; set; }
        public long language_id { get; set; }
        public long order_id { get; set; }
        public string apitype { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string ipAddress { get; set; }
        public string procedure_name { get; set; }
        public string orderwise_payment_list { get; set; }
        public string payment_details { get; set; }
        public DateTime from_date { get; set; }
        public DateTime to_date { get; set; }
    }
}

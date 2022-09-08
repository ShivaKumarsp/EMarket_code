using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.HubManager
{
    public class hubtofacilitationcenterDTO
    {
        public long language_id { get; set; }
        public long userid { get; set; }
        public string facilitationcenterlist { get; set; }
        public long hub_id { get; set; }
        public long parent_id { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public string consignmentlist { get; set; }
        public string procedure_name { get; set; }
        public string msg_flg { get; set; }
        public long created_by { get; set; }
        public string email_id { get; set; }
        public long contact_no { get; set; }
        public string vehicle_registration_no { get; set; }
        public string transportor_name { get; set; }
        public long transport_id { get; set; }
        public long transportor_id { get; set; }
        public string locallist { get; set; }
        public long send_by_id { get; set; }
        public long send_by_roleid { get; set; }
        public long send_by_status { get; set; }
        public long receive_by_id { get; set; }
        public long receive_by_roleid { get; set; }
        public long receive_by_status { get; set; }
        public string rdata { get; set; }
        public long batch_id { get; set; }
        public long consignment_id { get; set; }
        public long assign_id { get; set; }
        public long facilitation_center { get; set; }
        public DateTime scheduled_date { get; set; }
        //public DateTime departure_time { get; set; }
        public string departure_time { get; set; }
        public string facilitationschedulelist { get; set; }
        public string vehicletypelist { get; set; }
        public string pconsignmentlist { get; set; }
        public string messageflg { get; set; }
        public long vehicle_type { get; set; }
        public Decimal length { get; set; }
        public Decimal breadth { get; set; }
        public Decimal height { get; set; }
        public Decimal max_volume { get; set; }
        public Decimal max_weight { get; set; }
        public long facilitation_id { get; set; }
        public long type_of_consignment { get; set; }
        public long assigned_id { get; set; }
        public string batchlist { get; set; }

    }
}

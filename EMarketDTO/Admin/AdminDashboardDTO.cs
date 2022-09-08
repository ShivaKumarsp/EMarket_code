using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Admin
{
    public class AdminDashboardDTO
    {
        public long user_id { get; set; }
        public string username { get; set; }
        public long roleid { get; set; }
        public long language_id { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public string procedure_name { get; set; }
        public string user_list { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Master
{
    public class Master_CategoryDTO
    {
        public long user_id { get; set; }
        public string ipAddress { get; set; }
        public long language_id { get; set; }
        public string apitype { get; set; }
        public long mc_id { get; set; }
        public string category_name { get; set; }
        public string description { get; set; }
        public string image_url { get; set; }
        public bool is_active { get; set; }
        public string category_code { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string inputvalue { get; set; }
        public string procedure_name { get; set; }
        public long msc_id { get; set; }
        public string msc_name { get; set; }
        public string msc_description { get; set; }
        public bool msc_activeflg { get; set; }
        public string msc_imageurl { get; set; }

        public string category_list { get; set; }
        public string subcategory_list { get; set; }
        public string category_dd { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Admin
{
    public class BannerDTO
    {
        public long language_id { get; set; }
        public long add_cat_id { get; set; }
        public long user_id { get; set; }
        public long banner_id { get; set; }
        public long page_id { get; set; }
        public string procedure_name { get; set; }
        public string banner_title { get; set; }
        public string banner_link { get; set; }
        public string banner_details { get; set; }
        public string banner_image { get; set; }
        public bool is_active { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string banner_list { get; set; }
        public string page_list { get; set; }
        public string category_list { get; set; }
    }
}

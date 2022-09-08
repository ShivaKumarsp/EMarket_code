using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Admin
{
    public class product_featuresDTO
    {
        //public long product_feature_id { get; set; }
        public long product_id { get; set; }
        //public long datatype_id { get; set; }
        public String product_title { get; set; }
        public String product_header { get; set; }
        public String product_subheader { get; set; }
        public String description { get; set; }
        public long language_id { get; set; }
        public long created_by { get; set; }
        public DateTime created_on { get; set; }
        public long update_by { get; set; }
        public DateTime update_on { get; set; }
        public string image_name { get; set; }
        public string image_url { get; set; }
        public long roleid { get; set; }
        public string product_name { get; set; }
        public string msg_flg { get; set; }
        public string message_flg { get; set; }
        public String rolename { get; set; }
        public String ipAddress { get; set; }
        public String apitype { get; set; }
        public String procedure_name { get; set; }
        public String inputvalue { get; set; }
        //array
       
        public Array productslist { get; set; }
        public Array feature_list { get; set; }

        //status
        public Boolean statusflg { get; set; }
        public String messageflg { get; set; }
        public long in_pf_id { get; set; }
        public long ref_pf_id { get; set; }
        //error
        public long userid { get; set; }
        public long pf_id { get; set; }
        public doclist1[] imagelist { get; set; }
        public class doclist1
        {
            public string FilePath { get; set; }
            public string FileName { get; set; }
        }
    }
}

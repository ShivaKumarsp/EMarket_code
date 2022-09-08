using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Vendar
{
   public class Manage_SubsubcategoryDTO
    {
        //additional category
        public long additional_cat_id { get; set; }
        public long msc_id { get; set; }
        public string additional_cat_name { get; set; }
        public string additional_cat_code { get; set; }
        public string msg_flg { get; set; }
        public string username { get; set; }
        public string rolename { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public long language_id { get; set; }
        public long roleid { get; set; }
        public long userid { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public string inputvalue { get; set; }
        public string procedure_name { get; set; }
        public string subcatlist_dd { get; set; }
        public string category_dd { get; set; }
        public string subsubcatlist_grid { get; set; }
        //category

        public long mc_id { get; set; }
        public string category_name { get; set; }
        public string description { get; set; }
        public string image_url { get; set; }
        public bool is_active { get; set; }
        public string category_code { get; set; }
       
       //sub category

        public string msc_name { get; set; }
        public string msc_description { get; set; }
        public bool msc_activeflg { get; set; }
        public string msc_imagename { get; set; }
        public string msc_imageurl { get; set; }


    }
}

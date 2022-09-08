using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.LoginDTO
{
    public class Master_ModuleDTO
    {
        public long mm_id { get; set; }
        public long mp_id { get; set; }
        public string mm_name { get; set; }
        public string mm_icon { get; set; }
        public string mm_colour { get; set; }
        public bool mm_activeflg { get; set; }
        public string role { get; set; }
        public string mp_pagename { get; set; }
        public string mp_pageurl { get; set; }
        public string dashboardname { get; set; }
        public DateTime createddate { get; set; }
        public DateTime updatedate { get; set; }

        public string contact { get; set; }
        public string username { get; set; }
        public long userid { get; set; }
        public long vendor_id { get; set; }
        public long customer_id { get; set; }
        public long roleid { get; set; }
        public long language_id { get; set; }
        public string rolename { get; set; }
        public string get_token { get; set; }
        public string ipAddress { get; set; }
        public string procedure_name { get; set; }
        public string session_cart { get; set; }
        public long is_vendor_doc { get; set; }
        public bool is_vendor_profile { get; set; }
    
        // List
        public string category_list { get; set; }
        public string subcategory_list { get; set; }
        public string addcategory_list { get; set; }
        public Array getmodulelist { get; set; }
        public Array getpagelist { get; set; }
        public Array cartlist { get; set; }
        public Array user_details_list { get; set; }

    }
}

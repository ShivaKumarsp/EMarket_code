using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Master
{
   public class BrandDTO
    {
       public long brand_id { get; set; }
       public long language_id { get; set; }
       public String brand_name { get; set; }
       public String brand_code { get; set; }
       public String brand_description { get; set; }
       //public Array brandlist { get; set; }
       public long roleid { get; set; }
       public String rolename { get; set; }
       public Boolean statusflg { get; set; }
       public String messageflg { get; set; }
        public String image_url { get; set; }
        //array
       public Array languagelist { get; set; }

    }
}

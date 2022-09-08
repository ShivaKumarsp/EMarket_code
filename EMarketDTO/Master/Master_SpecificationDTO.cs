using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Master
{
   public class Master_SpecificationDTO
    {
        public long language_id { get; set; }
        public long spe_attr_id { get; set; }
        public string ipAddress { get; set; }
        public string inputvalue { get; set; }
        public long user_id { get; set; }
        public long attribute_name_id { get; set; }
        public string attribute_name { get; set; }
        public string attribute_code { get; set; }
        public bool is_active { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public long specification_id { get; set; }
        public string specification_name { get; set; }
        public string specification_code { get; set; }
        public long attribute_value_id { get; set; }
          public string attribute_value { get; set; }
          public string specification_dd { get; set; }
          public string specification_attribute_list { get; set; }
          public string attribute_name_dd { get; set; }
          public string procedure_name { get; set; }
          public string apitype { get; set; }  

        public Array specification_list { get; set; }
        public Array attrname_list { get; set; }
        public Array attrname_dd { get; set; }
        public Array attrvalue_list { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Customer
{
    public class Customer_AddressDTO
    {
        public long address_id { get; set; }
        public long user_id { get; set; }
        public string customer_name { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string city { get; set; }
        public string procedure_name { get; set; }
        public string inputvalue { get; set; }
        public long pincode { get; set; }
        public string land_mark { get; set; }
        public bool default_address { get; set; }
        public long mobile { get; set; }
        public string email_id { get; set; }
        public long country_id { get; set; }
        public long language_id { get; set; }
        public long state_id { get; set; }



        //array
        public Array addresslist { get; set; }
        public Array countrylist { get; set; }
        public Array statelist { get; set; }

        //status
        public bool statusflg { get; set; }
        public bool activeflg { get; set; }
        public string messageflg { get; set; }


        //session
        public long customer_id { get; set; }
        public string username { get; set; }
        public long userid { get; set; }
        public long roleid { get; set; }
        public string rolename { get; set; }

    }
}

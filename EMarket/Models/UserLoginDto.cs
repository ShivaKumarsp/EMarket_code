using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Models
{
    public class UserLoginDto
    {
        public string UserName { get; set; }
      public string method_details { get; set; }
        public string Check { get; set; }
        public string Password { get; set; }
        public string status { get; set; }
        public string role { get; set; }
        public long roleid { get; set; }
        public long log_id { get; set; }
      

        public string audit_details { get; set; }
      public string apitype { get; set; }

        public long userid { get; set; }
        public long customer_vendor_id { get; set; }
        public long vendor_id { get; set; }
     
        public string rolename { get; set; }
        public long forget_pwd_otp { get; set; }
        public long reg_otp { get; set; }
        public string msg_flg { get; set; }
        public string message { get; set; }
        public long user_available { get; set; }
        public string email_return { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string mobile { get; set; }
        public string salt { get; set; }
        public string salt_token { get; set; }
        public string Pwd { get; set; }
        public string ipAddress { get; set; }
        public string procedure_name { get; set; }
        public string session_cart { get; set; }
        public Array loginsuccesslist { get; set; }
       
     

    }
}

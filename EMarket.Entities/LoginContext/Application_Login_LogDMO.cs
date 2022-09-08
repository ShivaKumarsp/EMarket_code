using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMarket.Entities.LoginContext
{
    [Table("application_login_log", Schema = "public")]
    public class Application_Login_LogDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long log_id { get; set; }
        public long user_id { get; set; }
        public DateTime login_datetime { get; set; }
        public string device_details { get; set; }
        public string ip_address { get; set; }
        public string login_status { get; set; }
        public DateTime? log_out_time { get; set; }
        public string guid { get; set; }
        public string session { get; set; }
    }
}

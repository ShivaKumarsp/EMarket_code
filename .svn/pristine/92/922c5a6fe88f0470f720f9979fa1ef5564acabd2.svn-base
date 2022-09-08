using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EMarket.Entities.LoginContext
{
    [Table("application_user", Schema = "public")]
    public class Application_UserDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long user_id { get; set; }
        public long role_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string passwordhash { get; set; }
        public DateTime? lockoutdate { get; set; }
        public bool? lockoutenabled { get; set; }
        public long? accessfailedcount { get; set; }
        public DateTime? createde_on { get; set; }
        public DateTime? updated_on { get; set; }
    }
}

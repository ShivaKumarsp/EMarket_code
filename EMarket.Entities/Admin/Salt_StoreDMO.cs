using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Admin
{
    [Table("salt_store", Schema = "public")]
    public class Salt_StoreDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string salt { get; set; }
        public string token { get; set; }
        public DateTime? create_on { get; set; }
        public DateTime? exp_date { get; set; }
    }
}

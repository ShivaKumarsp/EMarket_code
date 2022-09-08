using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Master
{
    [Table("Master_State", Schema = "public")]
    public class Master_StateDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long state_id { get; set; }
        public string state_name { get; set; }
        public long language_id { get; set; }
        public long country_id { get; set; }
        public bool activeflg { get; set; }


    }
}

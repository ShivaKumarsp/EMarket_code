using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Master
{
    [Table("master_country", Schema = "public")]
    public class Master_CountryDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long country_id { get; set; }
        public string country_name { get; set; }
        public bool activeflg { get; set; }
        public DateTime? createdon { get; set; }
        public long? createdby { get; set; }
        public DateTime? updatedon { get; set; }
        public long? updatedby { get; set; }
        public long? language_id { get; set; }


    }
}

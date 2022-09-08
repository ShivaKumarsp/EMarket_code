using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Master
{
    [Table("master_city", Schema = "public")]
    public class Master_CityDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long city_id { get; set; }
        public string city_name { get; set; }
        public DateTime created_on { get; set; }
        public DateTime? updated_on { get; set; }
        public long country_id { get; set; }
        public long state_id { get; set; }
        public bool activeflg { get; set; }
    }
}

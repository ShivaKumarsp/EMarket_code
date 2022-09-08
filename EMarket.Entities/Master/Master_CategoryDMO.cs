using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Master
{
    [Table("master_category", Schema = "public")]
    public class Master_CategoryDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long mc_id { get; set; }
        public string category_name { get; set; }
        public string description { get; set; }
        public string image_url { get; set; }
        public bool is_active { get; set; }
        public string category_code { get; set; }
        public long language_id { get; set; }
    }
}

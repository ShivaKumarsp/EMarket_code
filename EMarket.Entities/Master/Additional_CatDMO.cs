using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMarket.Entities.Master
{
    [Table("master_additional_category", Schema = "public")]
    public class Additional_CatDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long additional_cat_id { get; set; }
        public long msc_id { get; set; }
        public string additional_cat_name { get; set; }
        public string additional_cat_code { get; set; }       
        public long language_id { get; set; }
        public string image_url { get; set; }
        public long? insert_by { get; set; }
        public DateTime? insert_on { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_on { get; set; }

    }
}

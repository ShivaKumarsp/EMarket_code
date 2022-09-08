using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Master
{
    [Table("master_subcategory", Schema = "public")]
    public class Master_SubCategoryDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long msc_id { get; set; }
        public long mc_id { get; set; }
        public string msc_name { get; set; }
        public string msc_description { get; set; }
        public bool msc_activeflg { get; set; }
        public string msc_imageurl { get; set; }
        public long language_id { get; set; }
        public DateTime? insert_on { get; set; }
        public long? insert_by { get; set; }
        public DateTime? update_on { get; set; }
        public long? update_by { get; set; }
    }
}

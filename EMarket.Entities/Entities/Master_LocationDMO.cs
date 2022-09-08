using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Entities
{
    [Table("master_location", Schema ="public")]
    public class Master_LocationDMO
    {
        [Key]
        public int ml_id { get; set; }
        public string ml_location { get; set; }
        public string ml_locationdescription { get; set; }
        public string ml_locationfacilities { get; set; }
       
        public DateTime createddate { get; set; }
        public long ml_createdby { get; set; }
        public DateTime updateddate { get; set; }
        public long ml_updatedby { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Models
{
    public class Master_LocationDTO
    {
        public long ml_id { get; set; }
        public string ml_location { get; set; }
        public string ml_locationdescription { get; set; }
        public string ml_locationfacilities { get; set; }
        public bool ml_activeflg { get; set; }
        public DateTime createddate { get; set; }
        public long ml_createdby { get; set; }
        public DateTime updateddate { get; set; }
        public long ml_updatedby { get; set; }
    }
}

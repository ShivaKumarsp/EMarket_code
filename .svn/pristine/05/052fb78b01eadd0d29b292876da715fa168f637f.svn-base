using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMarket.Entities.Delivery
{
    [Table("delivery_executive_vehicle_details", Schema = "public")]
    public class Delivery_Executive_Vehicle_DetailsDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long executive_vehicle_id { get; set; }
        public long executive_id { get; set; }
        public long vehicle_type_id { get; set; }
        public string vehicle_reg_number { get; set; }
        public string vehicle_details { get; set; }
   
 
    }
}

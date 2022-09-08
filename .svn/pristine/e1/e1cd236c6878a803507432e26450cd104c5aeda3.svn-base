using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EMarket.Entities.Admin
{
    [Table("hub_route", Schema = "public")]
    public class Hub_RouteDMO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long hub_route_id { get; set; }
        public long source_hub_id { get; set; }
        public long destination_hub_id { get; set; }
        public long transport_id { get; set; }
        public double distance { get; set; }
        public double travel_time_hour { get; set; }
        public double travel_time_minute { get; set; }
        public DateTime created_on { get; set; }
        public DateTime? updated_on { get; set; }
        public TimeSpan? departure_time { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EMarketDTO.Admin
{
    public class VendortohubDTO
    {
        public long language_id { get; set; }
        public long userid { get; set; }
        public string ipAddress { get; set; }
        public string apitype { get; set; }
        public string sourcelist { get; set; }
        public string destinationlist { get; set; }
        public long order_item_id { get; set; }
        public int flag { get; set; }

    }
}

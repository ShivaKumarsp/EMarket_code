using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Master
{
    public interface IMasterFacilitation
    {
        // Master Facilitation
        MasterFacilitationDTO get_data(MasterFacilitationDTO dto);
        MasterFacilitationDTO get_state(MasterFacilitationDTO dto);
        MasterFacilitationDTO get_city(MasterFacilitationDTO dto);
        MasterFacilitationDTO get_pincode(MasterFacilitationDTO dto);
        MasterFacilitationDTO save_facilitation(MasterFacilitationDTO dto);

        // Map Facilitation and Pincode
        MasterFacilitationDTO get_data_fc_map(MasterFacilitationDTO dto);
        MasterFacilitationDTO get_facilitation_dd(MasterFacilitationDTO dto);
        MasterFacilitationDTO get_pincode_dd(MasterFacilitationDTO dto);
        MasterFacilitationDTO save_map_data(MasterFacilitationDTO dto);
    }
}

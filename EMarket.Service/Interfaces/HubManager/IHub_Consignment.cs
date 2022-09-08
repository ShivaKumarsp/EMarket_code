using EMarketDTO.HubManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.HubManager
{
    public interface IHub_Consignment
    {
        Hub_ConsignmentDTO get_data(Hub_ConsignmentDTO dto);
        Hub_ConsignmentDTO get_route_data(Hub_ConsignmentDTO dto);
    }
}

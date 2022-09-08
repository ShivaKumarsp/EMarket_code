using EMarketDTO.HubManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.HubManager
{
    public interface IAssign_Hub_to_Hub
    {
        Assign_Hub_to_HubDTO get_data(Assign_Hub_to_HubDTO dto);
        Assign_Hub_to_HubDTO get_route_data(Assign_Hub_to_HubDTO dto);
        Assign_Hub_to_HubDTO save_hub_to_hub(Assign_Hub_to_HubDTO dto);
        Assign_Hub_to_HubDTO hub_to_hub_print_data(Assign_Hub_to_HubDTO dto);
        Assign_Hub_to_HubDTO assign_pickup_from_pt_to_hub(Assign_Hub_to_HubDTO dto);
        Assign_Hub_to_HubDTO get_destination_hub(Assign_Hub_to_HubDTO dto);
      
    }
}

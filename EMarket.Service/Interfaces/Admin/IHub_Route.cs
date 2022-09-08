using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Admin
{
    public interface IHub_Route
    {
        Hub_RouteDTO get_data(Hub_RouteDTO dto);
        Hub_RouteDTO get_transport_type(Hub_RouteDTO dto);
        Hub_RouteDTO save_hub_route(Hub_RouteDTO dto);
        Hub_RouteDTO delete_hub_route(Hub_RouteDTO dto);
    }
}

using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Admin
{
    public interface IHub_Route_Repository
    {
        Hub_RouteDTO save_hub_route(Hub_RouteDTO dto);
        Hub_RouteDTO delete_hub_route(Hub_RouteDTO dto);
    }
}

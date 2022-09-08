using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Master
{
    public interface IMaster_Vehicle_Type_Repository
    {
        Master_Vehicle_TypeDTO save_vehicle_type(Master_Vehicle_TypeDTO dto);
    }
}

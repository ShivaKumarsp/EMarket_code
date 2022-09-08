using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Master
{
    public interface IMaster_Vehicle_Type
    {
        Master_Vehicle_TypeDTO get_data(Master_Vehicle_TypeDTO dto);
        Master_Vehicle_TypeDTO save_vehicle_type(Master_Vehicle_TypeDTO dto);
    }
}

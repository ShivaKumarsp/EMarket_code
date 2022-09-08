using EMarketDTO.Delivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Delivery
{
    public interface IReceive_Hub_To_Hub
    {
        Receive_Hub_To_HubDTO get_data(Receive_Hub_To_HubDTO dto);
        Receive_Hub_To_HubDTO get_batch_data_details(Receive_Hub_To_HubDTO dto);
        Receive_Hub_To_HubDTO update_pickup_delivery(Receive_Hub_To_HubDTO dto);
        Receive_Hub_To_HubDTO update_drop_delivery(Receive_Hub_To_HubDTO dto);
        Receive_Hub_To_HubDTO get_delivery_batch_data_details(Receive_Hub_To_HubDTO dto);
    }
}

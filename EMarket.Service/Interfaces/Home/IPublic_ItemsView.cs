using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Home
{
   public interface IPublic_ItemsView
    {
        ItemViewDTO getdata(ItemViewDTO dto);
        ItemViewDTO show_items(ItemViewDTO dto);
        ItemViewDTO get_data_addcat(ItemViewDTO dto);
    }
}

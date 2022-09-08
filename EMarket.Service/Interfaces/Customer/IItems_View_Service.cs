using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Customer
{
    public interface IItems_View_Service
    {
        ItemViewDTO getdata(ItemViewDTO dto);
        ItemViewDTO show_items(ItemViewDTO dto);
        ItemViewDTO get_data_addcat(ItemViewDTO dto);
        ItemViewDTO get_filter_items(ItemViewDTO dto);
    }
}

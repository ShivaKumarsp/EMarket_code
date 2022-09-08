using EMarketDTO.Vendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Vendor
{
    public interface IVendor_All_Order_List
    {
        Vendor_All_Order_ListDTO get_all_order (Vendor_All_Order_ListDTO dto);
        Vendor_All_Order_ListDTO update_order(Vendor_All_Order_ListDTO dto);
        Vendor_All_Order_ListDTO get_item_lbh(Vendor_All_Order_ListDTO dto);
     
    }
}

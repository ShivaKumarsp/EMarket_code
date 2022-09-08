using EMarketDTO.Vendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Vendor
{
   public interface IAll_Item_Repository
    {
    

        // edit items
        All_ItemDTO get_edit_data(All_ItemDTO dto);
        All_ItemDTO saveproductitem(All_ItemDTO dto);
        All_ItemDTO get_specific_edit_data(All_ItemDTO dto);
        All_ItemDTO update_attribute(All_ItemDTO dto);
        All_ItemDTO get_product_details(All_ItemDTO dto);
    }
}

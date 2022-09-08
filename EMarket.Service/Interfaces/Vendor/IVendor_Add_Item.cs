using EMarketDTO.Admin;
using EMarketDTO.Vendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Vendor
{
    public interface IVendor_Add_Item
    {
        Vendor_Add_ItemDTO getdata(Vendor_Add_ItemDTO dto);
        Vendor_Add_ItemDTO get_item_product_details(Vendor_Add_ItemDTO dto);
        Vendor_Add_ItemDTO saveproductitem(Vendor_Add_ItemDTO dto);
        Vendor_Add_ItemDTO get_specification_data(Vendor_Add_ItemDTO dto);
        Vendor_Add_ItemDTO save_itemspecification(Vendor_Add_ItemDTO dto);
        Vendor_Add_ItemDTO get_specific_edit_data(Vendor_Add_ItemDTO dto);
        Vendor_Add_ItemDTO get_sku(Vendor_Add_ItemDTO dto);
        Vendor_Add_ItemDTO generate_itemcode(Vendor_Add_ItemDTO dto);
        Vendor_Add_ItemDTO update_itemspecification(Vendor_Add_ItemDTO dto);
        Vendor_Add_ItemDTO get_product_details(Vendor_Add_ItemDTO dto);

        itemfeaturesDTO getdata_feature(itemfeaturesDTO dto);
        itemfeaturesDTO save_itemfeatures(itemfeaturesDTO dto);
        Vendor_Add_ItemDTO save_multiple_images(Vendor_Add_ItemDTO dto);
    }
}

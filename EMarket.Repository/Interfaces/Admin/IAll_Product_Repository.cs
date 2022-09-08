using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Admin
{
    public interface IAll_Product_Repository
    {
        All_ProductDTO Update_Product(All_ProductDTO dto);

        All_ProductDTO update_attribute(All_ProductDTO dto);

        All_ProductDTO saveproductspecification(All_ProductDTO dto);
        All_ProductDTO deletemasterproductspecification(All_ProductDTO dto);
    }
}

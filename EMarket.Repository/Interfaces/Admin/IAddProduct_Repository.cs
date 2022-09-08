using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Admin
{
    public interface IAddProduct_Repository
    {
        Master_ProductDTO Save_Product(Master_ProductDTO dto);
        Master_ProductDTO saveproductspecification(Master_ProductDTO dto);
        Master_ProductDTO deletemasterproductspecification(Master_ProductDTO dto);
    }
}

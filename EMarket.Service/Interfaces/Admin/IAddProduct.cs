using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Admin
{
    public interface IAddProduct
    {
        Master_ProductDTO get_data(Master_ProductDTO dto);
        Master_ProductDTO get_sub_category(Master_ProductDTO dto);
        Master_ProductDTO get_spl_category(Master_ProductDTO dto);

        Master_ProductDTO Save_Product(Master_ProductDTO dto);


        //Product Question Set For vendor
        Master_ProductDTO get_questionsetdata(Master_ProductDTO dto);
        Master_ProductDTO getproductattributelist(Master_ProductDTO dto);
        Master_ProductDTO edit_getproductattributelist(Master_ProductDTO dto);
        Master_ProductDTO saveproductspecification(Master_ProductDTO dto);
        Master_ProductDTO deletemasterproductspecification(Master_ProductDTO dto);
    }
}

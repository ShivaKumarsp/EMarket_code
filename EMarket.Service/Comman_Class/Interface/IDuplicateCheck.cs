using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Comman_Class.Interface
{
    public interface IDuplicateCheck
    {
        bool check_product(Master_ProductDTO dto);
        bool check_doubleclick(string methodname, long userid);
    }
}

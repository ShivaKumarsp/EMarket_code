using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Comman_Data.Comman_Interface
{
    public interface IDuplicate_Check
    {
        bool check_product(Master_ProductDTO dto);
    }
}

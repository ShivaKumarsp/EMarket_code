using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Admin
{
    public interface IBrand
    {
        BrandDTO GetBrand(BrandDTO dto);
        BrandDTO AddBrand(BrandDTO dto);
        //BrandDTO UpdateBrand(BrandDTO dto);
    }
}

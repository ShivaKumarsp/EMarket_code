using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Admin
{
    public interface IBrand_Repository
    {
        BrandDTO GetBrand(BrandDTO dto);
        BrandDTO AddBrand(BrandDTO dto);
        //BrandDTO UpdateBrand(BrandDTO dto);
    }
}

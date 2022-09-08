using EMarket.BLL.Interfaces.Admin;
using EMarket.DLL.Interfaces.Admin;
using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.EMarket_Service.Admin
{
    public class Brand: IBrand
    {
        IBrand_Repository _inter;
        public Brand(IBrand_Repository inter)
        {
            _inter = inter;
        }
        public BrandDTO GetBrand(BrandDTO dto)
        {
            return _inter.GetBrand(dto);
        }
        public BrandDTO AddBrand(BrandDTO dto)
        {
            return _inter.AddBrand(dto);
        }
    }
}

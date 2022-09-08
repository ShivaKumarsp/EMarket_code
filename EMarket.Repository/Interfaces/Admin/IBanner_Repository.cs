using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Admin
{
   public interface IBanner_Repository
    {
        BannerDTO save_banner(BannerDTO dto);
        BannerDTO delete_banner(BannerDTO dto);
    }
}

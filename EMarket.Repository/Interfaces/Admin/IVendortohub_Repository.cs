using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Admin
{
   public interface IVendortohub_Repository
    {
        VendortohubDTO sourcehub(VendortohubDTO dto);
        VendortohubDTO destinationhub(VendortohubDTO dto);
        
    }
}

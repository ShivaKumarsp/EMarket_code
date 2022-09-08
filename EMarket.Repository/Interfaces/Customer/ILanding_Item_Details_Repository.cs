using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Customer
{
    public interface ILanding_Item_Details_Repository
    {
      
        Landing_Item_DetailsDTO add_to_cart(Landing_Item_DetailsDTO dto);
    }
}

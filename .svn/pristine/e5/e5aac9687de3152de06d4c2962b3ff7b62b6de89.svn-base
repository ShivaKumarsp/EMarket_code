using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Customer
{
   public interface ICartCheckPlaceOrder_Service
    {
        CartCheckPlaceOrderDTO get_data(CartCheckPlaceOrderDTO dto);
        CartCheckPlaceOrderDTO CheckOut_online(CartCheckPlaceOrderDTO dto);
        CartCheckPlaceOrderDTO CheckOut_POD(CartCheckPlaceOrderDTO dto);
        CartCheckPlaceOrderDTO paymentsave(CartCheckPlaceOrderDTO dto); 
        
        // Direct Checkout
        CartCheckPlaceOrderDTO Direct_CheckOut_online(CartCheckPlaceOrderDTO dto);
        CartCheckPlaceOrderDTO Direct_CheckOut_POD(CartCheckPlaceOrderDTO dto);
        CartCheckPlaceOrderDTO Direct_paymentsave(CartCheckPlaceOrderDTO dto);
        CartCheckPlaceOrderDTO check_item_available(CartCheckPlaceOrderDTO dto);
    }
}

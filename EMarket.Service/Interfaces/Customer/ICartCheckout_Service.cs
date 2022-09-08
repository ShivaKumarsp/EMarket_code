using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Customer
{
    public interface ICartCheckout_Service
    {
        CartCheckoutDTO get_data(CartCheckoutDTO dto);
        CartCheckoutDTO save_shipping_address(CartCheckoutDTO dto);
        CartCheckoutDTO change_shipping_address(CartCheckoutDTO dto);

        //Cart Payment Method

        CartCheckoutDTO get_payment_data(CartCheckoutDTO dto);
        // Direct Checkout
        CartCheckoutDTO get_data_directcart(CartCheckoutDTO dto);
        CartCheckoutDTO get_payment_data_directcart(CartCheckoutDTO dto);
        CartCheckoutDTO save_invoice_address(CartCheckoutDTO dto);
        CartCheckoutDTO get_state(CartCheckoutDTO dto);
        CartCheckoutDTO checkpincode(CartCheckoutDTO dto);
    }
}

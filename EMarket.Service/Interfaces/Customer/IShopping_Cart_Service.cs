using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Customer
{
    public interface IShopping_Cart_Service
    {
        Shopping_CartDTO get_data(Shopping_CartDTO dto);
        Shopping_CartDTO delete_item(Shopping_CartDTO dto);
        Shopping_CartDTO checkout_qty_update(Shopping_CartDTO dto);

        // Direct Checkout
        Shopping_CartDTO single_checkout(Shopping_CartDTO dto);
        Shopping_CartDTO single_checkout_qty_update(Shopping_CartDTO dto);

        // Public Checkout
        Shopping_CartDTO public_checkout(Shopping_CartDTO dto);
        Shopping_CartDTO public_checkout_qty_update(Shopping_CartDTO dto);
        Shopping_CartDTO public_delete_item(Shopping_CartDTO dto);

        // Public direct Checkout
        Shopping_CartDTO public_direct_checkout(Shopping_CartDTO dto);
        Shopping_CartDTO public_direct_checkout_qty_update(Shopping_CartDTO dto);
    }
}

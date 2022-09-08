using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Customer
{
    public interface ICustomer_Order_Track_Service
    {
        Customer_Order_TrackDTO get_data(Customer_Order_TrackDTO dto);
        Customer_Order_TrackDTO get_item_data(Customer_Order_TrackDTO dto);
        Customer_Order_TrackDTO get_order_item_details(Customer_Order_TrackDTO dto);
        Customer_Order_TrackDTO get_delivery_time(Customer_Order_TrackDTO dto);
        Customer_Order_TrackDTO order_item_cancel(Customer_Order_TrackDTO dto);
        Customer_Order_TrackDTO order_item_return(Customer_Order_TrackDTO dto);
        Customer_Order_TrackDTO save_rating_review(Customer_Order_TrackDTO dto);
        Customer_Order_TrackDTO invoice_print_data(Customer_Order_TrackDTO dto);
    }
}

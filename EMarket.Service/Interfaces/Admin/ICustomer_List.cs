using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Admin
{
  public  interface ICustomer_List
    {
        // Vendor List
        Customer_ListDTO get_data_vendor(Customer_ListDTO dto);
        Customer_ListDTO view_vendor_store(Customer_ListDTO dto);

        // Customer List
        Customer_ListDTO get_data_customer(Customer_ListDTO dto);
    }
}

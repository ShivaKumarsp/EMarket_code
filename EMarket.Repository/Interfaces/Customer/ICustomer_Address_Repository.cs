using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Customer
{
    public interface ICustomer_Address_Repository
    { 
        Customer_AddressDTO Upadate_Customer_Address(Customer_AddressDTO dto);
   
    }
}

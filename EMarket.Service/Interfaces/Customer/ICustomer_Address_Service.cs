using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Customer
{
    public interface ICustomer_Address_Service
    {
        Customer_AddressDTO Get_Customer_Address(Customer_AddressDTO dto);
        Customer_AddressDTO Upadate_Customer_Address(Customer_AddressDTO dto);
        Customer_AddressDTO get_address(Customer_AddressDTO dto);
        Customer_AddressDTO getstate(Customer_AddressDTO dto);
    }
}

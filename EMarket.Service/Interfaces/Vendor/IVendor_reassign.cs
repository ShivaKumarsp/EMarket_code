using EMarketDTO.Vendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Vendor
{
    public interface IVendor_reassign
    {
        Vendor_reassignDTO get(Vendor_reassignDTO dto);
        Vendor_reassignDTO getitem(Vendor_reassignDTO dto);
        Vendor_reassignDTO reassigning(Vendor_reassignDTO dto);
    }
}

using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Admin
{
    public interface IVerify_vendor_Profile
    {
        Verify_vendor_profileDTO Getdata(Verify_vendor_profileDTO dto);
        Verify_vendor_profileDTO VerifyProfile(Verify_vendor_profileDTO dto);
    }
}

using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Admin
{
    public interface IItem_Verification_Repository
    {
        Item_VerificationDTO Upadate_Status(Item_VerificationDTO dto);
    }
}

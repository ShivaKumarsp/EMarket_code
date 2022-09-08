using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Admin
{
    public interface IItem_Verification
    {
        //get item
        Item_VerificationDTO Get_Item(Item_VerificationDTO dto);
        //reviw item
        Item_VerificationDTO Get_Reviewitem(Item_VerificationDTO dto);
        //update review status
        Item_VerificationDTO Upadate_Status(Item_VerificationDTO dto);

        // item list
        Item_VerificationDTO get_all_Item(Item_VerificationDTO dto);
    }
}

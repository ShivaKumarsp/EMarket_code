using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Admin
{
    public interface IReturnOrderVerify
    {
        ReturnOrderVerifyDTO get_data(ReturnOrderVerifyDTO dto);
        ReturnOrderVerifyDTO update_order(ReturnOrderVerifyDTO dto);
    }
}

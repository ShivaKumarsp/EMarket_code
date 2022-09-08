using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Customer
{
    public interface Isearch_result_service
    {
        Search_resultDTO getresult(Search_resultDTO dto);
    }
}

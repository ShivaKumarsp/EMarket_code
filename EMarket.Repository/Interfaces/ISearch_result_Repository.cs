using EMarketDTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Customer
{
   public interface Isearch_result_Repository
    {
        Search_resultDTO getresult(Search_resultDTO dto);
    }
}

using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Master
{
    public interface Imasterdocument
    {
        masterdocumentDTO getdata(masterdocumentDTO dto);
        masterdocumentDTO save(masterdocumentDTO dto);
    }
}

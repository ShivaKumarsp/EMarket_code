﻿using EMarketDTO.HubManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces
{
    public interface Ihubtofacilitationcenter
    {
        hubtofacilitationcenterDTO Get(hubtofacilitationcenterDTO dto);
        hubtofacilitationcenterDTO schedulesave(hubtofacilitationcenterDTO dto);
        hubtofacilitationcenterDTO Save_batch(hubtofacilitationcenterDTO dto);
        hubtofacilitationcenterDTO save_batch_consignment(hubtofacilitationcenterDTO dto);
        hubtofacilitationcenterDTO Save(hubtofacilitationcenterDTO dto);
        hubtofacilitationcenterDTO update_batch_consignment(hubtofacilitationcenterDTO dto);
        hubtofacilitationcenterDTO update_pbatch_consignment(hubtofacilitationcenterDTO dto);
    }
}

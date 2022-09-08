using EMarketDTO.Facilitation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Facilitation
{
   public interface IAssign_Consignment
    {
        Assign_ConsignmentDTO get_data(Assign_ConsignmentDTO dto);
        Assign_ConsignmentDTO assign_consignment(Assign_ConsignmentDTO dto);
        Assign_ConsignmentDTO change_order_by(Assign_ConsignmentDTO dto);
        Assign_ConsignmentDTO get_storewise_consignment_data(Assign_ConsignmentDTO dto);
    }
}

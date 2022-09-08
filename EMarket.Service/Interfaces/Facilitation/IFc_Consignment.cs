using EMarketDTO.Facilitation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Facilitation
{
    public interface IFc_Consignment
    {
        Fc_ConsignmentDTO get_data(Fc_ConsignmentDTO dto);

        //FC to CS
        Fc_ConsignmentDTO get_data_fc_cs(Fc_ConsignmentDTO dto);
        Fc_ConsignmentDTO assign_delivery_to_customer(Fc_ConsignmentDTO dto);
        Fc_ConsignmentDTO fc_cs_change_order_by(Fc_ConsignmentDTO dto);

        // FC to HUB
        Fc_ConsignmentDTO get_data_fc_hub(Fc_ConsignmentDTO dto);
        Fc_ConsignmentDTO assign_fc_to_hub(Fc_ConsignmentDTO dto);
        Fc_ConsignmentDTO accept_from_de(Fc_ConsignmentDTO dto);
        Fc_ConsignmentDTO accept_data_from_hub(Fc_ConsignmentDTO dto);


    }
}

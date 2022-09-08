using EMarketDTO.Vendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Vendor
{
   public interface IConsignment
    {
        ConsignmentDTO get_data(ConsignmentDTO dto);
        ConsignmentDTO save_consignment(ConsignmentDTO dto);
        ConsignmentDTO consignment_print_data(ConsignmentDTO dto);
        ConsignmentDTO consignment_print_update(ConsignmentDTO dto);
        ConsignmentDTO consignment_get_edit_data(ConsignmentDTO dto);

        // handover
        ConsignmentDTO get_data_handover(ConsignmentDTO dto);
        ConsignmentDTO ready_to_handover(ConsignmentDTO dto);
        ConsignmentDTO handover_list(ConsignmentDTO dto);
        //mukta
        ConsignmentDTO invoice_print_update(ConsignmentDTO dto);
    }
}

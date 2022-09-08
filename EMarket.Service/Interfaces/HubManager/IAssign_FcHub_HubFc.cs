using EMarketDTO.HubManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.HubManager
{
    public interface IAssign_FcHub_HubFc
    {
        Assign_FcHub_HubDTO get_data(Assign_FcHub_HubDTO dto);
        Assign_FcHub_HubDTO save_fchub_hubfc(Assign_FcHub_HubDTO dto);
        Assign_FcHub_HubDTO hub_get_data(Assign_FcHub_HubDTO dto);
        Assign_FcHub_HubDTO accept_from_fc(Assign_FcHub_HubDTO dto);
        Assign_FcHub_HubDTO facilitation_wise_data(Assign_FcHub_HubDTO dto);
        Assign_FcHub_HubDTO get_accept_pt_to_hub_data(Assign_FcHub_HubDTO dto);
        Assign_FcHub_HubDTO accept_from_pt_to_hub(Assign_FcHub_HubDTO dto);
        Assign_FcHub_HubDTO accept_all_data_from_pt_to_hub(Assign_FcHub_HubDTO dto);
    }
}

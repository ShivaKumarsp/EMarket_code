using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Admin
{
    public interface IUser_Creation_Repository
    {
        UserCreationDTO save_vehicle_data(UserCreationDTO dto);
        UserCreationDTO change_password(UserCreationDTO dto);
    }
}

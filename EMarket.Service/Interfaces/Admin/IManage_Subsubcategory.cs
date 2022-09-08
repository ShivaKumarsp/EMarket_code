using EMarketDTO.Vendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Admin
{
   public interface IManage_Subsubcategory
    {
        Manage_SubsubcategoryDTO getdata(Manage_SubsubcategoryDTO dto);
        Manage_SubsubcategoryDTO get_add_category(Manage_SubsubcategoryDTO dto);
        Manage_SubsubcategoryDTO savemanagesubcat(Manage_SubsubcategoryDTO dto);
        Manage_SubsubcategoryDTO deletemanagesubcat(Manage_SubsubcategoryDTO dto);
        Manage_SubsubcategoryDTO savemastercategory(Manage_SubsubcategoryDTO dto);
    }
}

using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Admin
{
    public interface IItem_Specification_Mapping
    {
        Item_Specification_MappingDTO getdata(Item_Specification_MappingDTO dto);
        Item_Specification_MappingDTO saveitemspecification(Item_Specification_MappingDTO dto);
        Item_Specification_MappingDTO deleteitemspecification(Item_Specification_MappingDTO dto);
        Item_Specification_MappingDTO getattributelist(Item_Specification_MappingDTO dto);
        Item_Specification_MappingDTO getspecification(Item_Specification_MappingDTO dto);
        Item_Specification_MappingDTO getattribute_edit_list(Item_Specification_MappingDTO dto);
    }
}

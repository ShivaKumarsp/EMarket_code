using EMarketDTO.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Admin
{
  public  interface IItem_Specification_Mapping_Repository
    {
       
        Item_Specification_MappingDTO saveitemspecification(Item_Specification_MappingDTO dto);
        Item_Specification_MappingDTO deleteitemspecification(Item_Specification_MappingDTO dto);
       
    }
}

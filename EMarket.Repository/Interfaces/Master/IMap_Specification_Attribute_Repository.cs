using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Master
{
    public interface IMap_Specification_Attribute_Repository
    {
        Master_SpecificationDTO save_data(Master_SpecificationDTO dto);
        Master_SpecificationDTO delete_spec_attribute(Master_SpecificationDTO dto);
    }
}

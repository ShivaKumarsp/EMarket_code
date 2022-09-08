using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Master
{
   public interface IMaster_Specification
    {
        // Specification
        Master_SpecificationDTO get_data_specification(Master_SpecificationDTO dto);
        Master_SpecificationDTO save_specification(Master_SpecificationDTO dto);


        // Atribute name
        Master_SpecificationDTO get_data_attrname(Master_SpecificationDTO dto);
        Master_SpecificationDTO save_attrname(Master_SpecificationDTO dto);

        // Atribute value
        Master_SpecificationDTO get_data_attrvalue(Master_SpecificationDTO dto);
        Master_SpecificationDTO save_attrvalue(Master_SpecificationDTO dto);
        Master_SpecificationDTO delete_specidfication(Master_SpecificationDTO dto);
    }
}

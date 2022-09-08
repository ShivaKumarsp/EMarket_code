using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.BLL.Interfaces.Master
{
   public interface IMaster_Category
    {
        // Category
        Master_CategoryDTO get_data_cat(Master_CategoryDTO dto);
        Master_CategoryDTO save_cat(Master_CategoryDTO dto);
        Master_CategoryDTO delete_cat(Master_CategoryDTO dto);

        // Sub Category
        Master_CategoryDTO get_data_subcat(Master_CategoryDTO dto);
        Master_CategoryDTO save_subcat(Master_CategoryDTO dto);
        Master_CategoryDTO delete_subcat(Master_CategoryDTO dto);


    }
}

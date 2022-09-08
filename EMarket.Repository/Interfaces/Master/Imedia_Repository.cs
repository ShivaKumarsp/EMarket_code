using EMarketDTO.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.DLL.Interfaces.Master
{
    public interface Imedia_Repository
    {
        mediaDTO view(mediaDTO dto);
        mediaDTO save_media(mediaDTO dto);
        mediaDTO Delete(mediaDTO dto);
        mediaDTO get_media(mediaDTO dto);
        mediaDTO get_allmedia(mediaDTO dto);
    }
}

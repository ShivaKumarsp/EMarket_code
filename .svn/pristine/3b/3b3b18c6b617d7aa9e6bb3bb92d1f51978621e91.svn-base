using EMarket.BLL.Interfaces.Home;
using EMarketDTO.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Home
{
    [Route("api/[controller]")]
    [ApiController]
    public class Public_ItemsViewController : ControllerBase
    {
        IPublic_ItemsView _inter;
       
        public Public_ItemsViewController(IPublic_ItemsView inter)
        {
            _inter = inter;
          
        }


        [Route("getdata")]
        public ItemViewDTO getdata( [FromBody] ItemViewDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.getdata(dto);
        }

        [Route("show_items")]
        public ItemViewDTO show_items( [FromBody] ItemViewDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.show_items(dto);
        }

        [Route("get_data_addcat")]
        public ItemViewDTO get_data_addcat( [FromBody] ItemViewDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_data_addcat(dto);
        }




    }
}


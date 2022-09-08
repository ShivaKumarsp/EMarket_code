using EMarket.BLL.EMarket_Service.Delivery;
using EMarket.BLL.Interfaces.Delivery;
using EMarketDTO.Delivery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Delivery
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Send_Hub_to_HubController : ControllerBase
    {
        ISend_Hub_to_Hub _inter;
        public Send_Hub_to_HubController(ISend_Hub_to_Hub inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public Send_Hub_to_HubDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Send_Hub_to_HubDTO dto = new Send_Hub_to_HubDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }
        
        [Route("get_batch_data_details")]
        public Send_Hub_to_HubDTO get_batch_data_details([FromHeader(Name = "userid")] string userid, [FromBody] Send_Hub_to_HubDTO dto)
        {          
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_batch_data_details(dto);
        }
         [Route("update_pickup_delivery")]
        public Send_Hub_to_HubDTO update_pickup_delivery([FromHeader(Name = "userid")] string userid, [FromBody] Send_Hub_to_HubDTO dto)
        {          
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_pickup_delivery(dto);
        }
         [Route("update_drop_delivery")]
        public Send_Hub_to_HubDTO update_drop_delivery([FromHeader(Name = "userid")] string userid, [FromBody] Send_Hub_to_HubDTO dto)
        {          
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_drop_delivery(dto);
        }


    }
}

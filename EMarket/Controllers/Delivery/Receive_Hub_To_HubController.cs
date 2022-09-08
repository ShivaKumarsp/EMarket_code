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
    public class Receive_Hub_To_HubController : ControllerBase
    {
        IReceive_Hub_To_Hub _inter;
        public Receive_Hub_To_HubController(IReceive_Hub_To_Hub inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public Receive_Hub_To_HubDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Receive_Hub_To_HubDTO dto = new Receive_Hub_To_HubDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }

        [Route("get_batch_data_details")]
        public Receive_Hub_To_HubDTO get_batch_data_details([FromHeader(Name = "userid")] string userid, [FromBody] Receive_Hub_To_HubDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_batch_data_details(dto);
        }
        [Route("update_pickup_delivery")]
        public Receive_Hub_To_HubDTO update_pickup_delivery([FromHeader(Name = "userid")] string userid, [FromBody] Receive_Hub_To_HubDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_pickup_delivery(dto);
        }
        [Route("update_drop_delivery")]
        public Receive_Hub_To_HubDTO update_drop_delivery([FromHeader(Name = "userid")] string userid, [FromBody] Receive_Hub_To_HubDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_drop_delivery(dto);
        }
        [Route("get_delivery_batch_data_details")]
        public Receive_Hub_To_HubDTO get_delivery_batch_data_details([FromHeader(Name = "userid")] string userid, [FromBody] Receive_Hub_To_HubDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_delivery_batch_data_details(dto);
        }


    }
}



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
    public class Hub_To_Fc_DeliveryController : ControllerBase
    {
         IHub_To_Fc_Delivery _inter;
        public Hub_To_Fc_DeliveryController(IHub_To_Fc_Delivery inter)
        {
            _inter = inter;
        }

        [Route("get_data/{id:int}")]
        public Hub_To_Fc_DeliveryDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Hub_To_Fc_DeliveryDTO dto = new Hub_To_Fc_DeliveryDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }

        [Route("accept_hub_to_fc")]
        public Hub_To_Fc_DeliveryDTO accept_hub_to_fc([FromHeader(Name = "userid")] string userid, [FromBody] Hub_To_Fc_DeliveryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.accept_hub_to_fc(dto);
        }
        
        [Route("reject_hub_to_fc")]
        public Hub_To_Fc_DeliveryDTO reject_hub_to_fc([FromHeader(Name = "userid")] string userid, [FromBody] Hub_To_Fc_DeliveryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.reject_hub_to_fc(dto);
        }
        [Route("pickup_hub_to_fc")]
        public Hub_To_Fc_DeliveryDTO pickup_hub_to_fc([FromHeader(Name = "userid")] string userid, [FromBody] Hub_To_Fc_DeliveryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.pickup_hub_to_fc(dto);
        }

        [Route("deliver_from_hub_to_fc")]
        public Hub_To_Fc_DeliveryDTO deliver_from_hub_to_fc([FromHeader(Name = "userid")] string userid, [FromBody] Hub_To_Fc_DeliveryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.deliver_from_hub_to_fc(dto);
        }
    }
}

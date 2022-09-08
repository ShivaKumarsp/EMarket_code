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
    public class Fc_To_Hub_DeliveryController : ControllerBase
    {
        IFc_To_Hub_Delivery _inter;
        public Fc_To_Hub_DeliveryController(IFc_To_Hub_Delivery inter)
        {
            _inter = inter;
        }

        [Route("get_data/{id:int}")]
        public Fc_To_Hub_DeliveryDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Fc_To_Hub_DeliveryDTO dto = new Fc_To_Hub_DeliveryDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }

        [Route("accept_fc_to_hub")]
        public Fc_To_Hub_DeliveryDTO accept_fc_to_hub([FromHeader(Name = "userid")] string userid, [FromBody] Fc_To_Hub_DeliveryDTO dto)
        {           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.accept_fc_to_hub(dto);
        }
        
        [Route("reject_fc_to_hub")]
        public Fc_To_Hub_DeliveryDTO reject_fc_to_hub([FromHeader(Name = "userid")] string userid, [FromBody] Fc_To_Hub_DeliveryDTO dto)
        {           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.reject_fc_to_hub(dto);
        }
         [Route("pickup_fc_to_hub")]
        public Fc_To_Hub_DeliveryDTO pickup_fc_to_hub([FromHeader(Name = "userid")] string userid, [FromBody] Fc_To_Hub_DeliveryDTO dto)
        {           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.pickup_fc_to_hub(dto);
        }
        
        [Route("deliver_from_fc_to_hub")]
        public Fc_To_Hub_DeliveryDTO deliver_from_fc_to_hub([FromHeader(Name = "userid")] string userid, [FromBody] Fc_To_Hub_DeliveryDTO dto)
        {           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.deliver_from_fc_to_hub(dto);
        }

         

      

    }
}

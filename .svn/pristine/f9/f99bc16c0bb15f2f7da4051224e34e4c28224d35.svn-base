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
    public class Accept_DeliveryController : ControllerBase
    {
        IAccept_Delivery _inter;
        public Accept_DeliveryController(IAccept_Delivery inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public Accept_DeliveryDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Accept_DeliveryDTO dto = new Accept_DeliveryDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }
        [Route("update_accept_delivery")]
        public Accept_DeliveryDTO update_accept_delivery([FromHeader(Name = "userid")] string userid, [FromBody] Accept_DeliveryDTO dto)
        {
          dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_accept_delivery(dto);
        }

        [Route("update_accept_delivery_store")]
        public Accept_DeliveryDTO update_accept_delivery_store([FromHeader(Name = "userid")] string userid, [FromBody] Accept_DeliveryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_accept_delivery_store(dto);
        }
        
        [Route("update_reject_delivery")]
        public Accept_DeliveryDTO update_reject_delivery([FromHeader(Name = "userid")] string userid, [FromBody] Accept_DeliveryDTO dto)
        {
          dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_reject_delivery(dto);
        }

        [Route("pickup_from_vendor")]
        public Accept_DeliveryDTO pickup_from_vendor([FromHeader(Name = "userid")] string userid, [FromBody] Accept_DeliveryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.pickup_from_vendor(dto);
        }

    }
}

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
    public class Delivery_to_CustomerController : ControllerBase
    {
        IDelivery_to_Customer _inter;
        public Delivery_to_CustomerController(IDelivery_to_Customer inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public Delivery_to_CustomerDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Delivery_to_CustomerDTO dto = new Delivery_to_CustomerDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }
        [Route("update_accept_delivery")]
        public Delivery_to_CustomerDTO update_accept_delivery([FromHeader(Name = "userid")] string userid, [FromBody] Delivery_to_CustomerDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_accept_delivery(dto);
        }
        [Route("deliver_item")]
        public Delivery_to_CustomerDTO deliver_item([FromHeader(Name = "userid")] string userid, [FromBody] Delivery_to_CustomerDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.deliver_item(dto);
        }
        
        [Route("update_reject_delivery")]
        public Delivery_to_CustomerDTO update_reject_delivery([FromHeader(Name = "userid")] string userid, [FromBody] Delivery_to_CustomerDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_reject_delivery(dto);
        }
        
        [Route("update_pickup_delivery")]
        public Delivery_to_CustomerDTO update_pickup_delivery([FromHeader(Name = "userid")] string userid, [FromBody] Delivery_to_CustomerDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_pickup_delivery(dto);
        } 
        
        [Route("get_collect_amount")]
        public Delivery_to_CustomerDTO get_collect_amount([FromHeader(Name = "userid")] string userid, [FromBody] Delivery_to_CustomerDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_collect_amount(dto);
        }
        
        [Route("collect_amount")]
        public Delivery_to_CustomerDTO collect_amount([FromHeader(Name = "userid")] string userid, [FromBody] Delivery_to_CustomerDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.collect_amount(dto);
        }
        [Route("update_received_otp")]
        public Delivery_to_CustomerDTO update_received_otp([FromHeader(Name = "userid")] string userid, [FromBody] Delivery_to_CustomerDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_received_otp(dto);
        }


    }
}

using EMarket.BLL.Interfaces.Vendor;
using EMarketDTO.Vendar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Vendor
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CancelOrderRequestController : ControllerBase
    {
        ICancelOrderRequest _inter;
        public CancelOrderRequestController(ICancelOrderRequest inter)
        {
            _inter = inter;
        }
        [HttpGet("get_data/{id:int}")]
       
        public CancelOrderRequestDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            CancelOrderRequestDTO dto = new CancelOrderRequestDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }
        [Route("update_order")]
        public CancelOrderRequestDTO update_order([FromHeader(Name = "userid")] string userid, [FromBody] CancelOrderRequestDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_order(dto);
        }

        // Return
        [HttpGet("get_data_return/{id:int}")]

        public CancelOrderRequestDTO get_data_return([FromHeader(Name = "userid")] string userid, int id)
        {
            CancelOrderRequestDTO dto = new CancelOrderRequestDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_return(dto);
        }
        [Route("update_order_return")]
        public CancelOrderRequestDTO update_order_return([FromHeader(Name = "userid")] string userid, [FromBody] CancelOrderRequestDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_order_return(dto);
        }

    }
}

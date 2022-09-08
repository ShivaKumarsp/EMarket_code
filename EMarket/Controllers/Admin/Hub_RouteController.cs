using EMarket.BLL.Interfaces.Admin;
using EMarketDTO.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Hub_RouteController : ControllerBase
    {
        IHub_Route _inter;
        public Hub_RouteController(IHub_Route inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public Hub_RouteDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Hub_RouteDTO dto = new Hub_RouteDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }
        
        [Route("get_transport_type")]
        public Hub_RouteDTO get_transport_type([FromHeader(Name = "userid")] string userid, [FromBody] Hub_RouteDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_transport_type(dto);
        }
         
        [Route("save_hub_route")]
        public Hub_RouteDTO save_hub_route([FromHeader(Name = "userid")] string userid, [FromBody] Hub_RouteDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_hub_route(dto);
        }
        [Route("delete_hub_route")]
        public Hub_RouteDTO delete_hub_route([FromHeader(Name = "userid")] string userid, [FromBody] Hub_RouteDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_hub_route(dto);
        }


    }
}

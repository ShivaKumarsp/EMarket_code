using EMarket.BLL.Interfaces.HubManager;
using EMarketDTO.HubManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.HubManager
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Hub_ConsignmentController : ControllerBase
    {
        IHub_Consignment _inter;

        public Hub_ConsignmentController(IHub_Consignment inter)
        {
            _inter = inter;
        }

        [Route("get_data/{id:int}")]
        public Hub_ConsignmentDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Hub_ConsignmentDTO dto = new Hub_ConsignmentDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        } 
        
        [Route("get_route_data")]
        public Hub_ConsignmentDTO get_route_data([FromHeader(Name = "userid")] string userid, [FromBody] Hub_ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);           
            return _inter.get_route_data(dto);
        }


    }
}

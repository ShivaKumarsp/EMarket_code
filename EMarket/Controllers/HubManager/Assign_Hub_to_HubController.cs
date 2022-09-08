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
    public class Assign_Hub_to_HubController : ControllerBase
    {
        IAssign_Hub_to_Hub _inter;
        public Assign_Hub_to_HubController(IAssign_Hub_to_Hub inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public Assign_Hub_to_HubDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Assign_Hub_to_HubDTO dto = new Assign_Hub_to_HubDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }
        
        [Route("get_route_data")]
        public Assign_Hub_to_HubDTO get_route_data([FromHeader(Name = "userid")] string userid, [FromBody] Assign_Hub_to_HubDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
           return _inter.get_route_data(dto);
        }
         [Route("save_hub_to_hub")]
        public Assign_Hub_to_HubDTO save_hub_to_hub([FromHeader(Name = "userid")] string userid, [FromBody] Assign_Hub_to_HubDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
           return _inter.save_hub_to_hub(dto);
        }
        [Route("hub_to_hub_print_data")]
        public Assign_Hub_to_HubDTO hub_to_hub_print_data([FromHeader(Name = "userid")] string userid, [FromBody] Assign_Hub_to_HubDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
           return _inter.hub_to_hub_print_data(dto);
        }
        [Route("assign_pickup_from_pt_to_hub")]
        public Assign_Hub_to_HubDTO assign_pickup_from_pt_to_hub([FromHeader(Name = "userid")] string userid, [FromBody] Assign_Hub_to_HubDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
           return _inter.assign_pickup_from_pt_to_hub(dto);
        }
        [Route("get_destination_hub")]
        public Assign_Hub_to_HubDTO get_destination_hub([FromHeader(Name = "userid")] string userid, [FromBody] Assign_Hub_to_HubDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
           return _inter.get_destination_hub(dto);
        }
        

    }
}

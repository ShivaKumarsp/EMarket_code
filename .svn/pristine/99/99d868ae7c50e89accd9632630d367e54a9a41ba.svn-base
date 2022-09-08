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
    public class Assign_FcHub_HubFcController : ControllerBase
    {
        IAssign_FcHub_HubFc _inter;
        public Assign_FcHub_HubFcController(IAssign_FcHub_HubFc inter)
        {
            _inter = inter;
        }

        [Route("get_data/{id:int}")]
        public Assign_FcHub_HubDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Assign_FcHub_HubDTO dto = new Assign_FcHub_HubDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }
         [Route("save_fchub_hubfc")]
        public Assign_FcHub_HubDTO save_fchub_hubfc([FromHeader(Name = "userid")] string userid,[FromBody]  Assign_FcHub_HubDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
           return _inter.save_fchub_hubfc(dto);
        }

        [Route("hub_get_data/{id:int}")]
        public Assign_FcHub_HubDTO hub_get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Assign_FcHub_HubDTO dto = new Assign_FcHub_HubDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            dto.language_id = id;
            return _inter.hub_get_data(dto);
        }
        [Route("accept_from_fc")]
        public Assign_FcHub_HubDTO accept_from_fc([FromHeader(Name = "userid")] string userid, [FromBody] Assign_FcHub_HubDTO dto)
        {
           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
           return _inter.accept_from_fc(dto);
        }
        [Route("facilitation_wise_data")]
        public Assign_FcHub_HubDTO facilitation_wise_data([FromHeader(Name = "userid")] string userid, [FromBody] Assign_FcHub_HubDTO dto)
        {
           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
           return _inter.facilitation_wise_data(dto);
        }
         [Route("get_accept_pt_to_hub_data")]
        public Assign_FcHub_HubDTO get_accept_pt_to_hub_data([FromHeader(Name = "userid")] string userid, [FromBody] Assign_FcHub_HubDTO dto)
        {           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
           return _inter.get_accept_pt_to_hub_data(dto);
        }

        [Route("accept_from_pt_to_hub")]
        public Assign_FcHub_HubDTO accept_from_pt_to_hub([FromHeader(Name = "userid")] string userid, [FromBody] Assign_FcHub_HubDTO dto)
        {           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
           return _inter.accept_from_pt_to_hub(dto);
        }

    }
}

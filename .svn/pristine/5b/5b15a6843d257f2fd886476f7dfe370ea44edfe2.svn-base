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
    public class UserCreationController : ControllerBase
    {
        IUserCreation _inter;
        public UserCreationController(IUserCreation inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public UserCreationDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            UserCreationDTO dto = new UserCreationDTO();
            dto.language_id = 1;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }

        [Route("get_state")]
        public UserCreationDTO get_state([FromHeader(Name = "userid")] string userid, [FromBody] UserCreationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_state(dto);
        }

        [Route("create_user")]
        public UserCreationDTO create_user([FromHeader(Name = "userid")] string userid, [FromBody] UserCreationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.create_user(dto);
        }

        [Route("create_hub_manager_user")]
        public UserCreationDTO create_hub_manager_user([FromHeader(Name = "userid")] string userid, [FromBody] UserCreationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.create_hub_manager_user(dto);
        }

        [Route("get_edit_data")]
        public UserCreationDTO get_edit_data([FromHeader(Name = "userid")] string userid, [FromBody] UserCreationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_edit_data(dto);
        }
        [Route("get_facilitation")]
        public UserCreationDTO get_facilitation([FromHeader(Name = "userid")] string userid, [FromBody] UserCreationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_facilitation(dto);
        }
        [Route("create_facilitation")]
        public UserCreationDTO create_facilitation([FromHeader(Name = "userid")] string userid, [FromBody] UserCreationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.create_facilitation(dto);
        }
        [Route("get_de_data/{id:int}")]
        public UserCreationDTO get_de_data([FromHeader(Name = "userid")] string userid, int id)
        {
            UserCreationDTO dto = new UserCreationDTO();
            dto.language_id = 1;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_de_data(dto);
        }



        // create vehicle

        [Route("get_vehicle_data/{id:int}")]
        public UserCreationDTO get_vehicle_data([FromHeader(Name = "userid")] string userid, int id)
        {
            UserCreationDTO dto = new UserCreationDTO();
            dto.language_id = 1;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_vehicle_data(dto);
        }
        [Route("save_vehicle_data")]
        public UserCreationDTO save_vehicle_data([FromHeader(Name = "userid")] string userid, [FromBody] UserCreationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_vehicle_data(dto);
        }

        [Route("get_hub")]
        public UserCreationDTO get_hub([FromHeader(Name = "userid")] string userid, [FromBody] UserCreationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_hub(dto);
        }
        [Route("change_password")]
        public UserCreationDTO change_password([FromHeader(Name = "userid")] string userid, [FromBody] UserCreationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.change_password(dto);
        }

    }
}

using EMarket.BLL.Interfaces.Master;
using EMarketDTO.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Manage_PincodeController : ControllerBase
    {
        IManage_Pincode _inter;
        public Manage_PincodeController(IManage_Pincode inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public Manage_PincodeDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Manage_PincodeDTO dto = new Manage_PincodeDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }
        
        [Route("get_state")]
        public Manage_PincodeDTO get_state([FromHeader(Name = "userid")] string userid, [FromBody] Manage_PincodeDTO dto)
        {           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_state(dto);
        }

        [Route("get_city")]
        public Manage_PincodeDTO get_city([FromHeader(Name = "userid")] string userid, [FromBody] Manage_PincodeDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_city(dto);
        }

        [Route("save_pincode")]
        public Manage_PincodeDTO save_pincode([FromHeader(Name = "userid")] string userid, [FromBody] Manage_PincodeDTO dto)
        {           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_pincode(dto);
        }
         [Route("delete_pincode")]
        public Manage_PincodeDTO delete_pincode([FromHeader(Name = "userid")] string userid, [FromBody] Manage_PincodeDTO dto)
        {           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_pincode(dto);
        }


    }
}

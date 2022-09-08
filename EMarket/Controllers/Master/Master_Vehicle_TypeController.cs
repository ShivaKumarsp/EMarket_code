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
    public class Master_Vehicle_TypeController : ControllerBase
    {
        IMaster_Vehicle_Type _inter;
        public Master_Vehicle_TypeController(IMaster_Vehicle_Type inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public Master_Vehicle_TypeDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Master_Vehicle_TypeDTO dto = new Master_Vehicle_TypeDTO();
            dto.language_id = 1;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }

         [Route("save_vehicle_type")]
        public Master_Vehicle_TypeDTO save_vehicle_type([FromHeader(Name = "userid")] string userid, [FromBody] Master_Vehicle_TypeDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_vehicle_type(dto);
        }

    }
}

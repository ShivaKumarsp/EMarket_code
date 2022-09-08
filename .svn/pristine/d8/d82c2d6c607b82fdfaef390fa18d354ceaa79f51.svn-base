using EMarket.BLL.Interfaces.Master;
using EMarketDTO.Master;
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
    public class Master_TransportController : ControllerBase
    {
        IMaster_Transport _inter;
        public Master_TransportController(IMaster_Transport inter)
        {
            _inter = inter;
        }

        [Route("get_data/{id:int}")]
        public Master_TransportDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Master_TransportDTO dto = new Master_TransportDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }
         [Route("save_transport")]
        public Master_TransportDTO save_transport([FromHeader(Name = "userid")] string userid, [FromBody] Master_TransportDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_transport(dto);
        }
         
        [Route("delete_transport")]
        public Master_TransportDTO delete_transport([FromHeader(Name = "userid")] string userid, [FromBody] Master_TransportDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_transport(dto);
        }
         


    }
}

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
    public class Master_SpecificationController : ControllerBase
    {
        IMaster_Specification _inter;
        public Master_SpecificationController(IMaster_Specification inter)
        {
            _inter = inter;
        }

        // Specification
        [HttpGet("get_data_specification/{id:int}")]
        [Authorize]
        public Master_SpecificationDTO get_data_specification([FromHeader(Name = "userid")] string userid, int id)
        {
            Master_SpecificationDTO dto = new Master_SpecificationDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_specification(dto);
        }

        [HttpPost("save_specification")]
        [Authorize]
        public Master_SpecificationDTO save_specification([FromHeader(Name = "userid")] string userid, Master_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_specification(dto);
        }

        // Atribute name
        [HttpGet("get_data_attrname/{id:int}")]
        [Authorize]
        public Master_SpecificationDTO get_data_attrname([FromHeader(Name = "userid")] string userid, int id)
        {
            Master_SpecificationDTO dto = new Master_SpecificationDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_attrname(dto);
        }

        [HttpPost("save_attrname")]
        [Authorize]
        public Master_SpecificationDTO save_attrname([FromHeader(Name = "userid")] string userid, Master_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_attrname(dto);
        }

        // attribute value

        // Atribute name
        [HttpGet("get_data_attrvalue/{id:int}")]
        [Authorize]
        public Master_SpecificationDTO get_data_attrvalue([FromHeader(Name = "userid")] string userid, int id)
        {
            Master_SpecificationDTO dto = new Master_SpecificationDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_attrvalue(dto);
        }

        [HttpPost("save_attrvalue")]
        [Authorize]
        public Master_SpecificationDTO save_attrvalue([FromHeader(Name = "userid")] string userid, Master_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_attrvalue(dto);
        }
        [HttpPost("delete_specidfication")]
        [Authorize]
        public Master_SpecificationDTO delete_specidfication([FromHeader(Name = "userid")] string userid, Master_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_specidfication(dto);
        }



    }
}

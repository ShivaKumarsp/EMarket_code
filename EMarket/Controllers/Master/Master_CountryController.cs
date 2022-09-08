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
    public class Master_CountryController : ControllerBase
    {
        IMaster_Country _inter;
        public Master_CountryController(IMaster_Country inter)
        {
            _inter = inter;
        }
        // Country
        [Route("get_data_country/{id:int}")]
        public Master_CountryDTO get_data_country([FromHeader(Name = "userid")] string userid, int id)
        {
            Master_CountryDTO dto = new Master_CountryDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_country(dto);
        }
        [Route("save_country")]
        public Master_CountryDTO save_country([FromHeader(Name = "userid")] string userid, [FromBody] Master_CountryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_country(dto);
        }
         [Route("delete_country")]
        public Master_CountryDTO delete_country([FromHeader(Name = "userid")] string userid, [FromBody] Master_CountryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_country(dto);
        }

         // State
        [Route("get_data_state/{id:int}")]
        public Master_CountryDTO get_data_state([FromHeader(Name = "userid")] string userid, int id)
        {
            Master_CountryDTO dto = new Master_CountryDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_state(dto);
        }
        [Route("save_state")]
        public Master_CountryDTO save_state([FromHeader(Name = "userid")] string userid, [FromBody] Master_CountryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_state(dto);
        }
         [Route("delete_state")]
        public Master_CountryDTO delete_state([FromHeader(Name = "userid")] string userid, [FromBody] Master_CountryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_state(dto);
        }
         // city
        [Route("get_data_city/{id:int}")]
        public Master_CountryDTO get_data_city([FromHeader(Name = "userid")] string userid, int id)
        {
            Master_CountryDTO dto = new Master_CountryDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_city(dto);
        }
        [Route("get_state")]
        public Master_CountryDTO get_state([FromHeader(Name = "userid")] string userid, [FromBody] Master_CountryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_state(dto);
        }
        [Route("save_city")]
        public Master_CountryDTO save_city([FromHeader(Name = "userid")] string userid, [FromBody] Master_CountryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_city(dto);
        }
         [Route("delete_city")]
        public Master_CountryDTO delete_city([FromHeader(Name = "userid")] string userid, [FromBody] Master_CountryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_city(dto);
        }

    }
}

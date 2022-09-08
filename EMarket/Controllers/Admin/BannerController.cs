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
    public class BannerController : ControllerBase
    {
        IBanner _inter;
        public BannerController(IBanner inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public BannerDTO get_data ([FromHeader(Name = "userid")] string userid, int id)
        {
            BannerDTO dto = new BannerDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }

        [Route("save_banner")]
        public BannerDTO save_banner([FromHeader(Name = "userid")] string userid, [FromBody] BannerDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_banner(dto);
        }
        [Route("delete_banner")]
        public BannerDTO delete_banner([FromHeader(Name = "userid")] string userid, [FromBody] BannerDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_banner(dto);
        }


    }
}

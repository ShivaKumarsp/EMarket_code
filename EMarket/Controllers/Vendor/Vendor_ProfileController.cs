using EMarket.BLL.Interfaces.Vendor;

using EMarketDTO.Vendar;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Vendor
{
    [Route("api/[controller]")]
    [ApiController]
    public class Vendor_ProfileController : ControllerBase
    {
        IVendor_Profile _inter;
        private readonly IAntiforgery _antiforgery;
        public Vendor_ProfileController(IVendor_Profile inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }

        [HttpGet("getdata/{id:int}")]
        [Authorize]
        public Vendor_ProfileDTO getdata([FromHeader(Name = "userid")] string userid, int id)
        {
            Vendor_ProfileDTO dto = new Vendor_ProfileDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.getdata(dto);
        }
        
        [HttpPost("UpdateProfile")]
        [Authorize]
        public Vendor_ProfileDTO UpdateProfile([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_ProfileDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);

            return _inter.UpdateProfile(dto);
        }
        [HttpPost("getstate")]
        [Authorize]
        public Vendor_ProfileDTO getstate([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_ProfileDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);

            return _inter.getstate(dto);
        }

    }
}

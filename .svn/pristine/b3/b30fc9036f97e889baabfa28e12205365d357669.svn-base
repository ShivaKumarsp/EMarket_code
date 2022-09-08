using EMarket.BLL.Interfaces.Admin;
using EMarketDTO.Admin;
using Microsoft.AspNetCore.Antiforgery;
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
    public class verify_vendor_profileController : ControllerBase
    {
        IVerify_vendor_Profile _inter;
        private readonly IAntiforgery _antiforgery;
        public verify_vendor_profileController(IVerify_vendor_Profile inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }

        [HttpGet("Getdata/{id:int}")]
        [Authorize]
        public Verify_vendor_profileDTO Getdata([FromHeader(Name = "userid")] string userid, int id)
        {
            Verify_vendor_profileDTO dto = new Verify_vendor_profileDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.Getdata(dto);
        }

        [HttpPost("VerifyProfile")]
        [Authorize]
        public Verify_vendor_profileDTO VerifyProfile([FromHeader(Name = "userid")] string userid, [FromBody] Verify_vendor_profileDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);

            return _inter.VerifyProfile(dto);
        }
    }
}

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
    public class Vendor_ReassignController : ControllerBase
    {
        IVendor_reassign _inter;
        private readonly IAntiforgery _antiforgery;
        public Vendor_ReassignController(IVendor_reassign inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }
        //get
        [HttpGet("get/{id:int}")]
        [Authorize]
        public Vendor_reassignDTO get([FromHeader(Name = "userid")] string userid, int id)
        {

            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            Vendor_reassignDTO dto = new Vendor_reassignDTO();
            //dto.language_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.get(dto);
        }
        [HttpPost("getitem")]
        [Authorize]
        public Vendor_reassignDTO getitem([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_reassignDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.getitem(dto);
        }
        [HttpPost("reassigning")]
        [Authorize]
        public Vendor_reassignDTO reassigning([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_reassignDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.reassigning(dto);
        }
    }
}
 
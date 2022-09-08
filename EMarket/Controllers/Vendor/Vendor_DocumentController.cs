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
    [Authorize]
    public class Vendor_DocumentController : ControllerBase
    {
        IVendor_Document _inter;
        private readonly IAntiforgery _antiforgery;
        public Vendor_DocumentController(IVendor_Document inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }

        [HttpGet("getdata/{id:int}")]
        [Authorize]
        public Vendor_DocumentDTO getdata([FromHeader(Name = "userid")] string userid, int id)
        {

            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            Vendor_DocumentDTO dto = new Vendor_DocumentDTO();
            dto.language_id = id;
            dto.test = 100;
            dto.userid = Convert.ToInt64(userid);
            return _inter.getdata(dto);
        }
        [HttpPost]
        [HttpPost("save_vendor_documents")]
        [AllowAnonymous]
        public Vendor_DocumentDTO save_vendor_documents([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_DocumentDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.save_vendor_documents(dto);
        }
        //[HttpPost]
        //[HttpPost("update_vendor_documents")]
        //[AllowAnonymous]
        //public Vendor_DocumentDTO update_vendor_documents([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_DocumentDTO dto)
        //{
        //    dto.userid = Convert.ToInt64(userid);
        //    return _inter.update_vendor_documents(dto);
        //}
    }
}

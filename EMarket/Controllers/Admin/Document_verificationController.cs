using EMarket.BLL.EMarket_Service.Admin;
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
    public class Document_verificationController : ControllerBase
    {
        IDocument_verification _inter;
        private readonly IAntiforgery _antiforgery;
        public Document_verificationController(IDocument_verification inter,IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }
        [HttpGet("getdocuments/{id:int}")]
        public Document_verificationDTO getdocuments([FromHeader(Name = "userid")] string userid, int id)
        {

            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            Document_verificationDTO dto = new Document_verificationDTO();
            dto.language_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.getdocuments(dto);
        }
        //saving after verification
        [HttpPost("save_documents")]
        [AllowAnonymous]
        public Document_verificationDTO save_documents([FromHeader(Name = "userid")] string userid, [FromBody] Document_verificationDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.save_documents(dto);
        }




    }
}

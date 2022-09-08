using EMarket.BLL.Interfaces.Master;
using EMarketDTO.Master;
using Microsoft.AspNetCore.Antiforgery;
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
    public class masterdocumentController : ControllerBase
    {
        Imasterdocument _inter;
        private readonly IAntiforgery _antiforgery;
        public masterdocumentController(Imasterdocument inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }
        //get
        [HttpGet("getdata/{id:int}")]
        [Authorize]
        public masterdocumentDTO getdata([FromHeader(Name = "userid")] string userid, int id)
        {

            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            masterdocumentDTO dto = new masterdocumentDTO();
            dto.language_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.getdata(dto);
        }
        //save
        [HttpPost("save")]
        [Authorize]
        public masterdocumentDTO save([FromHeader(Name = "userid")] string userid, [FromBody] masterdocumentDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.save(dto);
        }



    }
}

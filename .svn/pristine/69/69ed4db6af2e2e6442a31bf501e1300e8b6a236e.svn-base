using EMarket.BLL.Interfaces.Customer;
using EMarketDTO.Customer;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class search_resultController : ControllerBase
    {
        Isearch_result_service _inter;
        private readonly IAntiforgery _antiforgery;
        public search_resultController(Isearch_result_service inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }
        //get
        //[HttpGet("getresult/{id}")]
        //public Search_resultDTO getresult([FromHeader(Name = "userid")] string userid,int id)
        //{

        //    //CSR token
        //    var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
        //    HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
        //    new CookieOptions() { HttpOnly = false });
        //    Search_resultDTO dto = new Search_resultDTO();
        //    dto.language_id = id;
        //    dto.userid = Convert.ToInt64(userid);
        //    return _inter.getresult(dto);
        //}

        [HttpPost("getresult")]
        [AllowAnonymous]
        public Search_resultDTO getresult([FromHeader(Name = "userid")] string userid, [FromBody] Search_resultDTO dto)
        {
            //dto.userid = Convert.ToInt64(userid);
            return _inter.getresult(dto);
        }

    }
}

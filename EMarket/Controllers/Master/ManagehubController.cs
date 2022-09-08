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

namespace EMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagehubController : ControllerBase
    {
        IManagehub _inter;
        private readonly IAntiforgery _antiforgery;
        public ManagehubController(IManagehub inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }
        //get
        [HttpGet("get/{id:int}")]
        [Authorize]
        public ManagehubDTO get([FromHeader(Name = "userid")] string userid, int id)
        {

            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            ManagehubDTO dto = new ManagehubDTO();
            dto.language_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.get(dto);
        }
        //get get_servicablePincodes
        [HttpGet("get_servicablePincodes/{id:int}")]
        [Authorize]
         public ManagehubDTO get_servicablePincodes([FromHeader(Name = "userid")] string userid, int id)
        {

            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            ManagehubDTO dto = new ManagehubDTO();
            dto.hub_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_servicablePincodes(dto);
        }

        //get_state
        [HttpPost("get_state")]
        [Authorize]
        public ManagehubDTO get_state([FromHeader(Name = "userid")] string userid, [FromBody] ManagehubDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_state(dto);
        }
        //get_city
        [HttpPost("get_city")]
        [Authorize]
        public ManagehubDTO get_city([FromHeader(Name = "userid")] string userid, [FromBody] ManagehubDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_city(dto);
        }
        //get_pincode
        [HttpPost("get_pincode")]
        [Authorize]
        public ManagehubDTO get_pincode([FromHeader(Name = "userid")] string userid, [FromBody] ManagehubDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_pincode(dto);
        }
        //save_hub
        [HttpPost("save_hub")]
        [Authorize]
        public ManagehubDTO save_hub([FromHeader(Name = "userid")] string userid, [FromBody] ManagehubDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.save_hub(dto);
        }
        //save_
        [HttpPost("save_servicablepin")]
        [Authorize]
        public ManagehubDTO save_servicablepin([FromHeader(Name = "userid")] string userid, [FromBody] ManagehubDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.save_servicablepin(dto);
        }
        //delete
        [HttpPost("delete")]
        [Authorize]
        public ManagehubDTO delete([FromHeader(Name = "userid")] string userid, [FromBody] ManagehubDTO dto)
        {

            dto.userid = Convert.ToInt64(userid);
            return _inter.delete(dto);
        }


    }
}

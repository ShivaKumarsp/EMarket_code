using EMarket.BLL.EMarket_Service.Master;
using EMarketDTO.Master;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMarket.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]

    public class mediaController : ControllerBase
    {
        Imedia _inter;
        private readonly IAntiforgery _antiforgery;
        public mediaController(Imedia inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }
       
        // GET api/<mediaController>/5
        [HttpGet("view/{id}")]
        public mediaDTO view([FromHeader(Name = "userid")] string userid, int id)
        {
            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            mediaDTO dto = new mediaDTO();
            dto.media_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.view(dto);

        }

        //get_media
        [HttpGet("get_media/{id}")]
        public mediaDTO get_media([FromHeader(Name = "userid")] string userid, int id)
        {
            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            mediaDTO dto = new mediaDTO();
            dto.media_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_media(dto);

        }
        [HttpGet("get_allmedia/{id}")]
        public mediaDTO get_allmedia([FromHeader(Name = "userid")] string userid, int id)
        {
            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            mediaDTO dto = new mediaDTO();
            dto.media_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_allmedia(dto);

        }
        //save
        [HttpPost("save_media")]
        [AllowAnonymous]
        public mediaDTO save_media([FromHeader(Name = "userid")] string userid, [FromBody] mediaDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.save_media(dto);
        }
        //update
        // PUT api/<mediaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<mediaController>/5
        [HttpPost("Delete/{id}")]
        public mediaDTO Delete([FromHeader(Name = "userid")] string userid,int id)
        {
            mediaDTO dto = new mediaDTO();
            dto.media_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.Delete(dto);
        }
    }
}

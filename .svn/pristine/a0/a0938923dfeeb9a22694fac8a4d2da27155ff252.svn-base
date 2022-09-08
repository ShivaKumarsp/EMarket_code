using EMarket.BLL.Interfaces;
using EMarketDTO.HubManager;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace EMarket.Controllers.HubManager
{
    [Route("api/[controller]")]
    [ApiController]
    public class hubtofacilitationcenterController : ControllerBase
    {
        Ihubtofacilitationcenter _inter;
        private readonly IAntiforgery _antiforgery;
        public hubtofacilitationcenterController(Ihubtofacilitationcenter inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }
         //get
        [HttpGet("Get/{id}")]
        [Authorize]
        public hubtofacilitationcenterDTO Get([FromHeader(Name = "userid")] string userid, int id)
        {

            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            hubtofacilitationcenterDTO dto = new hubtofacilitationcenterDTO();
            dto.parent_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.Get(dto);
        }

        [HttpPost("Save")]
        [Authorize]
        public hubtofacilitationcenterDTO Save([FromHeader(Name = "userid")] string userid, [FromBody] hubtofacilitationcenterDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.Save(dto);
        }

        [HttpPost("Save_batch")]
        [Authorize]
        public hubtofacilitationcenterDTO Save_batch([FromHeader(Name = "userid")] string userid, [FromBody] hubtofacilitationcenterDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.Save_batch(dto);
        }

        [HttpPost("save_batch_consignment")]
        [Authorize]
        public hubtofacilitationcenterDTO save_batch_consignment([FromHeader(Name = "userid")] string userid, [FromBody] hubtofacilitationcenterDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.save_batch_consignment(dto);
        }

        [HttpPost("update_batch_consignment")]
        [Authorize]
        public hubtofacilitationcenterDTO update_batch_consignment([FromHeader(Name = "userid")] string userid, [FromBody] hubtofacilitationcenterDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.update_batch_consignment(dto);
        }
        [HttpPost("update_pbatch_consignment")]
        [Authorize]
        public hubtofacilitationcenterDTO update_pbatch_consignment([FromHeader(Name = "userid")] string userid, [FromBody] hubtofacilitationcenterDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.update_pbatch_consignment(dto);
        }

        [HttpPost("schedulesave")]
        [Authorize]
        public hubtofacilitationcenterDTO schedulesave([FromHeader(Name = "userid")] string userid, [FromBody] hubtofacilitationcenterDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.schedulesave(dto);
        }
        
    }
}

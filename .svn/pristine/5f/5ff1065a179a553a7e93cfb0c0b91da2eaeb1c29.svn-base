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
    public class Item_Specification_MappingController : ControllerBase
    {
        IItem_Specification_Mapping _inter;
        private readonly IAntiforgery _antiforgery;
        public Item_Specification_MappingController(IItem_Specification_Mapping inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }
        [HttpGet("getdata/{id:int}")]
        [AllowAnonymous]
        public Item_Specification_MappingDTO getdata([FromHeader(Name = "userid")] string userid, int id)
        {
            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            Item_Specification_MappingDTO dto = new Item_Specification_MappingDTO();
            dto.language_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.getdata(dto);
        }

        [Route("saveitemspecification")]

        public Item_Specification_MappingDTO saveitemspecification([FromHeader(Name = "userid")] string userid, [FromBody] Item_Specification_MappingDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.saveitemspecification(dto);
        }
        [HttpPost]
        [HttpPost("deleteitemspecification")]
        [AllowAnonymous]
        public Item_Specification_MappingDTO deleteitemspecification([FromHeader(Name = "userid")] string userid, [FromBody] Item_Specification_MappingDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.deleteitemspecification(dto);
        }
        [HttpPost]
        [HttpPost("getattributelist")]
        [AllowAnonymous]
        public Item_Specification_MappingDTO getattributelist([FromHeader(Name = "userid")] string userid, [FromBody] Item_Specification_MappingDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.getattributelist(dto);
        }

        [Route("getspecification")]
        public Item_Specification_MappingDTO getspecification([FromHeader(Name = "userid")] string userid, [FromBody] Item_Specification_MappingDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.getspecification(dto);

        }
        
        [Route("getattribute_edit_list")]
        public Item_Specification_MappingDTO getattribute_edit_list([FromHeader(Name = "userid")] string userid, [FromBody] Item_Specification_MappingDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.getattribute_edit_list(dto);
        }


    }
}

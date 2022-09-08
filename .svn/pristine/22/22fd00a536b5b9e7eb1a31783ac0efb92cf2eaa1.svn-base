
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
    public class Map_Category_SpecificationController : ControllerBase
    {
        IMap_Category_Specification _inter;
        private readonly IAntiforgery _antiforgery;
        public Map_Category_SpecificationController(IMap_Category_Specification inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }
        [HttpGet("getdata/{id:int}")]
        [AllowAnonymous]
        public Map_Category_SpecificationDTO getdata([FromHeader(Name = "userid")] string userid, int id)
        {
            Map_Category_SpecificationDTO dto = new Map_Category_SpecificationDTO();
            dto.language_id = id;
            dto.userid = Convert.ToInt32(userid);
            return _inter.getdata(dto);
        }

        [Route("savemappedspecification")]

        public Map_Category_SpecificationDTO savemappedspecification([FromHeader(Name = "userid")] string userid, [FromBody] Map_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.savemappedspecification(dto);
        }
        [Route("getspecification")]
        public Map_Category_SpecificationDTO getspecification([FromHeader(Name = "userid")] string userid, [FromBody] Map_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.getspecification(dto);

        }
        [HttpPost]
        [HttpPost("deletecatspecification")]
        [AllowAnonymous]
        public Map_Category_SpecificationDTO deletecatspecification([FromHeader(Name = "userid")] string userid, [FromBody] Map_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.deletecatspecification(dto);
        }
        [HttpGet("getspecattribute/{id:int}")]
        [AllowAnonymous]
        public Map_Category_SpecificationDTO getspecattribute([FromHeader(Name = "userid")] string userid, int id)
        {
            Map_Category_SpecificationDTO dto = new Map_Category_SpecificationDTO();
            dto.language_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.getspecattribute(dto);
        }
        [Route("getattributelist")]
        public Map_Category_SpecificationDTO getattributelist([FromHeader(Name = "userid")] string userid, [FromBody] Map_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            return _inter.getattributelist(dto);
        }
        [Route("savemappedattribuename")]

        public Map_Category_SpecificationDTO savemappedattribuename([FromHeader(Name = "userid")] string userid, [FromBody] Map_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.savemappedattribuename(dto);
        }
        [HttpPost]
        [HttpPost("deletespecattribute")]
        [AllowAnonymous]
        public Map_Category_SpecificationDTO deletespecattribute([FromHeader(Name = "userid")] string userid, [FromBody] Map_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            return _inter.deletespecattribute(dto);
        }

    }
}

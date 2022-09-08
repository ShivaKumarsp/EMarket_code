using EMarket.BLL.Interfaces.Admin;

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
    public class Manage_SubsubcategoryController : ControllerBase
    {
        IManage_Subsubcategory _inter;
        private readonly IAntiforgery _antiforgery;
        public Manage_SubsubcategoryController(IManage_Subsubcategory inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }

        [HttpGet("getdata/{id:int}")]
        [AllowAnonymous]
        public Manage_SubsubcategoryDTO getdata([FromHeader(Name = "userid")] string userid, int id)
        {
            Manage_SubsubcategoryDTO dto = new Manage_SubsubcategoryDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.getdata(dto);
        }
       
        [HttpPost("get_add_category")]
              public Manage_SubsubcategoryDTO get_add_category([FromHeader(Name = "userid")] string userid, [FromBody] Manage_SubsubcategoryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_add_category(dto);

        }

        [HttpPost]
        [HttpPost("savemanagesubcat")]
        [AllowAnonymous]
        public Manage_SubsubcategoryDTO savemanagesubcat([FromHeader(Name = "userid")] string userid, [FromBody] Manage_SubsubcategoryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.savemanagesubcat(dto);
            
        }
        [HttpPost]
        [HttpPost("deletemanagesubcat")]
        [AllowAnonymous]
        public Manage_SubsubcategoryDTO deletemanagesubcat([FromHeader(Name = "userid")] string userid, [FromBody] Manage_SubsubcategoryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.deletemanagesubcat(dto);

        }
        [HttpPost]
        [HttpPost("savemastercategory")]
        [AllowAnonymous]
        public Manage_SubsubcategoryDTO savemastercategory([FromHeader(Name = "userid")] string userid, [FromBody] Manage_SubsubcategoryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.savemastercategory(dto);

        }
    }
}

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
    public class Add_Item_SpecificationController : ControllerBase
    {
        IAdd_Item_Specification _inter;
        private readonly IAntiforgery _antiforgery;
        public Add_Item_SpecificationController(IAdd_Item_Specification inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }

        [HttpGet("getdata/{id:int}")]
        [AllowAnonymous]
        public Add_Item_SpecificationDTO getdata([FromHeader(Name = "userid")] string userid, int id)
        {
            Add_Item_SpecificationDTO dto = new Add_Item_SpecificationDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.getdata(dto);
        }
        [HttpPost]
        [HttpPost("savespecification")]
        [AllowAnonymous]
        public Add_Item_SpecificationDTO savespecification([FromHeader(Name = "userid")] string userid, [FromBody] Add_Item_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.savespecification(dto);
        }
        [HttpPost("getitemspecification")]
        [AllowAnonymous]
        public Add_Item_SpecificationDTO getitemspecification([FromHeader(Name = "userid")] string userid, [FromBody] Add_Item_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.getitemspecification(dto);
        }

        [HttpPost("editspecification")]
        [AllowAnonymous]
        public Add_Item_SpecificationDTO editspecification([FromHeader(Name = "userid")] string userid, [FromBody] Add_Item_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.editspecification(dto);
        }
    }
}

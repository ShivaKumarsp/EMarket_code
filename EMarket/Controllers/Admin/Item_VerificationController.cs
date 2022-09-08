using EMarket.BLL.Interfaces.Admin;

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
    [Authorize]
    public class Item_VerificationController : ControllerBase
    {
        IItem_Verification _inter;
        private readonly IAntiforgery _antiForgery;
        public Item_VerificationController(IItem_Verification inter, IAntiforgery antiForgery)
        {
            _inter = inter;
            _antiForgery = antiForgery;
        }
        [HttpGet]
        [Route("Get_Item/{id:int}")]
        [AllowAnonymous]
        public Item_VerificationDTO Get_Item([FromHeader(Name = "userid")] string userid, int id)
        {
          
            Item_VerificationDTO dto = new Item_VerificationDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.Get_Item(dto);
        }
        //show item deatils
        [Route("Get_Reviewitem")]
        public Item_VerificationDTO Get_Reviewitem([FromHeader(Name = "userid")] string userid, [FromBody] Item_VerificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.Get_Reviewitem(dto);
        }

        //update status
        [Route("Upadate_Status")]
        public Item_VerificationDTO Upadate_Status([FromHeader(Name = "userid")] string userid, [FromBody] Item_VerificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.Upadate_Status(dto);
        }

        // Item List
        [HttpGet]
        [Route("get_all_Item/{id:int}")]
        [AllowAnonymous]
        public Item_VerificationDTO get_all_Item([FromHeader(Name = "userid")] string userid, int id)
        {

            Item_VerificationDTO dto = new Item_VerificationDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_all_Item(dto);
        }
    }
}

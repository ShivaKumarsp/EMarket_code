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


    public class All_ItemController : ControllerBase
    {
        IAll_Item _inter;
        private readonly IAntiforgery _antiForgeryService;
        public All_ItemController(IAll_Item inter, IAntiforgery antiForgeryService)
        {
            _inter = inter;
            _antiForgeryService = antiForgeryService;
        }

        [Route("get_data/{id:int}")]
        public All_ItemDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {

            All_ItemDTO dto = new All_ItemDTO();
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.language_id = id;
            return _inter.get_data(dto);
        }


        // edit items

        [Route("get_edit_data")]
        public All_ItemDTO get_edit_data([FromHeader(Name = "userid")] string userid, [FromBody] All_ItemDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return _inter.get_edit_data(dto);
        }

        [Route("saveproductitem")]
        public All_ItemDTO saveproductitem([FromHeader(Name = "userid")] string userid, [FromBody] All_ItemDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            return _inter.saveproductitem(dto);
        }

        [Route("get_specific_edit_data")]
      
        public All_ItemDTO get_specific_edit_data([FromHeader(Name = "userid")] string userid, [FromBody] All_ItemDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            return _inter.get_specific_edit_data(dto);
        }
         [Route("update_attribute")]
        public All_ItemDTO update_attribute([FromHeader(Name = "userid")] string userid, [FromBody] All_ItemDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            return _inter.update_attribute(dto);
        }
        
         [Route("get_product_details")]
        public All_ItemDTO get_product_details([FromHeader(Name = "userid")] string userid, [FromBody] All_ItemDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            return _inter.get_product_details(dto);
        }


    }
}

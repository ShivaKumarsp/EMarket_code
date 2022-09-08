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
    [Authorize]
    public class All_ProductController : ControllerBase
    {
        IAll_Product _inter;
        private readonly IAntiforgery _antiForgeryService;
        public All_ProductController(IAll_Product inter, IAntiforgery antiForgeryService)
        {
            _inter = inter;
            _antiForgeryService = antiForgeryService;
        }

        [Route("get_data/{id:int}")]
        public All_ProductDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            All_ProductDTO dto = new All_ProductDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }
        
        //Edit Product
        [Route("get_edit_data")]
        public All_ProductDTO get_edit_data([FromHeader(Name = "userid")] string userid, [FromBody] All_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_edit_data(dto);
        }

        [Route("Update_Product")]
        public All_ProductDTO Update_Product([FromHeader(Name = "userid")] string userid, [FromBody] All_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.Update_Product(dto);
        }


        // Edit Product Specification

        [Route("get_specific_edit_data")]
        public All_ProductDTO get_specific_edit_data([FromHeader(Name = "userid")] string userid, [FromBody] All_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_specific_edit_data(dto);
        }

        
        [Route("update_attribute")]
        public All_ProductDTO update_attribute([FromHeader(Name = "userid")] string userid, [FromBody] All_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_attribute(dto);
        }

        //Product Question Set For vendor
        [Route("get_questionsetdata")]

        public All_ProductDTO get_questionsetdata([FromHeader(Name = "userid")] string userid, [FromBody] All_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_questionsetdata(dto);
        }

        [Route("getproductattributelist")]

        public All_ProductDTO getproductattributelist([FromHeader(Name = "userid")] string userid, [FromBody] All_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);

            return _inter.getproductattributelist(dto);

        }
        [Route("saveproductspecification")]

        public All_ProductDTO saveproductspecification([FromHeader(Name = "userid")] string userid, [FromBody] All_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);

            return _inter.saveproductspecification(dto);
        }

        [Route("deletemasterproductspecification")]

        public All_ProductDTO deletemasterproductspecification([FromHeader(Name = "userid")] string userid, [FromBody] All_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.deletemasterproductspecification(dto);

        }
    }
}

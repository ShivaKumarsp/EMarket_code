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
    public class AddProductController : APIBaseController
    {
        IAddProduct _inter;
        private readonly IAntiforgery _antiForgeryService;
        public AddProductController(IAddProduct inter, IAntiforgery antiForgeryService)
        {
            _inter = inter;
            _antiForgeryService = antiForgeryService;
        }

        [HttpGet("get_data/{id:int}")]
        [Authorize]
        public Master_ProductDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {


            Master_ProductDTO dto = new Master_ProductDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }

        [HttpPost("get_sub_category")]
        [Authorize]
        public Master_ProductDTO get_sub_category([FromHeader(Name = "userid")] string userid, [FromBody] Master_ProductDTO dto)
        {
           dto.ipAddress= HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_sub_category(dto);
        }


        [Route("get_spl_category")]
        public Master_ProductDTO get_spl_category([FromHeader(Name = "userid")] string userid, [FromBody] Master_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_spl_category(dto);
        }


        [Route("Save_Product")]
        public Master_ProductDTO Save_Product([FromHeader(Name = "userid")] string userid, [FromBody] Master_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.Save_Product(dto);
        }


        //Product Question Set For vendor
        [Route("get_questionsetdata")]

        public Master_ProductDTO get_questionsetdata([FromHeader(Name = "userid")] string userid, [FromBody] Master_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_questionsetdata(dto);
        }

        [Route("getproductattributelist")]

        public Master_ProductDTO getproductattributelist([FromHeader(Name = "userid")] string userid, [FromBody] Master_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.getproductattributelist(dto);

        }
        [Route("edit_getproductattributelist")]

        public Master_ProductDTO edit_getproductattributelist([FromHeader(Name = "userid")] string userid, [FromBody] Master_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.edit_getproductattributelist(dto);

        }
        [Route("saveproductspecification")]

        public Master_ProductDTO saveproductspecification([FromHeader(Name = "userid")] string userid, [FromBody] Master_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.saveproductspecification(dto);
        }

        [Route("deletemasterproductspecification")]

        public Master_ProductDTO deletemasterproductspecification([FromHeader(Name = "userid")] string userid, [FromBody] Master_ProductDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.deletemasterproductspecification(dto);

        }
    }
}

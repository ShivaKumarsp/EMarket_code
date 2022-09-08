using EMarket.BLL.Interfaces.Admin;

using EMarketDTO.Admin;
using Microsoft.AspNetCore.Antiforgery;
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
    public class Product_SpecificationController : ControllerBase
    {
        IProduct_Specification _inter;
        private readonly IAntiforgery _antiForgeryService;
        public Product_SpecificationController(IProduct_Specification inter, IAntiforgery antiForgeryService)
        {
            _inter = inter;
            _antiForgeryService = antiForgeryService;
        }

        //Product Specification
        [Route("get_specification_data")]
        public Product_SpecificationDTO get_specification_data([FromHeader(Name = "userid")] string userid, [FromBody] Product_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            dto.user_id = Convert.ToInt64(userid);         
            return _inter.get_specification_data(dto);
        }

        [Route("save_productspecification")]
        public Product_SpecificationDTO save_productspecification([FromHeader(Name = "userid")] string userid, [FromBody] Product_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            dto.user_id = Convert.ToInt64(userid);            
            return _inter.save_productspecification(dto);
        }


        [Route("getvariantdata")]
        public Product_SpecificationDTO getvariantdata([FromHeader(Name = "userid")] string userid, [FromBody] Product_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.getvariantdata(dto);
        }
          [Route("save_productvariant")]
        public Product_SpecificationDTO save_productvariant([FromHeader(Name = "userid")] string userid, [FromBody] Product_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_productvariant(dto);
        }
         [Route("delete_productvariant")]
        public Product_SpecificationDTO delete_productvariant([FromHeader(Name = "userid")] string userid, [FromBody] Product_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_productvariant(dto);
        }

    }
}

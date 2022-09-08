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
    public class product_featuresController : ControllerBase
    {
        IProduct_Features _inter;
        private readonly IAntiforgery _antiForgery;
        public product_featuresController(IProduct_Features inter, IAntiforgery antiForgery)
        {
            _inter = inter;
            _antiForgery = antiForgery;
        }

        [HttpPost]
        [Route("Get_productfeatures")]
        [AllowAnonymous]
        public product_featuresDTO Get_productfeatures([FromHeader(Name = "userid")] string userid, [FromBody] product_featuresDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.Get_productfeatures(dto);
        }

        [Route("save_productfeatures")]
        public product_featuresDTO save_productfeatures([FromHeader(Name = "userid")] string userid, [FromBody] product_featuresDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.save_productfeatures(dto);
        }


    }
}

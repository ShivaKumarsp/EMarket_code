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
    public class BrandController : ControllerBase
    {
        IBrand _inter;
        private readonly IAntiforgery _antiForgery;
        public BrandController(IBrand inter, IAntiforgery antiForgery)
        {
            _inter = inter;
            _antiForgery = antiForgery;
        }
        [HttpGet]
        [Route("GetBrand/{id:int}")]
        [AllowAnonymous]
        public BrandDTO GetBrand(int id)
        {
            BrandDTO dto = new BrandDTO();
            var tokens = _antiForgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            dto.language_id = id;
            //dto.username = Convert.ToString(HttpContext.Session.GetString("UserName"));
            //dto.user_id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            dto.roleid = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
            dto.rolename = Convert.ToString(HttpContext.Session.GetString("RoleName"));
            return _inter.GetBrand(dto);
        }

        [HttpPost]
        [Route("AddBrand")]
        [AllowAnonymous]
        public BrandDTO AddBrand([FromBody] BrandDTO dto)
        {
            
            //dto.username = Convert.ToString(HttpContext.Session.GetString("UserName"));
            //dto.userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            dto.roleid = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
            dto.rolename = Convert.ToString(HttpContext.Session.GetString("RoleName"));
            return _inter.AddBrand(dto);
        }

    }
}

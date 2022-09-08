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
    public class Master_Category_SpecificationController : ControllerBase
    {
        IMaster_Category_Specification _inter;
        private readonly IAntiforgery _antiforgery;
        public Master_Category_SpecificationController(IMaster_Category_Specification inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }
        [HttpGet("getdata/{id:int}")]
        [AllowAnonymous]
        public Master_Category_SpecificationDTO getdata([FromHeader(Name = "userid")] string userid, int id)
        {
            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            Master_Category_SpecificationDTO dto = new Master_Category_SpecificationDTO();
            dto.language_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.getdata(dto);
        }

        [Route("savemasterspecification")]
        public Master_Category_SpecificationDTO savemasterspecification([FromHeader(Name = "userid")] string userid, [FromBody] Master_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.savemasterspecification(dto);
        }
        [HttpPost]
        [HttpPost("deletemasterspecification")]
        [AllowAnonymous]
        public Master_Category_SpecificationDTO deletemasterspecification([FromHeader(Name = "userid")] string userid, [FromBody] Master_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt32(userid);
            return _inter.deletemasterspecification(dto);
        }
        [HttpPost]
        [HttpPost("getattributelist")]
        [AllowAnonymous]
        public Master_Category_SpecificationDTO getattributelist([FromHeader(Name = "userid")] string userid, [FromBody] Master_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.getattributelist(dto);
        }

        [Route("getspecification")]
        public Master_Category_SpecificationDTO getspecification([FromHeader(Name = "userid")] string userid, [FromBody] Master_Category_SpecificationDTO dto)
        {
             dto.userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
             return _inter.getspecification(dto);
        }

        [Route("editmasterspecification")]
        public Master_Category_SpecificationDTO editmasterspecification([FromHeader(Name = "userid")] string userid, [FromBody] Master_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            return _inter.editmasterspecification(dto);
        }
        [Route("getattributelist_edit")]
        public Master_Category_SpecificationDTO getattributelist_edit([FromHeader(Name = "userid")] string userid, [FromBody] Master_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.getattributelist_edit(dto);
        }

        // category variant map
        [HttpGet("getvariantdata/{id:int}")]
        [AllowAnonymous]
        public Master_Category_SpecificationDTO getvariantdata([FromHeader(Name = "userid")] string userid, int id)
        {
            //CSR token
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            Master_Category_SpecificationDTO dto = new Master_Category_SpecificationDTO();
            dto.language_id = id;
            dto.userid = Convert.ToInt64(userid);
            return _inter.getvariantdata(dto);
        }
        [Route("save_cat_variant")]
        public Master_Category_SpecificationDTO save_cat_variant([FromHeader(Name = "userid")] string userid, [FromBody] Master_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
            return _inter.save_cat_variant(dto);
        }

        [Route("get_variant_list")]
        public Master_Category_SpecificationDTO get_variant_list ([FromHeader(Name = "userid")] string userid,[FromBody]
        Master_Category_SpecificationDTO dto)
        {
            dto.userid = Convert.ToInt64(userid);
              return _inter.get_variant_list(dto);
        }
    //[Route("delete_cat_variant")]
    //public Master_Category_SpecificationDTO delete_cat_variant([FromHeader(Name = "userid")] string userid, [FromBody] Master_Category_SpecificationDTO dto)
    //{
    //    return _inter.delete_cat_variant(dto);
    //}


}
}

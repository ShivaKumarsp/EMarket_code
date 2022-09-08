using EMarket.BLL.Interfaces.Admin;
using EMarket.BLL.Interfaces.Master;
using EMarketDTO.Admin;
using EMarketDTO.Master;
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
    public class Master_CategoryController : ControllerBase
    {
        IMaster_Category _inter;
               public Master_CategoryController(IMaster_Category inter)
        {
            _inter = inter;
         
        }
        // Category
        [HttpGet("get_data_cat/{id:int}")]
     
        public Master_CategoryDTO get_data_cat([FromHeader(Name = "userid")] string userid, int id)
        {
            Master_CategoryDTO dto = new Master_CategoryDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_cat(dto);
        }
        
        [HttpPost("save_cat")]
        [Authorize]
        public Master_CategoryDTO save_cat([FromHeader(Name = "userid")] string userid, Master_CategoryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_cat(dto);
        }
         [HttpPost("delete_cat")]
        [Authorize]
        public Master_CategoryDTO delete_cat([FromHeader(Name = "userid")] string userid, Master_CategoryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_cat(dto);
        }

        // Sub Category
        [HttpGet("get_data_subcat/{id:int}")]
        [Authorize]
        public Master_CategoryDTO get_data_subcat([FromHeader(Name = "userid")] string userid, int id)
        {
            Master_CategoryDTO dto = new Master_CategoryDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_subcat(dto);
        }

        [HttpPost("save_subcat")]
        [Authorize]
        public Master_CategoryDTO save_subcat([FromHeader(Name = "userid")] string userid, Master_CategoryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_subcat(dto);
        }
        [HttpPost("delete_subcat")]
        [Authorize]
        public Master_CategoryDTO delete_subcat([FromHeader(Name = "userid")] string userid, Master_CategoryDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_subcat(dto);
        }
        

    }
}

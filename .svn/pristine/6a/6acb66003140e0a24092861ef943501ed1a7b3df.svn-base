using EMarket.BLL.Interfaces.Vendor;
using EMarketDTO.Products;
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
    public class Vendor_StoreController : ControllerBase
    {
        IVendor_Store _inter;
        public Vendor_StoreController(IVendor_Store inter)
        {
            _inter = inter;
        }
        [Route("getdata")]
        
        public Vendor_StoreDTO getdata([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_StoreDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.getdata(dto);
        }

        [Route("save_store")]
        
        public Vendor_StoreDTO save_store([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_StoreDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_store(dto);
        }
         [Route("delete_store")]
        
        public Vendor_StoreDTO delete_store([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_StoreDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_store(dto);
        }

        // Vendor Bank

        [HttpGet("get_bank_data/{id:int}")]
        [AllowAnonymous]
        public Vendor_StoreDTO get_bank_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Vendor_StoreDTO dto = new Vendor_StoreDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_bank_data(dto);
        }
         [HttpPost("save_bank_data")]
        [AllowAnonymous]
        public Vendor_StoreDTO save_bank_data([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_StoreDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_bank_data(dto);
        }
         [HttpPost("request_delete_account")]
        [AllowAnonymous]
        public Vendor_StoreDTO request_delete_account([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_StoreDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.request_delete_account(dto);
        }

    }
}

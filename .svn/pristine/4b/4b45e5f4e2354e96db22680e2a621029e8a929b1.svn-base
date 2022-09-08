using EMarket.BLL.Interfaces.Admin;
using EMarketDTO.Admin;
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
    public class Customer_ListController : ControllerBase
    {
        ICustomer_List _inter;
        public Customer_ListController(ICustomer_List inter)
        {
            _inter = inter;
        }
        // Vendor List
        [HttpGet("get_data_vendor/{id:int}")]
        public Customer_ListDTO get_data_vendor([FromHeader(Name = "userid")] string userid, int id)
        {
            Customer_ListDTO dto = new Customer_ListDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_vendor(dto);
        }
        [HttpPost("view_vendor_store")]
        public Customer_ListDTO view_vendor_store([FromHeader(Name = "userid")] string userid, [FromBody] Customer_ListDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.view_vendor_store(dto);
        }

        // Customer List
        [HttpGet("get_data_customer/{id:int}")]
        public Customer_ListDTO get_data_customer([FromHeader(Name = "userid")] string userid, int id)
        {
            Customer_ListDTO dto = new Customer_ListDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_customer(dto);
        }

    }
}

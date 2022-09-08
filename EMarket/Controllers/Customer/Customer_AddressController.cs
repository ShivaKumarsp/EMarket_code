using EMarket.BLL.Interfaces.Customer;

using EMarketDTO.Customer;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer_AddressController : ControllerBase
    {
        ICustomer_Address_Service _inter;
        private readonly IAntiforgery _antiForgery;
        public Customer_AddressController(ICustomer_Address_Service inter, IAntiforgery antiForgery)
        {
            _inter = inter;
            _antiForgery = antiForgery;
        }

        [Route("Get_Customer_Address/{id:int}")]
        public Customer_AddressDTO Get_Customer_Address(int id)
        {
            var tokens = _antiForgery.GetAndStoreTokens(HttpContext);
            HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                new CookieOptions() { HttpOnly = false });
            Customer_AddressDTO dto = new Customer_AddressDTO();
            dto.language_id = id;
            dto.username = Convert.ToString(HttpContext.Session.GetString("UserName"));
            dto.user_id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            dto.roleid = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
            dto.rolename = Convert.ToString(HttpContext.Session.GetString("RoleName"));
            return _inter.Get_Customer_Address(dto);
        }

        
        //update
        [Route("Upadate_Customer_Address")]
        public Customer_AddressDTO Upadate_Customer_Address([FromBody] Customer_AddressDTO dto)
        {
            dto.username = Convert.ToString(HttpContext.Session.GetString("UserName"));
            dto.user_id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            dto.roleid = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
            dto.rolename = Convert.ToString(HttpContext.Session.GetString("RoleName"));
            return _inter.Upadate_Customer_Address(dto);
        }
        [Route("get_address")]
        public Customer_AddressDTO get_address([FromBody] Customer_AddressDTO dto)
        {
            dto.username = Convert.ToString(HttpContext.Session.GetString("UserName"));
            dto.user_id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            dto.roleid = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
            dto.rolename = Convert.ToString(HttpContext.Session.GetString("RoleName"));
            return _inter.get_address(dto);
        }
        [Route("getstate")]
        public Customer_AddressDTO getstate([FromBody] Customer_AddressDTO dto)
        {
            dto.username = Convert.ToString(HttpContext.Session.GetString("UserName"));
            dto.userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            dto.roleid = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
            dto.rolename = Convert.ToString(HttpContext.Session.GetString("RoleName"));
            dto.customer_id = Convert.ToInt32(HttpContext.Session.GetInt32("customerid"));
            return _inter.getstate(dto);
        }


    }
}

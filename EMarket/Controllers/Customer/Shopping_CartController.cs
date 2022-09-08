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
    [Authorize]
    [AllowAnonymous]
    public class Shopping_CartController : ControllerBase
    {
        IShopping_Cart_Service _inter;
        private readonly IAntiforgery _antiForgeryService;
        public Shopping_CartController(IShopping_Cart_Service inter, IAntiforgery antiForgeryService)
        {
            _inter = inter;
            _antiForgeryService = antiForgeryService;
        }

        [Route("get_data")]
       
        public Shopping_CartDTO get_data([FromHeader(Name = "userid")] string userid, [FromBody] Shopping_CartDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_data(dto);
        }

        [Route("checkout_qty_update")]
        public Shopping_CartDTO checkout_qty_update([FromHeader(Name = "userid")] string userid, [FromBody] Shopping_CartDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.checkout_qty_update(dto);
        }

        [Route("delete_item")]
             public Shopping_CartDTO delete_item([FromHeader(Name = "userid")] string userid, [FromBody] Shopping_CartDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.delete_item(dto);
        }
        
        // Direct Checkout
        [Route("single_checkout")]
             public Shopping_CartDTO single_checkout([FromHeader(Name = "userid")] string userid, [FromBody] Shopping_CartDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.single_checkout(dto);
        }
        [Route("single_checkout_qty_update")]
             public Shopping_CartDTO single_checkout_qty_update([FromHeader(Name = "userid")] string userid, [FromBody] Shopping_CartDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.single_checkout_qty_update(dto);
        }

         // Public cart
        [Route("public_checkout")]
             public Shopping_CartDTO public_checkout([FromHeader(Name = "userid")] string userid, [FromBody] Shopping_CartDTO dto)
        {
            dto.user_id = 0;
            if(userid!="null")
            {
                dto.user_id = Convert.ToInt64(userid);
            }           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.public_checkout(dto);
        }
        [Route("public_checkout_qty_update")]
             public Shopping_CartDTO public_checkout_qty_update([FromHeader(Name = "userid")] string userid, [FromBody] Shopping_CartDTO dto)
        {
            dto.user_id = 0;
            if (userid != "null")
            {
                dto.user_id = Convert.ToInt64(userid);
            }
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.public_checkout_qty_update(dto);
        }

        [Route("public_delete_item")]
        public Shopping_CartDTO public_delete_item([FromHeader(Name = "userid")] string userid, [FromBody] Shopping_CartDTO dto)
        {
            dto.user_id = 0;
            if (userid != "null")
            {
                dto.user_id = Convert.ToInt64(userid);
            }
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.public_delete_item(dto);
        }

        // Public direct cart
        [Route("public_direct_checkout")]
             public Shopping_CartDTO public_direct_checkout([FromHeader(Name = "userid")] string userid, [FromBody] Shopping_CartDTO dto)
        {
            dto.user_id = 0;
            if(userid!="null")
            {
                dto.user_id = Convert.ToInt64(userid);
            }           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.public_direct_checkout(dto);
        }
        [Route("public_direct_checkout_qty_update")]
             public Shopping_CartDTO public_direct_checkout_qty_update([FromHeader(Name = "userid")] string userid, [FromBody] Shopping_CartDTO dto)
        {
            dto.user_id = 0;
            if (userid != "null")
            {
                dto.user_id = Convert.ToInt64(userid);
            }
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.public_direct_checkout_qty_update(dto);
        }


    }
}

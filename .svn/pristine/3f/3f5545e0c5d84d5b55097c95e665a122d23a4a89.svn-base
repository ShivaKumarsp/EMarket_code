using EMarket.BLL.Interfaces.Customer;

using EMarketDTO.Customer;
using Microsoft.AspNetCore.Antiforgery;
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
    public class CartCheckoutController : ControllerBase
    {
        ICartCheckout_Service _inter;
        private readonly IAntiforgery _antiForgeryService;
        public CartCheckoutController(ICartCheckout_Service inter, IAntiforgery antiForgeryService)
        {
            _inter = inter;
            _antiForgeryService = antiForgeryService;
        }

        [Route("get_data")]
        public CartCheckoutDTO get_data([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckoutDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return _inter.get_data(dto);
        }


        [Route("save_shipping_address")]
        public CartCheckoutDTO save_shipping_address([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckoutDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return _inter.save_shipping_address(dto);
        }
        [Route("change_shipping_address")]
        public CartCheckoutDTO change_shipping_address([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckoutDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return _inter.change_shipping_address(dto);
        }


        //Cart Payment Method

        [Route("get_payment_data")]
        public CartCheckoutDTO get_payment_data([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckoutDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return _inter.get_payment_data(dto);
        }

        // direct checkout

        [Route("get_data_directcart")]
        public CartCheckoutDTO get_data_directcart([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckoutDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return _inter.get_data_directcart(dto);
        }

        [Route("get_payment_data_directcart")]
        public CartCheckoutDTO get_payment_data_directcart([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckoutDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return _inter.get_payment_data_directcart(dto);
        }
         [Route("save_invoice_address")]
        public CartCheckoutDTO save_invoice_address([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckoutDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return _inter.save_invoice_address(dto);
        }
        [Route("get_state")]
        public CartCheckoutDTO get_state([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckoutDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return _inter.get_state(dto);
        }
        [Route("checkpincode")]
        public CartCheckoutDTO checkpincode([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckoutDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return _inter.checkpincode(dto);
        }

    }
}

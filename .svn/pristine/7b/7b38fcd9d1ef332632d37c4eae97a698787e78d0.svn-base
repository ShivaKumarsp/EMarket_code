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
    public class CartCheckPlaceOrderController : ControllerBase
    {
        ICartCheckPlaceOrder_Service _inter;
        private readonly IAntiforgery _antiForgeryService;
        public CartCheckPlaceOrderController(ICartCheckPlaceOrder_Service inter, IAntiforgery antiForgeryService)
        {
            _inter = inter;
            _antiForgeryService = antiForgeryService;
        }

        [Route("get_data/{id:int}")]
        public CartCheckPlaceOrderDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            CartCheckPlaceOrderDTO dto = new CartCheckPlaceOrderDTO();
            dto.user_id = Convert.ToInt64(userid);
            dto.language_id = id;
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_data(dto);
        }

        [Route("CheckOut_online")]
        public CartCheckPlaceOrderDTO CheckOut_online([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckPlaceOrderDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.CheckOut_online(dto);
        }
        
        [Route("CheckOut_POD")]
        public CartCheckPlaceOrderDTO CheckOut_POD([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckPlaceOrderDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.CheckOut_POD(dto);
        }
         [Route("paymentsave")]
        public CartCheckPlaceOrderDTO paymentsave([FromHeader(Name = "userid")] string userid,[FromBody] CartCheckPlaceOrderDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.paymentsave(dto);
        }

        // direct checkout

        [Route("Direct_CheckOut_online")]
        public CartCheckPlaceOrderDTO Direct_CheckOut_online([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckPlaceOrderDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.Direct_CheckOut_online(dto);
        }

        [Route("Direct_CheckOut_POD")]
        public CartCheckPlaceOrderDTO Direct_CheckOut_POD([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckPlaceOrderDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.Direct_CheckOut_POD(dto);
        }
        [Route("Direct_paymentsave")]
        public CartCheckPlaceOrderDTO Direct_paymentsave([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckPlaceOrderDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.Direct_paymentsave(dto);
        }
         [Route("check_item_available")]
        public CartCheckPlaceOrderDTO check_item_available([FromHeader(Name = "userid")] string userid, [FromBody] CartCheckPlaceOrderDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.check_item_available(dto);
        }


    }
}

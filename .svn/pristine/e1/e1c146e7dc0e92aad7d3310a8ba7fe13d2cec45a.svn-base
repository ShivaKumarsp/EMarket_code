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
    public class Customer_Order_TrackController : ControllerBase
    {

        ICustomer_Order_Track_Service _inter;
        private readonly IAntiforgery _antiForgeryService;
        public Customer_Order_TrackController(ICustomer_Order_Track_Service inter, IAntiforgery antiForgeryService)
        {
            _inter = inter;
            _antiForgeryService = antiForgeryService;
        }

        [Route("get_data/{id:int}")]
        public Customer_Order_TrackDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Customer_Order_TrackDTO dto = new Customer_Order_TrackDTO();
            dto.user_id = Convert.ToInt32(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.language_id = id;
            return _inter.get_data(dto);
        }

        [Route("get_item_data")]
        public Customer_Order_TrackDTO get_item_data([FromHeader(Name = "userid")] string userid, [FromBody] Customer_Order_TrackDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.get_item_data(dto);
        }
         [Route("get_order_item_details")]
        public Customer_Order_TrackDTO get_order_item_details([FromHeader(Name = "userid")] string userid, [FromBody] Customer_Order_TrackDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.get_order_item_details(dto);
        }

        [Route("order_item_cancel")]
        public Customer_Order_TrackDTO order_item_cancel([FromHeader(Name = "userid")] string userid, [FromBody] Customer_Order_TrackDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.order_item_cancel(dto);
        }
        [Route("order_item_return")]
        public Customer_Order_TrackDTO order_item_return([FromHeader(Name = "userid")] string userid, [FromBody] Customer_Order_TrackDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.order_item_return(dto);
        }
        [Route("save_rating_review")]
        public Customer_Order_TrackDTO save_rating_review([FromHeader(Name = "userid")] string userid, [FromBody] Customer_Order_TrackDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.save_rating_review(dto);
        }

        [Route("get_delivery_time")]
        public Customer_Order_TrackDTO get_delivery_time([FromHeader(Name = "userid")] string userid, [FromBody] Customer_Order_TrackDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.get_delivery_time(dto);
        }
        //Mukta 03-09-2022
        [Route("invoice_print_data")]
        public Customer_Order_TrackDTO invoice_print_data([FromHeader(Name = "userid")] string userid, [FromBody] Customer_Order_TrackDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.invoice_print_data(dto);
        }

    }
}

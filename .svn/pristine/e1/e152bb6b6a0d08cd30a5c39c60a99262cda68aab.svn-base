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
  
    public class Landing_Item_DetailsController : ControllerBase
    {
        ILanding_Item_Details_Service _inter;
        private readonly IAntiforgery _antiForgeryService;
        public Landing_Item_DetailsController(ILanding_Item_Details_Service inter, IAntiforgery antiForgeryService)
        {
            _inter = inter;
            _antiForgeryService = antiForgeryService;
        }

        [HttpPost("get_data")]
        public Landing_Item_DetailsDTO get_data([FromHeader(Name = "userid")] string userid, [FromBody] Landing_Item_DetailsDTO dto)
        {
            if(userid=="null")
            {
                dto.user_id = 0;
            }
            else
            {
                dto.user_id = Convert.ToInt64(userid);
            }
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_data(dto);
        } 
        
        [HttpPost("get_data_pub")]
        [AllowAnonymous]
        public Landing_Item_DetailsDTO get_data_pub( [FromBody] Landing_Item_DetailsDTO dto)
        {
            return _inter.get_data_pub(dto);
        } 
         [Route("get_specification_details")]
        public Landing_Item_DetailsDTO get_specification_details([FromHeader(Name = "userid")] string userid, [FromBody] Landing_Item_DetailsDTO dto)
        {
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_specification_details(dto);
        } 
        
        [Route("add_to_cart")]
        public Landing_Item_DetailsDTO add_to_cart([FromHeader(Name = "userid")] string userid, [FromBody] Landing_Item_DetailsDTO dto)
        {
            dto.user_id = 0;
            if (userid!= "null")
            {
                dto.session_cart = "";
                dto.user_id = Convert.ToInt64(userid);
            }
         
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.add_to_cart(dto);
        }
        
        [Route("single_checkout")]
        public Landing_Item_DetailsDTO single_checkout([FromHeader(Name = "userid")] string userid, [FromBody] Landing_Item_DetailsDTO dto)
        {
            dto.user_id = 0;
            if (userid != "null")
            {
                dto.session_cart = "";
                dto.user_id = Convert.ToInt64(userid);
            }
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.single_checkout(dto);
        } 
        [Route("single_public_checkout")]
        public Landing_Item_DetailsDTO single_public_checkout([FromHeader(Name = "userid")] string userid, [FromBody] Landing_Item_DetailsDTO dto)
        {
            dto.user_id = 0;
            if (userid != "null")
            {
                dto.session_cart = "";
                dto.user_id = Convert.ToInt64(userid);
            }
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.single_public_checkout(dto);
        }
    }
}

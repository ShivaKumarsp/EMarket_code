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
   
    public class itemsviewController : ControllerBase
    {
        IItems_View_Service _inter;
        private readonly IAntiforgery _antiForgery;
        public itemsviewController(IItems_View_Service inter, IAntiforgery antiForgery)
        {
            _inter = inter;
            _antiForgery = antiForgery;
        }


        [Route("getdata")]
        public ItemViewDTO getdata([FromHeader(Name = "userid")] string userid, [FromBody] ItemViewDTO dto)
        {
            if(userid=="null")
            {
                dto.userid = 0;
            }
            else
            {
                dto.userid = Convert.ToInt64(userid);
            }
            
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.getdata(dto);
        }

        [Route("show_items")]
        public ItemViewDTO show_items([FromHeader(Name = "userid")] string userid, [FromBody] ItemViewDTO dto)
        {
            if (userid == "null")
            {
                dto.userid = 0;
            }
            else
            {
                dto.userid = Convert.ToInt64(userid);
            }
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.show_items(dto);
        }

        [Route("get_data_addcat")]
        public ItemViewDTO get_data_addcat([FromHeader(Name = "userid")] string userid, [FromBody] ItemViewDTO dto)
        {
            if (userid == "null")
            {
                dto.userid = 0;
            }
            else
            {
                dto.userid = Convert.ToInt64(userid);
            }
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_data_addcat(dto);
        }

        [Route("get_filter_items")]
        public ItemViewDTO get_filter_items([FromHeader(Name = "userid")] string userid, [FromBody] ItemViewDTO dto)
        {
            if (userid == "null")
            {
                dto.userid = 0;
            }
            else
            {
                dto.userid = Convert.ToInt64(userid);
            }
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_filter_items(dto);
        }




    }
}

using EMarket.BLL.Interfaces.Admin;
using EMarketDTO.Admin;
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
    public class OrderWise_ReportController : ControllerBase
    {
        IOrderWise_Report _inter;
        public OrderWise_ReportController(IOrderWise_Report inter)
        {
            _inter = inter;
        }
        [HttpGet("get_data/{id:int}")]

        public OrderWise_ReportDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            OrderWise_ReportDTO dto = new OrderWise_ReportDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }

         [HttpPost("payment_details")]
        public OrderWise_ReportDTO payment_details([FromHeader(Name = "userid")] string userid, [FromBody] OrderWise_ReportDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.payment_details(dto);
        }
        
         [HttpPost("get_payment_data")]
        public OrderWise_ReportDTO get_payment_data([FromHeader(Name = "userid")] string userid, [FromBody] OrderWise_ReportDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_payment_data(dto);
        }
        
    }
}

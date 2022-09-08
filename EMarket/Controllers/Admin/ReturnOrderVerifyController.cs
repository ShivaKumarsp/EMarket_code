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
    public class ReturnOrderVerifyController : ControllerBase
    {
        IReturnOrderVerify _inter;
        public ReturnOrderVerifyController(IReturnOrderVerify inter)
        {
            _inter = inter;
        }
        [HttpGet("get_data/{id:int}")]

        public ReturnOrderVerifyDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            ReturnOrderVerifyDTO dto = new ReturnOrderVerifyDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }
        [Route("update_order")]
        public ReturnOrderVerifyDTO update_order([FromHeader(Name = "userid")] string userid, [FromBody] ReturnOrderVerifyDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_order(dto);
        }
    }
}
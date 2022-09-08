using EMarket.BLL.Interfaces.Facilitation;
using EMarketDTO.Facilitation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Facilitation
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Assign_ConsignmentController : ControllerBase
    {
        IAssign_Consignment _inter;
        public Assign_ConsignmentController(IAssign_Consignment inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public Assign_ConsignmentDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Assign_ConsignmentDTO dto = new Assign_ConsignmentDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }

        [Route("assign_consignment")]
        public Assign_ConsignmentDTO assign_consignment([FromHeader(Name = "userid")] string userid, [FromBody] Assign_ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.assign_consignment(dto);
        }

        [Route("change_order_by")]
        public Assign_ConsignmentDTO change_order_by([FromHeader(Name = "userid")] string userid, [FromBody] Assign_ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.change_order_by(dto);
        }
        [Route("get_storewise_consignment_data")]
        public Assign_ConsignmentDTO get_storewise_consignment_data([FromHeader(Name = "userid")] string userid, [FromBody] Assign_ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_storewise_consignment_data(dto);
        }


    }
}

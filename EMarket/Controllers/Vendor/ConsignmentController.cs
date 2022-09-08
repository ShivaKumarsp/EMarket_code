using EMarket.BLL.Interfaces.Vendor;
using EMarketDTO.Vendar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Vendor
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsignmentController : ControllerBase
    {
        IConsignment _inter;
        public ConsignmentController(IConsignment inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public ConsignmentDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            ConsignmentDTO dto = new ConsignmentDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }
         [Route("save_consignment")]
        public ConsignmentDTO save_consignment([FromHeader(Name = "userid")] string userid, [FromBody] ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_consignment(dto);
        }
        
        [Route("consignment_print_data")]
        public ConsignmentDTO consignment_print_data([FromHeader(Name = "userid")] string userid, [FromBody] ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.consignment_print_data(dto);
        }
        [Route("consignment_print_update")]
        public ConsignmentDTO consignment_print_update([FromHeader(Name = "userid")] string userid, [FromBody] ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.consignment_print_update(dto);
        }
         [Route("consignment_get_edit_data")]
        public ConsignmentDTO consignment_get_edit_data([FromHeader(Name = "userid")] string userid, [FromBody] ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.consignment_get_edit_data(dto);
        }

        // handover

        [Route("get_data_handover/{id:int}")]
        public ConsignmentDTO get_data_handover([FromHeader(Name = "userid")] string userid, int id)
        {
            ConsignmentDTO dto = new ConsignmentDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data_handover(dto);
        }
    
        [Route("ready_to_handover")]
        public ConsignmentDTO ready_to_handover([FromHeader(Name = "userid")] string userid, [FromBody] ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.ready_to_handover(dto);
        }
         [Route("handover_list")]
        public ConsignmentDTO handover_list([FromHeader(Name = "userid")] string userid, [FromBody] ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.handover_list(dto);
        }
        //Mukta 23-08-2022 
        [Route("invoice_print_update")]
        public ConsignmentDTO invoice_print_update([FromHeader(Name = "userid")] string userid, [FromBody] ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.invoice_print_update(dto);
        }

    }
}

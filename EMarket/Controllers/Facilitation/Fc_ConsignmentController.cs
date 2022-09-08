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
    public class Fc_ConsignmentController : ControllerBase
    {

        IFc_Consignment _inter;

        public Fc_ConsignmentController(IFc_Consignment inter)
        {
            _inter = inter;
        }

        [Route("get_data/{id:int}")]
        public Fc_ConsignmentDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Fc_ConsignmentDTO dto = new Fc_ConsignmentDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }

        // FC to CS

        [Route("get_data_fc_cs/{id:int}")]
        public Fc_ConsignmentDTO get_data_fc_cs([FromHeader(Name = "userid")] string userid, int id)
        {
            Fc_ConsignmentDTO dto = new Fc_ConsignmentDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            dto.language_id = id;
            return _inter.get_data_fc_cs(dto);
        }
        [Route("assign_delivery_to_customer")]
        public Fc_ConsignmentDTO assign_delivery_to_customer([FromHeader(Name = "userid")] string userid,[FromBody] Fc_ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);        
            return _inter.assign_delivery_to_customer(dto);
        }


        [Route("fc_cs_change_order_by")]
        public Fc_ConsignmentDTO fc_cs_change_order_by([FromHeader(Name = "userid")] string userid, [FromBody] Fc_ConsignmentDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.fc_cs_change_order_by(dto);
        }

        // FC to HUB

        [Route("get_data_fc_hub/{id:int}")]
        public Fc_ConsignmentDTO get_data_fc_hub([FromHeader(Name = "userid")] string userid, int id)
        {
            Fc_ConsignmentDTO dto = new Fc_ConsignmentDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            dto.language_id = id;
            return _inter.get_data_fc_hub(dto);
        }
        
        [Route("assign_fc_to_hub")]
        public Fc_ConsignmentDTO assign_fc_to_hub([FromHeader(Name = "userid")] string userid, [FromBody] Fc_ConsignmentDTO dto)
        {          
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);          
            return _inter.assign_fc_to_hub(dto);
        }
       [Route("accept_from_de")]
        public Fc_ConsignmentDTO accept_from_de([FromHeader(Name = "userid")] string userid, [FromBody] Fc_ConsignmentDTO dto)
        {          
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);          
            return _inter.accept_from_de(dto);
        }
        [Route("accept_data_from_hub")]
        public Fc_ConsignmentDTO accept_data_from_hub([FromHeader(Name = "userid")] string userid, [FromBody] Fc_ConsignmentDTO dto)
        {          
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);          
            return _inter.accept_data_from_hub(dto);
        }
       


    }
}

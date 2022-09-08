using EMarket.BLL.Interfaces.Master;
using EMarketDTO.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MasterFacilitationController : ControllerBase
    {
        IMasterFacilitation _inter;
        public MasterFacilitationController(IMasterFacilitation inter)
        {
            _inter = inter;
        }


        // Master Facilitation
        [Route("get_data/{id:int}")]
        public MasterFacilitationDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            MasterFacilitationDTO dto = new MasterFacilitationDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }
        
        [Route("get_state")]
        public MasterFacilitationDTO get_state([FromHeader(Name = "userid")] string userid,[FromBody] MasterFacilitationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.get_state(dto);
        }
        [Route("get_city")]
        public MasterFacilitationDTO get_city([FromHeader(Name = "userid")] string userid,[FromBody] MasterFacilitationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.get_city(dto);
        }
        [Route("get_pincode")]
        public MasterFacilitationDTO get_pincode([FromHeader(Name = "userid")] string userid,[FromBody] MasterFacilitationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.get_pincode(dto);
        }
        [Route("save_facilitation")]
        public MasterFacilitationDTO save_facilitation([FromHeader(Name = "userid")] string userid,[FromBody] MasterFacilitationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.save_facilitation(dto);
        }

        // Map Facilitation and Pincode
        [Route("get_data_fc_map/{id:int}")]
        public MasterFacilitationDTO get_data_fc_map([FromHeader(Name = "userid")] string userid, int id)
        {
            MasterFacilitationDTO dto = new MasterFacilitationDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            dto.language_id = id;
            return _inter.get_data_fc_map(dto);
        }

        [Route("get_facilitation_dd")]
        public MasterFacilitationDTO get_facilitation_dd([FromHeader(Name = "userid")] string userid, [FromBody] MasterFacilitationDTO dto)
        {
           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.get_facilitation_dd(dto);
        }

        [Route("get_pincode_dd")]
        public MasterFacilitationDTO get_pincode_dd([FromHeader(Name = "userid")] string userid, [FromBody] MasterFacilitationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.get_pincode_dd(dto);
        }
        [Route("save_map_data")]
        public MasterFacilitationDTO save_map_data([FromHeader(Name = "userid")] string userid, [FromBody] MasterFacilitationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt32(userid);
            return _inter.save_map_data(dto);
        }

    }
}

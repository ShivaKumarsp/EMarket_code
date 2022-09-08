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
    public class Map_Specification_AttributeController : ControllerBase
    {
        IMap_Specification_Attribute _inter;
        public Map_Specification_AttributeController(IMap_Specification_Attribute inter)
        {
            _inter = inter;
        }



        //specification  Atribute name map
        [HttpGet("get_data/{id:int}")]
     
        public Master_SpecificationDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Master_SpecificationDTO dto = new Master_SpecificationDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_data(dto);
        }

        [HttpPost("get_attribute_name")]       
        public Master_SpecificationDTO get_attribute_name([FromHeader(Name = "userid")] string userid, Master_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_attribute_name(dto);
        }

         [HttpPost("save_data")]       
        public Master_SpecificationDTO save_data([FromHeader(Name = "userid")] string userid, Master_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.save_data(dto);
        }
         [HttpPost("get_attribute_name_edit")]       
        public Master_SpecificationDTO get_attribute_name_edit([FromHeader(Name = "userid")] string userid, Master_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_attribute_name_edit(dto);
        }
        [HttpPost("delete_spec_attribute")]       
        public Master_SpecificationDTO delete_spec_attribute([FromHeader(Name = "userid")] string userid, Master_SpecificationDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.delete_spec_attribute(dto);
        }

    }
}

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
    public class All_FC_Consignment_ListController : ControllerBase
    {
        IAll_FC_Consignment_List _inter;
        public All_FC_Consignment_ListController(IAll_FC_Consignment_List inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public All_FC_Consignment_ListDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            All_FC_Consignment_ListDTO dto = new All_FC_Consignment_ListDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.user_id = Convert.ToInt64(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }
    }
}

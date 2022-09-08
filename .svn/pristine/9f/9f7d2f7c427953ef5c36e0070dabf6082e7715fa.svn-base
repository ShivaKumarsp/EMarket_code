using EMarket.BLL.Interfaces.Admin;
using EMarketDTO.Admin;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class AdminDashboardController : ControllerBase
    {
        IAdminDashboard _inter;
        public AdminDashboardController(IAdminDashboard inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]

        public AdminDashboardDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            AdminDashboardDTO dto = new AdminDashboardDTO();
            dto.user_id = Convert.ToInt64(userid);
            dto.language_id = id;
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_data(dto);
        }
    }
}

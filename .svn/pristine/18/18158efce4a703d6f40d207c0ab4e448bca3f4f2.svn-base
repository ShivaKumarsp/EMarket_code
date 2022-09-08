using EMarket.BLL.Interfaces.Vendor;
using EMarket.DLL.Interfaces.Vendor;
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
    public class VendorDashboardController : ControllerBase
    {
        IVendorDashboard _inter;
        public VendorDashboardController(IVendorDashboard inter)
        {
            _inter = inter;
        }
        [Route("get_all_order/{id:int}")]
        public Vendor_DashBoardDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            Vendor_DashBoardDTO dto = new Vendor_DashBoardDTO();
            dto.user_id = Convert.ToInt64(userid);
            dto.language_id = id;
            dto.user_id = Convert.ToInt64(userid);
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_data(dto);
        }
  
        [Route("update_order")]
        public Vendor_All_Order_ListDTO update_order([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_All_Order_ListDTO dto)
        {

            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_order(dto);
        }

    }
}

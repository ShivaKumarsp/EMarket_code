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
    public class Vendor_All_Order_ListController : ControllerBase
    {
        IVendor_All_Order_List _inter;
        public Vendor_All_Order_ListController(IVendor_All_Order_List inter)
        {
            _inter = inter;
        }
        [Route("get_all_order/{id:int}")]
        public Vendor_All_Order_ListDTO get_all_order([FromHeader(Name = "userid")] string userid, int id)
        {
            Vendor_All_Order_ListDTO dto = new Vendor_All_Order_ListDTO();
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            dto.language_id = id;
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_all_order(dto);
        }
        
        [Route("update_order")]
        public Vendor_All_Order_ListDTO update_order([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_All_Order_ListDTO dto)
        {           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.update_order(dto);
        }
         [Route("get_item_lbh")]
        public Vendor_All_Order_ListDTO get_item_lbh([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_All_Order_ListDTO dto)
        {           
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            dto.user_id = Convert.ToInt64(userid);
            return _inter.get_item_lbh(dto);
        }
        


    }
}

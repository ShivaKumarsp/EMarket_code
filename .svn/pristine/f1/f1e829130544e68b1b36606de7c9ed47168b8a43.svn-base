using EMarket.BLL.Interfaces.Vendor;
using EMarketDTO.Admin;
using EMarketDTO.Vendar;
using Microsoft.AspNetCore.Antiforgery;
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
    public class Vendor_Add_ItemController : ControllerBase
    {

        IVendor_Add_Item _inter;
        private readonly IAntiforgery _antiforgery;
        public Vendor_Add_ItemController(IVendor_Add_Item inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;

        }

        [HttpGet("getdata/{id:int}")]
        [AllowAnonymous]
        public Vendor_Add_ItemDTO getdata([FromHeader(Name = "userid")] string userid, int id)
        { 
            Vendor_Add_ItemDTO dto = new Vendor_Add_ItemDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid); 
            return _inter.getdata(dto);
        }

        [HttpPost("get_item_product_details")]
        public Vendor_Add_ItemDTO get_item_product_details([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_Add_ItemDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_item_product_details(dto);
        }

        [Route("saveproductitem")]
        public Vendor_Add_ItemDTO saveproductitem([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_Add_ItemDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.saveproductitem(dto);
        }

        [Route("get_sku")]
        public Vendor_Add_ItemDTO get_sku([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_Add_ItemDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_sku(dto);
        }
        [Route("generate_itemcode")]
        public Vendor_Add_ItemDTO generate_itemcode([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_Add_ItemDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.generate_itemcode(dto);
        }

     
        [Route("get_specification_data")]
        public Vendor_Add_ItemDTO get_specification_data([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_Add_ItemDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_specification_data(dto);
        }

        [Route("save_itemspecification")]
        public Vendor_Add_ItemDTO save_itemspecification([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_Add_ItemDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.save_itemspecification(dto);
        }
        [Route("get_specific_edit_data")]
        public Vendor_Add_ItemDTO get_specific_edit_data([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_Add_ItemDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_specific_edit_data(dto);
        }


        [Route("update_itemspecification")]
        public Vendor_Add_ItemDTO update_itemspecification([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_Add_ItemDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.update_itemspecification(dto);
        }

        [HttpPost("get_product_details")]
        public Vendor_Add_ItemDTO get_product_details([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_Add_ItemDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.get_product_details(dto);
        }
        //Mukta 09-08-2022
        [HttpPost("save_multiple_images")]
        public Vendor_Add_ItemDTO save_multiple_images([FromHeader(Name = "userid")] string userid, [FromBody] Vendor_Add_ItemDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.save_multiple_images(dto);
        }
        [HttpPost("getdata_feature")]
        [AllowAnonymous]
        public itemfeaturesDTO getdata_feature([FromHeader(Name = "userid")] string userid, [FromBody] itemfeaturesDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.getdata_feature(dto);
        }

        [HttpPost("save_itemfeatures")]
        public itemfeaturesDTO save_itemfeatures([FromHeader(Name = "userid")] string userid, [FromBody] itemfeaturesDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            dto.userid = Convert.ToInt64(userid);
            return _inter.save_itemfeatures(dto);
        }
      

    }
}

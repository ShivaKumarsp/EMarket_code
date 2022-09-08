
using EMarket.BLL;
using EMarket.BLL.Interfaces.Customer;
using EMarket.DLL.Comman_Data;
using EMarket.DLL.Comman_Data.Comman_Interface;
using EMarket.Entities;
using EMarket.Entities.Admin;
using EMarketDTO.Customer;
using EMarketDTO.LoginDTO;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandingController : ControllerBase
    {
        private readonly ILanding_Service _inter;   
        private readonly IAntiforgery _antiForgeryService;      
        PostgreSqlContext _context;
        IComman_Data _business;      

        public LandingController(IAntiforgery antiForgeryService,  ILanding_Service inter,
            IComman_Data business,  PostgreSqlContext context)
        {
            //_inter = inter;
            _antiForgeryService = antiForgeryService;        
            _inter = inter;
            _business = business;         
            _context = context;

        }

        [HttpGet]
        [Route("getdata/{id:int}")]
        public PublicLandingDTO getdata(int id)
        {
            PublicLandingDTO dto = new PublicLandingDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.getdata(dto);
        }

        [Route("get_public_productdetails")]
        public PublicLandingDTO get_public_productdetails([FromBody] PublicLandingDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_public_productdetails(dto);
        }


        [Route("get_specification")]
        public PublicLandingDTO get_specification([FromBody] PublicLandingDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_specification(dto);
        }

        [Route("get_specification_details")]
        public PublicLandingDTO get_specification_details([FromBody] PublicLandingDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_specification_details(dto);
        }

        [Route("attributecheck")]
        public PublicLandingDTO attributecheck([FromBody] PublicLandingDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.attributecheck(dto);
        }

        [Route("get_subcategory")]
        public PublicLandingDTO get_subcategory([FromBody] PublicLandingDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_subcategory(dto);
        }
         [Route("get_addcategory")]
        public PublicLandingDTO get_addcategory([FromBody] PublicLandingDTO dto)
        {
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.get_addcategory(dto);
        }
        

        [HttpGet]
        [Route("getdata_footer/{id:int}")]
        public PublicLandingDTO getdata_footer(int id)
        {
            PublicLandingDTO dto = new PublicLandingDTO();
            dto.language_id = id;
            dto.ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return _inter.getdata_footer(dto);
        }

    }
}

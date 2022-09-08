using EMarket.BLL.Interfaces;
using EMarketDTO.Admin;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendortohubController : ControllerBase
    {
        IVendortohub _inter;
        private readonly IAntiforgery _antiforgery;
        public VendortohubController(IVendortohub inter, IAntiforgery antiforgery)
        {
            _inter = inter;
            _antiforgery = antiforgery;
        }
       


    }
}

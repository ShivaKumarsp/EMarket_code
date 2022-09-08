using EMarket.BLL.Interfaces.Vendor;

using EMarketDTO.Admin;
using Microsoft.AspNetCore.Antiforgery;
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
    public class itemfeaturesController : ControllerBase
    {

        IItem_Features _inter;
        private readonly IAntiforgery _antiForgery;
        public itemfeaturesController(IItem_Features inter, IAntiforgery antiForgery)
        {
            _inter = inter;
            _antiForgery = antiForgery;
        }

       

    }
}

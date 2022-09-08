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
    [AllowAnonymous]
    public class TestController : ControllerBase
    {
        ITest _inter;
        public TestController(ITest inter)
        {
            _inter = inter;
        }
        [Route("get_data/{id:int}")]
        public TestDTO get_data([FromHeader(Name = "userid")] string userid, int id)
        {
            TestDTO dto = new TestDTO();
            dto.user_id = Convert.ToInt32(userid);
            dto.language_id = id;
            return _inter.get_data(dto);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;

namespace ShopGames.Controllers
{
    [ApiController]
    [Route("SystemRequirement")]
    public class SystemReqController : ControllerBase
    {
        [HttpGet]
        public Task<List<SystemReqView>> Get()
        {
            try
            {
                return Services.ServSystemReq.Get();
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        [HttpPost]
        public void Post([FromBody] SystemRequirement systemReq)
        {
            try
            {
                Services.ServSystemReq.Post(systemReq);
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        [HttpPatch]
        public void Patch([FromBody] SystemRequirement systemReq)
        {
            try
            {
                Services.ServSystemReq.Patch(systemReq);
            }
            catch (Exception e)
            {

                throw new Exception($"{e}");
            }
        }
    }
}
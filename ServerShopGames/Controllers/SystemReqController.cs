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
        public Task<List<SystemReqView>> SearchSystemReq()
        {
            try
            {
                return Services.ServSystemReq.SearchSystemReq();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public Task<SystemReqView> NewSystemReq([FromBody] SystemRequirement systemReq)
        {
            try
            {
                return Services.ServSystemReq.NewSystemReq(systemReq);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        public Task<SystemReqView> ChangeSystemReq([FromBody] SystemRequirement systemReq)
        {
            try
            {
                return Services.ServSystemReq.ChangeSystemReq(systemReq);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
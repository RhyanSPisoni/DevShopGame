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
    [Route("Enterprise")]
    public class EnterpriseController : ControllerBase
    {
        [HttpGet]
        public Task<List<EnterpriseView>> Get()
        {
            try
            {
                return Services.ServEnterprise.Get();
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        [HttpPost]
        public Task<EnterpriseView> Post([FromBody] Enterprise Ent)
        {
            try
            {
                return Services.ServEnterprise.Post(Ent);
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        [HttpPatch]
        public void Patch([FromBody] Enterprise Ent)
        {
            try
            {
                Services.ServEnterprise.Patch(Ent);
            }
            catch (Exception e)
            {

                throw new Exception($"{e}");
            }
        }
    }
}
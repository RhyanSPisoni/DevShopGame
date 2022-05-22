using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopGames.DTOs.ModelsDto;
using ShopGames.Models;
using ShopGames.Views;

namespace ShopGames.Controllers
{
    [ApiController]
    [Route("Enterprise")]
    public class EnterpriseController : ControllerBase
    {
        [HttpGet]
        public Task<List<EnterpriseView>> SearchEnterprises()
        {
            try
            {
                return Services.ServEnterprise.SearchEnterprises();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public Task<EnterpriseView> NewEnterprise([FromBody] EnterpriseDTO ent)
        {
            try
            {
                return Services.ServEnterprise.NewEnterprise(ent);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        public Task<EnterpriseView> ChangeEnterprise([FromBody] EnterpriseDTO ent)
        {
            try
            {
                return Services.ServEnterprise.ChangeEnterprise(ent);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
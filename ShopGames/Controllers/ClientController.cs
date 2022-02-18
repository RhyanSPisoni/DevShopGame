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
    [Route("Client")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public Task<List<ClientView>> Get()
        {
            try
            {
                return Services.ServClient.Get();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public void Post([FromBody] Client Cli)
        {
            try
            {
                Services.ServClient.Post(Cli);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        public void Patch([FromBody] Client Cli)
        {
            try
            {
                Services.ServClient.Patch(Cli);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
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
        public Task<List<ClientView>> SearchClients()
        {
            try
            {
                return Services.ServClient.SearchClients();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public Task<ClientView> NewClient([FromBody] Client Cli)
        {
            try
            {
                return Services.ServClient.NewClient(Cli);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        public Task<ClientView> ChangeClient([FromBody] Client Cli)
        {
            try
            {
                return Services.ServClient.ChangeClient(Cli);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
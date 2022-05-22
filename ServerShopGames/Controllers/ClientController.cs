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
        public Task<ClientView> NewClient([FromBody] ClientDTO cli)
        {
            try
            {
                return Services.ServClient.NewClient(cli);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        public Task<ClientView> ChangeClient([FromBody] ClientDTO cli)
        {
            try
            {
                return Services.ServClient.ChangeClient(cli);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
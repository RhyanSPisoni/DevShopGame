using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Client>> Get([FromServices] ShopGamesDbContext Db)
        {
            return await Db.Clients.ToListAsync();
        }

        [HttpGet]
        [Route("id")]
        public async Task<List<Client>> Get([FromServices] ShopGamesDbContext Db, int Id)
        {
            return await Db.Clients.Where(x => x.Id_Client == Id).ToListAsync();
        }

        [HttpPost]
        public async Task<string> Post([FromServices] ShopGamesDbContext Db, [FromBody] Client c)
        {
            Db.Add(c);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpPut]
        public async Task<string> Put([FromServices] ShopGamesDbContext Db, [FromBody] Client c)
        {
            Db.Update(c);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpDelete]
        public async Task<string> Delete([FromServices] ShopGamesDbContext Db, [FromQuery] int id)
        {

            var i = new Client { Id_Client = id };

            Db.Remove(i);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }
    }
}
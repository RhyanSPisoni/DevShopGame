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
    public class EnterpriseController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Enterprise>> Get([FromServices] ShopGamesDbContext Db)
        {
            return await Db.Enterprises.ToListAsync();
        }

        [HttpGet]
        [Route("id")]
        public async Task<List<Enterprise>> Get([FromServices] ShopGamesDbContext Db, int Id)
        {
            return await Db.Enterprises.Where(x => x.Id_Enterprise == Id).ToListAsync();
        }

        [HttpPost]
        public async Task<string> Post([FromServices] ShopGamesDbContext Db, [FromBody] Enterprise emp)
        {
            Db.Add(emp);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpPut]
        public async Task<string> Put([FromServices] ShopGamesDbContext Db, [FromBody] Enterprise emp)
        {
            Db.Update(emp);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpDelete]
        public async Task<string> Delete([FromServices] ShopGamesDbContext Db, [FromQuery] int id)
        {
            var emp = new Enterprise { Id_Enterprise = id };

            Db.Remove(emp);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

    }
}
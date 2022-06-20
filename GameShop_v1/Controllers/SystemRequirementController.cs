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
    public class SystemRequirementController : ControllerBase
    {
        [HttpGet]
        public async Task<List<SystemRequirement>> Get([FromServices] ShopGamesDbContext Db)
        {
            return await Db.SystemRequirements.ToListAsync();
        }

        [HttpGet]
        [Route("id")]
        public async Task<List<SystemRequirement>> Get([FromServices] ShopGamesDbContext Db, int Id)
        {
            return await Db.SystemRequirements.Where(x => x.Id_System_Requirement == Id).ToListAsync();
        }

        [HttpPost]
        public async Task<string> Post([FromServices] ShopGamesDbContext Db, [FromBody] SystemRequirement sr)
        {
            Db.Add(sr);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpPut]
        public async Task<string> Put([FromServices] ShopGamesDbContext Db, [FromBody] SystemRequirement sr)
        {
            Db.Update(sr);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpDelete]
        public async Task<string> Delete([FromServices] ShopGamesDbContext Db, [FromQuery] int id)
        {
            var sr = new SystemRequirement { Id_System_Requirement = id };

            Db.Remove(sr);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }
    }
}
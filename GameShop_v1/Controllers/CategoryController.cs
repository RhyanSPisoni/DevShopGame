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
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get(
            [FromServices] ShopGamesDbContext Db
        )
        {
            return await Db.Categories.ToListAsync();
        }

        [HttpGet]
        [Route("id")]
        public async Task<List<Category>> Get([FromServices] ShopGamesDbContext Db, int Id)
        {
            return await Db.Categories.Where(x => x.id_category == Id).ToListAsync();
        }

        [HttpPost]
        public async Task<string> Post([FromServices] ShopGamesDbContext Db, [FromBody] Category ct)
        {
            Db.Add(ct);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpPut]
        public async Task<string> Put([FromServices] ShopGamesDbContext Db, [FromBody] Category ct)
        {
            Db.Update(ct);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpDelete]
        public async Task<string> Delete([FromServices] ShopGamesDbContext Db, [FromQuery] int id)
        {
            var ct = new Category { id_category = id };

            Db.Remove(ct);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }
    }
}

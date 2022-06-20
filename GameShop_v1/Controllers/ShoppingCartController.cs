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
    public class ShoppingCartController : ControllerBase
    {
        [HttpGet]
        public async Task<List<ShoppingCart>> Get([FromServices] ShopGamesDbContext Db)
        {
            return await Db.ShoppingCarts
                           .Include(x => x.Client)
                           .Include(x => x.Product)
                           .ToListAsync();
        }

        [HttpGet]
        [Route("id")]
        public async Task<List<ShoppingCart>> Get([FromServices] ShopGamesDbContext Db, int Id)
        {
            return await Db.ShoppingCarts
                           .Include(x => x.Client)
                           .Include(x => x.Product)
                           .Where(x => x.Id_Shop == Id)
                           .Where(x => x.fl_situation == true)
                           .ToListAsync();
        }

        [HttpPost]
        public async Task<string> Post([FromServices] ShopGamesDbContext Db, [FromBody] ShoppingCart c)
        {
            Db.Add(c);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpPut]
        public async Task<string> Put([FromServices] ShopGamesDbContext Db, [FromBody] ShoppingCart c)
        {
            Db.Update(c);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpDelete]
        public async Task<string> Delete([FromServices] ShopGamesDbContext Db, [FromQuery] int id)
        {

            var i = new ShoppingCart { Id_Shop = id };

            Db.Remove(i);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }
    }
}
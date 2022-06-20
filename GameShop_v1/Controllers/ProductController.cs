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
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Product>> Get([FromServices] ShopGamesDbContext Db)
        {
            return await Db.Products
                           .AsNoTracking()
                           .Include(x => x.ProductSystemReq)
                           .ThenInclude(x => x.SystemRequirement)
                           .Include(x => x.Enterprise)
                           .Include(x => x.Category)
                           .ToListAsync();
        }

        [HttpGet]
        [Route("id")]
        public async Task<List<Product>> Get([FromServices] ShopGamesDbContext Db, int Id)
        {
            return await Db.Products.Where(x => x.Id_Product == Id).ToListAsync();
        }

        [HttpPost]
        public async Task<string> Post([FromServices] ShopGamesDbContext Db, [FromBody] Product p)
        {
            Db.Add(p);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpPut]
        public async Task<string> Put([FromServices] ShopGamesDbContext Db, [FromBody] Product p)
        {
            Db.Update(p);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpDelete]
        public async Task<string> Delete([FromServices] ShopGamesDbContext Db, [FromQuery] int id)
        {
            var p = new Product { Id_Product = id };

            Db.Remove(p);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }
    }
}
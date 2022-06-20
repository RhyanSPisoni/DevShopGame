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
    public class LibraryUserController : ControllerBase
    {
        [HttpGet]
        public async Task<List<LibraryUser>> Get([FromServices] ShopGamesDbContext Db)
        {
            return await Db.LibraryUsers
                           .Include(x => x.Client)
                           .Include(x => x.Product)
                           .ToListAsync();
        }

        [HttpGet]
        [Route("id")]
        public async Task<List<LibraryUser>> Get([FromServices] ShopGamesDbContext Db, int Id)
        {
            return await Db.LibraryUsers
                       .Include(x => x.Client)
                       .Include(x => x.Product)
                       .Where( x => x.Id_Library == Id)
                       .ToListAsync();
        }

        [HttpPost]
        public async Task<string> Post([FromServices] ShopGamesDbContext Db, [FromBody] LibraryUser c)
        {
            Db.Add(c);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpPut]
        public async Task<string> Put([FromServices] ShopGamesDbContext Db, [FromBody] LibraryUser c)
        {
            Db.Update(c);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }

        [HttpDelete]
        public async Task<string> Delete([FromServices] ShopGamesDbContext Db, [FromQuery] int id)
        {

            var i = new LibraryUser { Id_Library = id };

            Db.Remove(i);
            await Db.SaveChangesAsync();

            return "Sucesso!";
        }
    }
}
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
    [Route("Category")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public Task<List<CategoryView>> Get()
        {
            try
            {
                return Services.ServCategory.Get();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public void Post([FromBody] Category Cat)
        {
            try
            {
                Services.ServCategory.Post(Cat);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        public void Patch([FromBody] Category Cat)
        {
            try
            {
                Services.ServCategory.Patch(Cat);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
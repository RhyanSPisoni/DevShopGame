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
    [Route("Product")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public Task<List<ProductView>> Get()
        {
            try
            {
                return Services.ServProduct.Get();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public void Post([FromBody] Product prod)
        {
            try
            {
                Services.ServProduct.Post(prod);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        public void Patch([FromBody] Product prod)
        {
            try
            {
                Services.ServProduct.Patch(prod);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
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
        public Task<List<ProductView>> SearchProduct()
        {
            try
            {
                return Services.ServProduct.SearchProduct();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public Task<ProductView> NewProduct([FromBody] Product prod)
        {
            try
            {
                return Services.ServProduct.NewProduct(prod);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        public Task<ProductView> ChangeProduct([FromBody] Product prod)
        {
            try
            {
                return Services.ServProduct.ChangeProduct(prod);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
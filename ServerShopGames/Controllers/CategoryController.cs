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
        public Task<List<CategoryView>> SearchCategories()
        {
            try
            {
                return Services.ServCategory.SearchCategories();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public void NewCategory([FromBody] Category Cat)
        {
            try
            {
                Services.ServCategory.NewCategory(Cat);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        public Task<CategoryView> ChangeCategory([FromBody] Category Cat)
        {
            try
            {
                return Services.ServCategory.ChangeCategory(Cat);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
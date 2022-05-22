using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopGames.DTOs.ModelsDto;
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
        public Task<CategoryView> NewCategory([FromBody] CategoryDTO cat)
        {
            try
            {
                return Services.ServCategory.NewCategory(cat);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        public Task<CategoryView> ChangeCategory([FromBody] CategoryDTO cat)
        {
            try
            {
                return Services.ServCategory.ChangeCategory(cat);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
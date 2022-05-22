using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopGames.DTOs.ModelsDto;
using ShopGames.Models;
using ShopGames.Services.Validators;
using ShopGames.Views;

namespace ShopGames.Services
{
    public class ServCategory
    {
        public async static Task<List<CategoryView>> SearchCategories()
        {
            try
            {
                using (var Db = new ShopGamesContext())
                {
                    return await Db.Categories.AsNoTracking()
                    .Where(x => x.FlActive == 1)
                    .Select(x => new CategoryView
                    {
                        IdCategory = x.IdCategory,
                        NmCategory = x.NmCategory
                    }).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao tentar mostrar lista de Empresas: {e.Message}");
            }
        }

        public static async Task<CategoryView> NewCategory(CategoryDTO cat)
        {
            try
            {
                ValidatorCategory.ValidateEmptyOrNullCategory(cat);
                ValidatorCategory.ValidateDuplicateCategoryNew(cat);

                await using (var Db = new ShopGamesContext())
                {
                    Console.WriteLine("A");

                    await Db.Categories.AddAsync(new Category
                    {
                        IdCategory = cat.IdCategory,
                        NmCategory = cat.NmCategory,
                        FlActive = cat.FlActive,
                    });

                    await Db.SaveChangesAsync();

                    return (new CategoryView
                    {
                        IdCategory = cat.IdCategory,
                        NmCategory = cat.NmCategory
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao inserir uma Categoria: {e.Message}");
            }
        }

        public static async Task<CategoryView> ChangeCategory(CategoryDTO cat)
        {
            try
            {
                ValidatorCategory.ValidateEmptyOrNullCategory(cat);

                await using (var Db = new ShopGamesContext())
                {
                    Db.Categories.Update(new Category
                    {
                        IdCategory = cat.IdCategory,
                        NmCategory = cat.NmCategory,
                        FlActive = cat.FlActive,
                    });
                    await Db.SaveChangesAsync();

                    return (new CategoryView
                    {
                        IdCategory = cat.IdCategory,
                        NmCategory = cat.NmCategory
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao tentar alterar uma Categoria: {e.Message}");
            }
        }

    }
}
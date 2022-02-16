using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Services.Validators;
using ShopGames.Views;

namespace ShopGames.Services
{
    public class ServCategory
    {
        public async static Task<List<CategoryView>> Get()
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

        public static async void Post(Category cat)
        {
            try
            {
                ValidatorCategory.EmptyOrNullCategory(cat);
                ValidatorCategory.DuplicateCategoryNew(cat);

                await using (var Db = new ShopGamesContext())
                {
                    await Db.Categories.AddAsync(cat);
                    await Db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao inserir uma Categoria: {e.Message}");
            }
        }

        public static async void Patch(Category cat)
        {
            try
            {
                ValidatorCategory.EmptyOrNullCategory(cat);

                await using (var Db = new ShopGamesContext())
                {
                    Db.Categories.Update(cat);
                    await Db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao tentar alterar uma Categoria: {e.Message}");
            }
        }

    }
}
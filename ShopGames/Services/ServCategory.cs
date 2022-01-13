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
                throw new Exception($"Erro ao tentar mostrar lista de Empresas: {e}");
            }
        }

        public static async void Post(Category Cat)
        {
            try
            {
                ValidatorCategory.DuplicateCategoryNew(Cat);

                await using (var Db = new ShopGamesContext())
                {
                    await Db.Categories.AddAsync(Cat);
                    await Db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao inserir uma Categoria: {e}");
            }
        }

        public static async void Patch(Category Cat)
        {
            try
            {
                await using (var Db = new ShopGamesContext())
                {
                    Db.Categories.Update(Cat);
                    await Db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao alterar uma Empresa: {e}");
            }
        }

    }
}
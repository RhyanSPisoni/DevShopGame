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
    public class ServProduct
    {
        public async static Task<List<ProductView>> Get()
        {
            try
            {
                using (var Db = new ShopGamesContext())
                {
                    return await Db.Products.AsNoTracking()
                    .Where(x => x.FlActive == 1)
                    .Select(x => new ProductView
                    {
                        IdProduct = x.IdProduct,
                        NmProduct = x.NmProduct
                    }).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao mostrar lista de Empresas: {e.Message}");
            }
        }

        public static async Task<ProductView> Post(Product prod)
        {
            try
            {
                ValidatorProduct.DuplicateProductNew(prod);

                await using (var Db = new ShopGamesContext())
                {
                    await Db.Products.AddAsync(prod);
                    await Db.SaveChangesAsync();

                    return (new ProductView
                    {
                        IdProduct = prod.IdProduct,
                        NmProduct = prod.NmProduct
                    });
                }



            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao inserir uma Empresa: {e.Message}");
            }
        }

        public static async void Patch(Product prod)
        {
            try
            {
                await using (var Db = new ShopGamesContext())
                {
                    Db.Products.Update(prod);
                    await Db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao alterar uma Empresa: {e.Message}");
            }
        }
    }

}
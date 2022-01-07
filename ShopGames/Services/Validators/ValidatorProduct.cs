using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;

namespace ShopGames.Services.Validators
{
    public class ValidatorProduct
    {
        public static void DuplicateProductNew(ProductView Prod)
        {
            using (var Db = new ShopGamesContext())
            {
                var duplicado = Db.Products.AsNoTracking().FirstOrDefault(x => x.NmProduct == Prod.NmProduct);

                if (duplicado != null)
                    throw new Exception("Existe duplicidade de Empresas");
            }
        }
    }
}
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;

namespace ShopGames.Services.Validators
{
    public class ValidatorCategory
    {
        public static void DuplicateCategoryNew(Category Cat)
        {
            using (var Db = new ShopGamesContext())
            {
                var duplicado = Db.Categories.AsNoTracking().FirstOrDefault(x => x.NmCategory == Cat.NmCategory);

                if (duplicado != null)
                    throw new Exception("Existe duplicidade de Empresas");
            }
        }
    }
}
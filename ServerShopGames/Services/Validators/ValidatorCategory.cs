using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;

namespace ShopGames.Services.Validators
{
    public class ValidatorCategory
    {
        public static void EmptyOrNullCategory(Category cat)
        {
            if (cat.NmCategory.Trim() == "" || cat.NmCategory == null)
                throw new Exception("Insira um nome para Categoria!");
        }

        public static void DuplicateCategoryNew(Category cat)
        {
            using (var Db = new ShopGamesContext())
            {
                var duplicado = Db.Categories.AsNoTracking().FirstOrDefault(x => x.NmCategory.Trim() == cat.NmCategory.Trim());

                if (duplicado != null)
                    throw new Exception("Existe duplicidade de Categoria");
            }
        }
    }
}
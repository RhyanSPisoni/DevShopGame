using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;

namespace ShopGames.Services.Validators
{
    public class ValidatorSystemReq
    {
        public static void DuplicateSystemReqNew(SystemRequirement Sys)
        {
            using (var Db = new ShopGamesContext())
            {
                var duplicado = Db.SystemRequirements.AsNoTracking().FirstOrDefault(x => x.NmRequired == Sys.NmRequired);

                if (duplicado != null)
                    throw new Exception("Existe duplicidade de Empresas");
            }
        }
    }
}
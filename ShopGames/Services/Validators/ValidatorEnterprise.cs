using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;

namespace ShopGames.Services.Validators
{
    public class ValidatorEnterprise
    {
        public static void DuplicateEnterpriseNew(EnterpriseView Ent)
        {
            using (var Db = new ShopGamesContext())
            {
                var duplicado = Db.Enterprises.AsNoTracking().FirstOrDefault(x => x.NmEnterprise == Ent.NmEnterprise);

                if (duplicado != null)
                    throw new Exception("Existe duplicidade de Empresas");
            }
        }
    }
}
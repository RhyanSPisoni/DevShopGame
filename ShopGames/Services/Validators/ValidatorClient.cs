using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;

namespace ShopGames.Services.Validators
{
    public class ValidatorClient
    {
        public static void DuplicateClientNew(ClientView Cli)
        {
            using (var Db = new ShopGamesContext())
            {
                var duplicado = Db.Clients.AsNoTracking().FirstOrDefault(x => x.VlCpf == Cli.VlCpf);

                if (duplicado != null)
                    throw new Exception("Existe duplicidade de Empresas");
            }
        }
    }
}
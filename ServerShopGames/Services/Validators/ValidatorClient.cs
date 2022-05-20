using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;

namespace ShopGames.Services.Validators
{
    public class ValidatorClient
    {
        public static async Task DuplicateClientNew(Client Cli)
        {
            using (var Db = new ShopGamesContext())
            {
                var duplicado = await Db.Clients.AsNoTracking().FirstOrDefaultAsync(x => x.VlCpf == Cli.VlCpf);

                if (duplicado != null)
                {
                    await Task.Delay(10);
                    throw new Exception("Existe duplicidade de Empresas");
                }
            }
        }
    }
}
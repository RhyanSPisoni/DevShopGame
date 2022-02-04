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
    public class ServClient
    {
        public static async Task<List<ClientView>> Get()
        {
            try
            {
                using (var Db = new ShopGamesContext())
                {
                    return await Db.Clients.AsNoTracking()
                    .Select(x => new ClientView
                    {
                        IdClient = x.IdClient,
                        NmClient = x.NmClient,
                        NmMail = x.NmMail,
                        NmNick = x.NmNick,
                        Active = x.FlActive,
                        DtRegistration = x.DtRegistration
                    }).ToListAsync();
                }
            }
            catch (System.Exception)
            {
                throw new Exception("Não foi possível buscar os clientes");
            }
        }

        public static async void Post(Client Cli)
        {
            await using (var Db = new ShopGamesContext())
            {
                await Db.Clients.AddAsync(Cli);
                await Db.SaveChangesAsync();
            }
        }

        public static async void Patch(Client Cli)
        {
            try
            {
                await using (var Db = new ShopGamesContext())
                {
                    Db.Clients.Update(Cli);
                    await Db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw new Exception($"Erro ao alterar cliente");
            }
        }

    }
}
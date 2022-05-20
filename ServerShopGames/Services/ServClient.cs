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
        public static async Task<List<ClientView>> SearchClients()
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

        public static async Task<ClientView> NewClient(Client Cli)
        {
            await using (var Db = new ShopGamesContext())
            {
                await Db.Clients.AddAsync(Cli);
                await Db.SaveChangesAsync();

                return (new ClientView
                {
                    IdClient = Cli.IdClient,
                    NmClient = Cli.NmClient,
                    DtRegistration = Cli.DtRegistration
                });
            }
        }

        public static async Task<ClientView> ChangeClient(Client cli)
        {
            try
            {
                await using (var Db = new ShopGamesContext())
                {
                    Db.Clients.Update(cli);
                    await Db.SaveChangesAsync();

                    return (new ClientView
                    {
                        IdClient = cli.IdClient,
                        NmClient = cli.NmClient,
                        NmMail = cli.NmMail,
                        NmNick = cli.NmNick,
                        Active = cli.FlActive,
                        DtRegistration = cli.DtRegistration
                    });
                }
            }
            catch (Exception)
            {
                throw new Exception($"Erro ao alterar cliente");
            }
        }

    }
}
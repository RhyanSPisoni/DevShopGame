using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;
using ShopGames.Services.Validators;

namespace ShopGames.Services
{
    public class ServEnterprise
    {
        public async static Task<List<EnterpriseView>> Get()
        {
            try
            {
                using (var Db = new ShopGamesContext())
                {
                    return await Db.Enterprises.AsNoTracking()
                    .Where(x => x.FlActive == 1)
                    .Select(x => new EnterpriseView
                    {
                        IdEnterprise = x.IdEnterprise,
                        NmEnterprise = x.NmEnterprise
                    }).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao mostrar lista de Empresas: {e}");
            }
        }

        public static async Task<EnterpriseView> Post(Enterprise Ent)
        {
            try
            {

                ValidatorEnterprise.DuplicateEnterpriseNew(Ent);

                await using (var Db = new ShopGamesContext())
                {
                    await Db.Enterprises.AddAsync(Ent);
                    await Db.SaveChangesAsync();
                }

                var EntV = (new EnterpriseView
                {
                    IdEnterprise = Ent.IdEnterprise,
                    NmEnterprise = Ent.NmEnterprise
                });

                return EntV;

            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao inserir uma Empresa: {e}");
            }
        }

        public static async void Patch(Enterprise Ent)
        {
            try
            {
                await using (var Db = new ShopGamesContext())
                {
                    Db.Enterprises.Update(Ent);
                    await Db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao alterar uma Empresa: {e}");
            }
        }
    }
}
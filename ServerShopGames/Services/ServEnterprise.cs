using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;
using ShopGames.Services.Validators;
using ShopGames.DTOs.ModelsDto;

namespace ShopGames.Services
{
    public class ServEnterprise
    {
        public async static Task<List<EnterpriseView>> SearchEnterprises()
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
            catch (Exception)
            {
                throw new Exception($"Erro ao mostrar lista de Empresas");
            }
        }

        public static async Task<EnterpriseView> NewEnterprise(EnterpriseDTO ent)
        {
            try
            {
                ValidatorEnterprise.DuplicateEnterpriseNew(ent);

                await using (var Db = new ShopGamesContext())
                {
                    await Db.Enterprises.AddAsync(new Enterprise
                    {
                        FlActive = ent.FlActive,
                        IdEnterprise = ent.IdEnterprise,
                        NmEnterprise = ent.NmEnterprise
                    });

                    await Db.SaveChangesAsync();

                    return (new EnterpriseView
                    {
                        IdEnterprise = ent.IdEnterprise,
                        NmEnterprise = ent.NmEnterprise
                    });
                }


            }
            catch (Exception)
            {
                throw new Exception($"Erro ao inserir uma Empresa");
            }
        }

        public static async Task<EnterpriseView> ChangeEnterprise(EnterpriseDTO ent)
        {
            try
            {
                await using (var Db = new ShopGamesContext())
                {
                    Db.Enterprises.Update(new Enterprise
                    {
                        FlActive = ent.FlActive,
                        IdEnterprise = ent.IdEnterprise,
                        NmEnterprise = ent.NmEnterprise
                    });

                    await Db.SaveChangesAsync();

                    return (new EnterpriseView
                    {
                        IdEnterprise = ent.IdEnterprise,
                        NmEnterprise = ent.NmEnterprise
                    });
                }
            }
            catch (Exception)
            {
                throw new Exception($"Erro ao alterar uma Empresa");
            }
        }
    }
}
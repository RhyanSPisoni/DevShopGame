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
    public class ServSystemReq
    {
        public async static Task<List<SystemReqView>> SearchSystemReq()
        {
            try
            {
                using (var Db = new ShopGamesContext())
                {
                    return await Db.SystemRequirements.AsNoTracking()
                    .Where(x => x.FlActive == 1)
                    .Select(x => new SystemReqView
                    {
                        IdSystemRequirement = x.IdSystemRequirement,
                        NmRequired = x.NmRequired
                    }).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao mostrar lista de Empresas: {e.Message}");
            }
        }

        public static async Task<SystemReqView> NewSystemReq(SystemRequirement prod)
        {
            try
            {
                await using (var Db = new ShopGamesContext())
                {
                    await Db.SystemRequirements.AddAsync(prod);
                    await Db.SaveChangesAsync();

                    return (new SystemReqView
                    {
                        IdSystemRequirement = prod.IdSystemRequirement,
                        NmRequired = prod.NmRequired
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao inserir uma Empresa: {e.Message}");
            }
        }

        public static async Task<SystemReqView> ChangeSystemReq(SystemRequirement prod)
        {
            try
            {
                await using (var Db = new ShopGamesContext())
                {
                    Db.SystemRequirements.Update(prod);
                    await Db.SaveChangesAsync();

                    return (new SystemReqView
                    {
                        IdSystemRequirement = prod.IdSystemRequirement,
                        NmRequired = prod.NmRequired
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao alterar uma Empresa: {e.Message}");
            }
        }

    }
}
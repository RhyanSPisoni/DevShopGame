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
        public async static Task<List<SystemReqView>> Get()
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

        public static async Task<SystemReqView> Post(SystemRequirement prod)
        {
            try
            {
                // ValidatorSystemReq.DuplicateNewRequirement(prod);

                await using (var Db = new ShopGamesContext())
                {
                    await Db.SystemRequirements.AddAsync(prod);
                    await Db.SaveChangesAsync();
                }

                var EntV = (new SystemReqView
                {
                    IdSystemRequirement = prod.IdSystemRequirement,
                    NmRequired = prod.NmRequired
                });

                return EntV;

            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao inserir uma Empresa: {e.Message}");
            }
        }

        public static async void Patch(SystemRequirement prod)
        {
            try
            {
                await using (var Db = new ShopGamesContext())
                {
                    Db.SystemRequirements.Update(prod);
                    await Db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao alterar uma Empresa: {e.Message}");
            }
        }

    }
}
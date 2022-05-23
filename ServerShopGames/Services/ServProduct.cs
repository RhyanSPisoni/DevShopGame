using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopGames.DTOs.ModelsDto;
using ShopGames.Models;
using ShopGames.Services.Validators;
using ShopGames.Views;

namespace ShopGames.Services
{
    public class ServProduct
    {
        public async static Task<List<ProductView>> SearchProduct()
        {
            try
            {
                using (var Db = new ShopGamesContext())
                {
                    return await Db.Products.AsNoTracking()
                    .Where(x => x.FlActive == 1)
                    .Select(x => new ProductView
                    {
                        IdProduct = x.IdProduct,
                        NmProduct = x.NmProduct
                    }).ToListAsync();
                }
            }
            catch (Exception)
            {
                throw new Exception($"Erro ao mostrar lista de Empresas");
            }
        }

        public static async Task<ProductView> NewProduct(ProductDTO prod)
        {
            try
            {
                ValidatorProduct.DuplicateProductNew(prod);

                await using (var Db = new ShopGamesContext())
                {
                    await Db.Products.AddAsync(new Product
                    {
                        IdProduct = prod.IdProduct,
                        DsText = prod.DsText,
                        DtLauncher = prod.DtLauncher,
                        FlActive = prod.FlActive,
                        IdCategory = prod.IdCategory,
                        IdDeveloper = prod.IdDeveloper,
                        IdProvider = prod.IdProvider,
                        NmProduct = prod.NmProduct,
                        VlAvaliation = prod.VlAvaliation,
                        VlDiscount = prod.VlDiscount,
                        VlPrice = prod.VlPrice,
                        VlProdcount = prod.VlProdcount,
                        ProductSystemReqs = new List<ProductSystemReq>()
                        {
                            new ProductSystemReq {
                                IdSystemRequirement = prod.ProductSystemReqs.Select( x => x.IdSystemRequirement).FirstOrDefault()
                            }
                        }
                    });
                    await Db.SaveChangesAsync();

                    return (new ProductView
                    {
                        IdProduct = prod.IdProduct,
                        NmProduct = prod.NmProduct
                    });
                }



            }
            catch (Exception)
            {
                throw new Exception($"Erro ao inserir uma Empresa");
            }
        }

        public static async Task<ProductView> ChangeProduct(ProductDTO prod)
        {
            try
            {
                await using (var Db = new ShopGamesContext())
                {
                    Db.Products.Update(new Product
                    {
                        IdProduct = prod.IdProduct,
                        DsText = prod.DsText,
                        DtLauncher = prod.DtLauncher,
                        FlActive = prod.FlActive,
                        IdCategory = prod.IdCategory,
                        IdDeveloper = prod.IdDeveloper,
                        IdProvider = prod.IdProvider,
                        NmProduct = prod.NmProduct,
                        VlAvaliation = prod.VlAvaliation,
                        VlDiscount = prod.VlDiscount,
                        VlPrice = prod.VlPrice,
                        VlProdcount = prod.VlProdcount,
                        ProductSystemReqs = new List<ProductSystemReq>()
                        {
                            new ProductSystemReq {
                                IdSystemRequirement = prod.ProductSystemReqs.Select( x => x.IdSystemRequirement).FirstOrDefault()
                            }
                        }
                    });
                    await Db.SaveChangesAsync();

                    return (new ProductView
                    {
                        IdProduct = prod.IdProduct,
                        NmProduct = prod.NmProduct
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
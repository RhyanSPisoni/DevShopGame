using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;
using ShopGames.DTOs;
using ShopGames.Services.Validators;
using ShopGames.Services.Auth;

namespace ShopGames.Services
{
    public class ServLogin
    {
        public static async Task<ActionResult<dynamic>> LoginUser(LoginDTO log)
        {
            ValidatorLogin.ValidatorField(log);

            using (var Db = new ShopGamesContext())
            {
                var login = await Db.Clients.Where(x => x.NmMail.ToUpper() == log.NmMail.ToUpper() &&
                                                   x.VlPassword.ToUpper() == log.VlPassword.ToUpper())
                                        .Select(x => new LoginDTO
                                        {
                                            NmMail = x.NmMail,
                                            VlPassword = x.VlPassword
                                        })
                                        .FirstOrDefaultAsync();

                if (login.NmMail != null)
                {
                    var token = TokenService.GenerateToken(log);

                    return new
                    {
                        user = login,
                        token = token
                    };
                }
                else
                    throw new Exception("Esse usuário não existe!");
            }
        }
    }
}
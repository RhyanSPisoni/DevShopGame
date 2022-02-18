using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopGames.Models;
using ShopGames.Views;
using ShopGames.DTOs;
using ShopGames.Services;
using Microsoft.AspNetCore.Authorization;

namespace ShopGames.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<dynamic>> LoginUser(LoginDTO log)
        {
            try
            {
                return await ServLogin.LoginUser(log);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
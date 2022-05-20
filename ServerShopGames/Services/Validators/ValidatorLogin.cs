using System.Collections.Generic;
using ShopGames.DTOs;
using System;

namespace ShopGames.Services.Validators
{
    public static class ValidatorLogin
    {
        public static void ValidatorField(LoginDTO log)
        {
            var fields = new List<string>();

            if ((log.NmMail.Trim() == null || log.NmMail.Trim() == ""))
                fields.Add(log.NmMail);

            if (log.VlPassword.Trim() == null || log.VlPassword.Trim() == "")
                fields.Add(log.NmMail);

            if (fields.Count != 0)
                throw new AggregateException("Campos vazios!", (IEnumerable<Exception>)fields);

        }
    }
}
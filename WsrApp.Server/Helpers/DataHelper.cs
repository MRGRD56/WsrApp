using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WsrApp.Context;
using WsrApp.Model;

namespace WsrApp.Server.Helpers
{
    internal static class DataHelper
    {
        internal static async Task<User> GetUserAsync(Guid token, AppDbContext db)
        {
            await db.Users.LoadAsync();
            await db.Teachers.LoadAsync();
            await db.Faculties.LoadAsync();
            var dbToken = await db.ApiTokens.FirstOrDefaultAsync(x => x.Token == token);
            return dbToken?.User;
        }
    }
}

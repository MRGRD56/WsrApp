using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WsrApp.Context;
using WsrApp.Model;
using WsrApp.Server.Helpers;

namespace WsrApp.Server.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessTokenController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AccessTokenController(AppDbContext db)
        {
            _db = db;
            _db.Users.Load();
        }

        [HttpGet]
        public async Task<ActionResult<Guid>> Get(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest(MethodHelper.GetParametersString(MethodHelper.GetAsyncMethod(MethodBase.GetCurrentMethod())));
            }

            var teacher = await _db.Teachers.FirstOrDefaultAsync(x => x.Login.ToLower() == login.Trim().ToLower() && x.Password == password);
            if (teacher == null)
            {
                return BadRequest("Неверные данные");
            }

            var token = await _db.ApiTokens.OrderBy(x => x.CreationTime).LastOrDefaultAsync(x => x.User.Id == teacher.Id);
            if (token == null)
            {
                token = new ApiToken(teacher);
                await _db.ApiTokens.AddAsync(token);
                await _db.SaveChangesAsync();
            }

            return Ok(token.Token);
        }
    }
}

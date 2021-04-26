using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WsrApp.Context;
using WsrApp.Model;
using WsrApp.Server.Helpers;

namespace WsrApp.Server.Controllers.Api
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProfileController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("api/profile")]
        public async Task<ActionResult<Teacher>> GetProfile(Guid token)
        {
            if (token == default)
            {
                return BadRequest(MethodHelper.GetCurrentAsyncParametersString());
            }

            var user = await DataHelper.GetUserAsync(token, _db);

            if (user == null)
            {
                return BadRequest("Пользователь не найден.");
            }

            return Ok(user);
        }

        [HttpGet("api/images/{id}")]
        public async Task<IActionResult> GetImage([FromRoute] int id, Guid token)
        {
            if (token == default)
            {
                return BadRequest(MethodHelper.GetCurrentAsyncParametersString());
            }

            var user = await DataHelper.GetUserAsync(token, _db);

            if (user == null)
            {
                return BadRequest("Пользователь не найден.");
            }

            if (id != 1)
            {
                return NotFound("Изображение не найдено.");
            }

            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("WsrApp.Server.Resources.Images.avatar1.png");
            var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);

            var file = memoryStream.ToArray();

            return File(file, "image/png");
        }
    }
}

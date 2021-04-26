using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WsrApp.Context;
using WsrApp.Model;
using WsrApp.Server.Helpers;

namespace WsrApp.Server.Controllers.Api
{
    [ApiController]
    public class ConsultationsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ConsultationsController(AppDbContext db)
        {
            _db = db;
            _db.Students.Load();
            _db.Projects.Load();
            _db.ProjectStages.Load();
        }

        /// <summary>
        /// Возвращает список принятых консультаций преподавателя.
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/consultations")]
        public async Task<ActionResult<List<Consultation>>> Get(Guid token)
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

            if (user is not Teacher teacher)
            {
                return Forbid("Действие недоступно для данного пользователя.");
            }

            var consultations = await _db.Consultations.Where(x => x.IsAccepted && x.Teacher.Id == teacher.Id).ToListAsync();
            return Ok(consultations);
        }

        /// <summary>
        /// Возвращает список ещё не принятых консультаций преподавателя.
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/consultations/unaccepted")]
        public async Task<ActionResult<List<Consultation>>> GetUnaccepted(Guid token)
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

            if (user is not Teacher teacher)
            {
                return Forbid("Действие недоступно для данного пользователя.");
            }

            var consultations = await _db.Consultations.Where(x => !x.IsAccepted && x.Teacher.Id == teacher.Id).ToListAsync();
            return Ok(consultations);
        }

        /// <summary>
        /// Принимает не принятую консультацию.
        /// </summary>
        /// <returns></returns>
        [HttpPut("api/consultations/unaccepted/{id}")]
        public async Task<ActionResult> AcceptUnaccepted([FromRoute] int id, Guid token)
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

            if (user is not Teacher teacher)
            {
                return Forbid("Действие недоступно для данного пользователя.");
            }

            var consultation = await _db.Consultations.FindAsync(id);
            if (consultation == null)
            {
                return NotFound("Консультация не найдена.");
            }
            if (consultation.IsAccepted)
            {
                return NotFound("Консультация уже принята.");
            }

            consultation.IsAccepted = true;
            await _db.SaveChangesAsync();

            return Ok(consultation);
        }
    }
}

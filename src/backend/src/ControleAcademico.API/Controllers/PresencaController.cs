using System;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleAcademico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresencaController : ControllerBase
    {
        private readonly IPresencaService _presencaService;

        public PresencaController(IPresencaService presencaService)
        {
            _presencaService = presencaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var presencas = await _presencaService.PegarTodosPresencaAsynk();
                if (presencas == null) return NoContent();
                return Ok(presencas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar presenças. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPresenca(Presenca model)
        {
            try
            {
                var presenca = await _presencaService.AdicionarPresenca(model);
                if (presenca == null) return NoContent();
                return Ok(presenca);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar presença. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresenca(int id, Presenca model)
        {
            try
            {
                if (model.IdDisciplinasUsuario != id)
                    return StatusCode(StatusCodes.Status409Conflict, "Você está tentando atualizar a presença errada");

                var presenca = await _presencaService.AtualizarPresenca(model);
                if (presenca == null) return NoContent();
                return Ok(presenca);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar presença com id: {id}. Erro: {ex.Message}");
            }
        }


    }
}

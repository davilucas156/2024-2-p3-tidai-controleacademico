using System;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleAcademico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasTarefaController : ControllerBase
    {
        private readonly INotasTarefasService _notasTarefasService;

        public NotasTarefaController(INotasTarefasService notasTarefasService)
        {
            _notasTarefasService = notasTarefasService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var notas = await _notasTarefasService.PegarTodosNotasAsynk();
                if (notas == null) return NoContent();
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar notas. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostNota(NotasTarefa model)
        {
            try
            {
                var nota = await _notasTarefasService.AdicionarNotas(model);
                if (nota == null) return NoContent();
                return Ok(nota);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar nota. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNota(int id, NotasTarefa model)
        {
            try
            {
                if (model.IdTarefa != id)
                    return StatusCode(StatusCodes.Status409Conflict, "Você está tentando atualizar a nota errada");

                var nota = await _notasTarefasService.AtualizarNotas(model);
                if (nota == null) return NoContent();
                return Ok(nota);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar nota com id: {id}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            try
            {
                var nota = await _notasTarefasService.PegarNotasPorTudo(id);
                if (nota == null)
                    return StatusCode(StatusCodes.Status409Conflict, "Você está tentando deletar a nota que não existe");

                if (await _notasTarefasService.DeletarNotas(id))
                {
                    return Ok(new { message = "Nota deletada" });
                }
                else
                {
                    return BadRequest("Ocorreu um problema ao tentar deletar a nota.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar nota com id: {id}. Erro: {ex.Message}");
            }
        }
    }
}

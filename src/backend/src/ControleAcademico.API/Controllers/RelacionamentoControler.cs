using System;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleAcademico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinasUsuarioController : ControllerBase
    {
        private readonly IRelacionamentoUsuarioDisciplinaService _relacionamentoService;

        public DisciplinasUsuarioController(IRelacionamentoUsuarioDisciplinaService relacionamentoService)
        {
            _relacionamentoService = relacionamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var relacionamentos = await _relacionamentoService.PegarTodosRelacionamentoAsynk();
                if (relacionamentos == null) return NoContent();
                return Ok(relacionamentos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar relacionamentos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRelacionamento(DisciplinasUsuario model)
        {
            try
            {
                var relacionamento = await _relacionamentoService.AdicionarRelacionamento(model);
                if (relacionamento == null) return NoContent();
                return Ok(relacionamento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar relacionamento. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelacionamento(int id, DisciplinasUsuario model)
        {
            try
            {
                if (model.IdDisciplinas != id)
                    return StatusCode(StatusCodes.Status409Conflict, "Você está tentando atualizar o relacionamento errado");

                var relacionamento = await _relacionamentoService.AtualizarRelacionamento(model);
                if (relacionamento == null) return NoContent();
                return Ok(relacionamento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar relacionamento com id: {id}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelacionamento(int id)
        {
            try
            {
                var relacionamento = await _relacionamentoService.PegarRelacionamentoPorTudo(matricula: id);
                if (relacionamento == null)
                    return StatusCode(StatusCodes.Status409Conflict, "Você está tentando deletar o relacionamento que não existe");

                if (await _relacionamentoService.DeletarRelacionamento(id))
                {
                    return Ok(new { message = "Relacionamento deletado" });
                }
                else
                {
                    return BadRequest("Ocorreu um problema ao tentar deletar o relacionamento.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar relacionamento com id: {id}. Erro: {ex.Message}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using static ControleAcademico.Domain.Entities.TarefasDisciplina;

namespace ControleAcademico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaDisciplinaController : ControllerBase
    {
        private readonly ITarefaDisciplinaService _TarefaDisciplinaService;
        public TarefaDisciplinaController(ITarefaDisciplinaService TarefaDisciplinaService)
        {
            _TarefaDisciplinaService = TarefaDisciplinaService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cursos = await _TarefaDisciplinaService.PegarTodosTarefaAsynk();
                if (cursos == null) return NoContent();

                return Ok(cursos);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Atividades. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCurso(TarefasDisciplina model)
        {
            try
            {
                var atividade = await _TarefaDisciplinaService.AdicionarTarefa(model);
                if (atividade == null) return NoContent();

                return Ok(atividade);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Adicionar Atividades. Erro: {ex.Message}");
            }
        }

[HttpPut("{id}")]
public async Task<IActionResult> PutTarefaDisciplina(int id, TarefasDisciplina model)
{
    try
    {
        if (model.IdTarefa != id)
            return this.StatusCode(StatusCodes.Status409Conflict, "Você está tentando atualizar a atividade errada.");

        var tarefaAtualizada = await _TarefaDisciplinaService.AtualizarTarefa(model);
        if (tarefaAtualizada == null) return NoContent();

        return Ok(tarefaAtualizada);
    }
    catch (System.Exception ex)
    {
        return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar atualizar a tarefa com id: {id}. Erro: {ex.Message}");
    }
}



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursos(int id)
        {
            try
            {
                var atividade = await _TarefaDisciplinaService.PegarTarefaPorTudo(idTarefa: id);
                if (atividade == null)
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando deletar a atividade que não existe");

                if (await _TarefaDisciplinaService.DeletarTarefa(id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    return BadRequest("Ocorreu um problema não específico ao tentar deletar a atividade.");
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar Atividade com id: ${id}. Erro: {ex.Message}");
            }
        }
    }
}
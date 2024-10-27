using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using static ControleAcademico.Domain.Entities.Curso;

namespace ControleAcademico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _CursoService;
        public CursoController(ICursoService CursoService)
        {
            _CursoService = CursoService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cursos = await _CursoService.PegarTodosCursoAsynk();
                if (cursos == null) return NoContent();

                return Ok(cursos);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Atividades. Erro: {ex.Message}");
            }
        }

        [HttpGet("filtrados")]
        public async Task<IActionResult> GetCursosFiltrados(int? id = null, string? nome = null, TiposCurso? tipo = null, Niveis? nivel = null)
        {
            try
            {
                var cursos = await _CursoService.PegarCursoPorTudo(id, nome, tipo, nivel);
                if (cursos == null || cursos.Length == 0) return NoContent();

                return Ok(cursos);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cursos com filtros aplicados. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCurso(Curso model)
        {
            try
            {
                var atividade = await _CursoService.AdicionarCurso(model);
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
public async Task<IActionResult> PutCurso(int id, Curso model)
{
    try
    {
        if (model.IdCursos != id)
            return this.StatusCode(StatusCodes.Status409Conflict,
                "Você está tentando atualizar a atividade errada");

        var atividade = await _CursoService.AtualizarCurso(model);
        if (atividade == null) return NoContent();

        return Ok(atividade);
    }
    catch (System.Exception ex)
    {
        return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar Atualizar Atividade com id: {id}. Erro: {ex.Message}");
    }
}


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursos(int id)
        {
            try
            {
                var atividade = await _CursoService.PegarCursoPorTudo(id: id);
                if (atividade == null)
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando deletar a atividade que não existe");

                if (await _CursoService.DeletarCurso(id))
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
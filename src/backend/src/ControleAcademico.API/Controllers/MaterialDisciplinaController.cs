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
    public class MaterialDisciplinaController : ControllerBase
    {
        private readonly IMaterialDisciplinaService _MaterialDisciplinaService;
        public MaterialDisciplinaController(IMaterialDisciplinaService MaterialDisciplinaService)
        {
            _MaterialDisciplinaService = MaterialDisciplinaService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cursos = await _MaterialDisciplinaService.PegarTodosMaterialAsynk();
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
        public async Task<IActionResult> PostCurso(MaterialDisciplina model)
        {
            try
            {
                var atividade = await _MaterialDisciplinaService.AdicionarMaterial(model);
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
public async Task<IActionResult> PutCurso(int id, MaterialDisciplina model)
{
    try
    {
        if (model.IdDisciplinas != id)
            return this.StatusCode(StatusCodes.Status409Conflict,
                "Você está tentando atualizar a atividade errada");

        var atividade = await _MaterialDisciplinaService.AtualizarMaterial(model);
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
                var atividade = await _MaterialDisciplinaService.PegarMaterialPorTudo(idMateria: id);
                if (atividade == null)
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando deletar a atividade que não existe");

                if (await _MaterialDisciplinaService.DeletarMaterial(id))
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
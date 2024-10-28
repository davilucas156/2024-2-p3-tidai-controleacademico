using System;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using ControleAcademico.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleAcademico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = await _usuarioService.PegarTodosUsuarioAsynk();
                if (usuarios == null) return NoContent();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar usuários. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario(Usuario model)
        {
            try
            {
                var usuario = await _usuarioService.AdicionarUsuario(model);
                if (usuario == null) return NoContent();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar usuário. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario model)
        {
            try
            {
                if (model.Matricula != id)
                    return StatusCode(StatusCodes.Status409Conflict, "Você está tentando atualizar o usuário errado");

                var usuario = await _usuarioService.AtualizarUsuario(model);
                if (usuario == null) return NoContent();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar usuário com id: {id}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioService.PegarUsuarioPorTudo(matricula: id);
                if (usuario == null)
                    return StatusCode(StatusCodes.Status409Conflict, "Você está tentando deletar o usuário que não existe");

                if (await _usuarioService.DeletarUsuario(id))
                {
                    return Ok(new { message = "Usuário deletado" });
                }
                else
                {
                    return BadRequest("Ocorreu um problema ao tentar deletar o usuário.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar usuário com id: {id}. Erro: {ex.Message}");
            }
        }
    }
}

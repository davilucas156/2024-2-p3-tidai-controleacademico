using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Disciplina;
using static ControleAcademico.Domain.Entities.Usuario;


namespace ControleAcademico.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> AdicionarUsuario(Usuario model);
        Task<Usuario> AtualizarUsuario(Usuario model);
        Task<bool> DeletarUsuario(int IdUsuario);
        Task<Usuario[]> PegarTodosUsuarioAsynk();
        Task<Usuario[]> PegarUsuarioPorTudo(int? matricula=null, string? nome=null, string? cpf=null, string? email=null, string? endereco=null, Tipos? tipo=null, string? senha=null, int? idCurso=null, Curso? idCursoNavigation=null);
    }
}
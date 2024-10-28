using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Curso;
using static ControleAcademico.Domain.Entities.Usuario;

namespace ControleAcademico.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepo : IgeralRepo
    {
        Task<Usuario[]> PegarTodasAsync();
        Task<Usuario[]> PegarUsuarioPorTudoAsync(int? matricula=null, string? nome=null, string? cpf=null, string? email=null, string? endereco=null, Tipos? tipo=null, string? senha=null, int? idCurso=null, Curso? idCursoNavigation=null);
    }
}
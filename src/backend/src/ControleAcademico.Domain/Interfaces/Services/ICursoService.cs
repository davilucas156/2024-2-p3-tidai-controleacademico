using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Curso;


namespace ControleAcademico.Domain.Interfaces.Services
{
    public interface ICursoService
    {
        Task<Curso> AdicionarCurso(Curso model);
        Task<Curso> AtualizarCurso(Curso model);
        Task<bool> DeletarCurso(int cursoId);
        Task<Curso[]> PegarTodosCursoAsynk();
        Task<Curso[]> PegarCursoPorTudo(int? id = null, string? nome = null, TiposCurso? tipo = null, Niveis? nivel = null);
    }
}
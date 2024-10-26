using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;


namespace ControleAcademico.Domain.Interfaces.Services
{
    public interface ICursoService
    {
        Task<Curso> AdicionarCurso(Curso model);
        Task<Curso> AtualizarCurso(Curso model);
        Task<bool> DeletarCurso(int cursoId);
        Task<bool> ConcluirCurso(Curso model);
        Task<Curso[]> PegarTodosCursoAsynk();
        Task<Curso> PegarTodosCursoPorId(int cursoId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Disciplina;


namespace ControleAcademico.Domain.Interfaces.Services
{
    public interface IDisciplinaService
    {
        Task<Disciplina> AdicionarDisciplina(Disciplina model);
        Task<Disciplina> AtualizarDisciplina(Disciplina model);
        Task<bool> DeletarDisciplina(int IdDisciplina);
        Task<Disciplina[]> PegarTodosDisciplinaAsynk();
        Task<Disciplina[]> PegarDisciplinaPorTudo(int? id= null, string? nome= null, int? semestre= null, int?IdCurso=null, Curso? idCursoNavigation=null);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Disciplina;

namespace ControleAcademico.Domain.Interfaces.Repositories
{
    public interface IDisciplinaRepo : IgeralRepo
    {
        Task<Disciplina[]> PegarTodasAsync();
        Task<Disciplina[]> PegarDisciplinaPorTudoAsync(int? id= null, string? nome= null, int? semestre= null, int?IdCurso=null, Curso? idCursoNavigation=null);
    }
}
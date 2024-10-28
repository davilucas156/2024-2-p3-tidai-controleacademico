using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Curso;

namespace ControleAcademico.Domain.Interfaces.Repositories
{
    public interface IMaterialDisciplinaRepo : IgeralRepo
    {
        Task<MaterialDisciplina[]> PegarTodasAsync();
        Task<MaterialDisciplina[]> PegarMaterialPorTudoAsync(int? idMateria=null, int? modulo=null, string? titulo=null, string? linkVideoaula=null, string? descricao=null, int? idDisciplinas=null, Disciplina? idDisciplinasNavigation=null);
    }
}
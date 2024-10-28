using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Curso;

namespace ControleAcademico.Domain.Interfaces.Repositories
{
    public interface IRelacionamentoUsuarioDisciplinaRepo : IgeralRepo
    {
        Task<DisciplinasUsuario[]> PegarTodasAsync();
        Task<DisciplinasUsuario[]> PegarRelacionamentoPorTudoAsync(int? matricula=null, int? idDisciplinas=null);
    }
}
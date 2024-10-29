using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Curso;
using static ControleAcademico.Domain.Entities.Presenca;

namespace ControleAcademico.Domain.Interfaces.Repositories
{
    public interface IPresencaRepo : IgeralRepo
    {
        Task<Presenca[]> PegarTodasAsync();
        Task<Presenca[]> PegarPresencaPorTudoAsync(DateOnly? data=null, Presença? presenca=null, int? idDisciplinasUsuario=null);
    }
}
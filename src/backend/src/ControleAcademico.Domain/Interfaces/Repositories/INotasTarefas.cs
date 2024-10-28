using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Curso;

namespace ControleAcademico.Domain.Interfaces.Repositories
{
    public interface INotasTarefasRepo : IgeralRepo
    {
        Task<NotasTarefa[]> PegarTodasAsync();
        Task<NotasTarefa[]> PegarTarefasPorTudoAsync(int? nota=null, int? matricula=null, int? idTarefa=null);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Curso;

namespace ControleAcademico.Domain.Interfaces.Repositories
{
    public interface ITarefasDisciplinaRepo : IgeralRepo
    {
        Task<TarefasDisciplina[]> PegarTodasAsync();
        Task<TarefasDisciplina[]> PegarTarefaPorTudoAsync(int? idTarefa =null, string? modulo=null, string? titulo=null, int? valor=null, DateOnly? dataEntrega=null, string? linkArquivoTarefa=null, int? idDisciplinas=null);
    }
}
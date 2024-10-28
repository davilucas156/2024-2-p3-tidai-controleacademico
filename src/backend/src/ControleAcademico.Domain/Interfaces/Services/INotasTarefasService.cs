using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Disciplina;


namespace ControleAcademico.Domain.Interfaces.Services
{
    public interface INotasTarefasService
    {
        Task<NotasTarefa> AdicionarNotas(NotasTarefa model);
        Task<NotasTarefa> AtualizarNotas(NotasTarefa model);
        Task<bool> DeletarNotas(int IdNotas);
        Task<NotasTarefa[]> PegarTodosNotasAsynk();
        Task<NotasTarefa[]> PegarNotasPorTudo(int? nota=null, int? matricula=null, int? idTarefa=null);
    }
}
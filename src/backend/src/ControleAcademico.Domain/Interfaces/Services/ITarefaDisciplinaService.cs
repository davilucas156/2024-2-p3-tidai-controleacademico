using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleAcademico.Domain.Entities;
using static ControleAcademico.Domain.Entities.Disciplina;


namespace ControleAcademico.Domain.Interfaces.Services
{
    public interface ITarefaDisciplinaService
    {
        Task<TarefasDisciplina> AdicionarTarefa(TarefasDisciplina model);
        Task<TarefasDisciplina> AtualizarTarefa(TarefasDisciplina model);
        Task<bool> DeletarTarefa(int IdTarefa);
        Task<TarefasDisciplina[]> PegarTodosTarefaAsynk();
        Task<TarefasDisciplina[]> PegarTarefaPorTudo(int? idTarefa =null, string? modulo=null, string? titulo=null, int? valor=null, DateOnly? dataEntrega=null, string? linkArquivoTarefa=null, int? idDisciplinas=null);
    }
}